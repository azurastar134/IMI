using Asignment1.AnimalsGen;
using Asignment1.Food;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Asignment1
{
    public partial class MainForm : Form
    {
        
        private AnimalManager manager = new AnimalManager();
        public MainForm()
        {


            InitializeComponent();
            InitializeGUI();
        }



        private void InitializeGUI()
        {
            ctrlLbl.Text = "'Name' should not be empty \nYou can add digits if you want!";
            boxGender.Enabled = false;
            boxAge.Enabled = false;
            boxSize.Enabled = false;
            boxSpecification1.Enabled = false;
            boxSpecification2.Enabled = false;
            txtSnake.Enabled = false;
            /// <summary>
            /// Add all genders in the combobox (list) named boxGender in my case.
            /// Add the items in the boxGender by using technically the property of AddRange.
            /// What we actually do here is that we have a base class that is Enum and we try to get the names of the GenderType class
            /// </summary>
            boxGender.Items.AddRange(Enum.GetNames(typeof(GenderType)));
            boxGender.SelectedIndex = 0;  // just use equal to 0 to avoid any kind of errors. We start from 0 instead of -1

            foreach (var category in Enum.GetValues(typeof(CategoryType))) // If I understood correct this is another guy of adding the items in the list box. I think we could
                                                                           // use the previous lines of code as well. 
            {
                lstCategoryType.Items.Add(category); // finally add the items into the category
            }
            lstCategoryType.SelectedIndex = 0; //same as in the line 31
        }

        /// <summary>
        /// Here we make some sort of validation. Making an enum variable then we check if the index is greater than zero. 
        /// That means that the user picked a category and can continue.
        /// If they did not picked something then we have an else that works
        /// as a validation that shows an error type message
        /// and then we just set the categoryType to Mammal as a default
        /// </summary>
        /// <returns>category</returns>
        private CategoryType ReadCategory()
        {
            CategoryType category;

            if (lstCategoryType.SelectedIndex >= 0)
                category = (CategoryType)lstCategoryType.SelectedIndex;
            else
            {
                MessageBox.Show("Please select a category to begin!");
                category = CategoryType.Mammal;
            }
            return category;
        }


        /// <summary>
        /// Here is a method in order to read the input from the user.
        /// </summary>
        /// <returns>animal</returns>
        private Animal ReadInput()
        {
            CategoryType category = ReadCategory();
            Animal animal = null;




            switch (category)
            {
                case CategoryType.Mammal:
                    animal = CreateMammal();
                    break;
                case CategoryType.Bird:
                    animal = CreateBird();
                    break;
                case CategoryType.Reptile:
                    animal = CreateReptile();
                    break;
                default:
                    return null;

            }
            // if animal is not null we continue reading the common values
            if (animal != null)
            {
                ReadCommonValues(ref animal);
            }

            return animal;
        }
        /// <summary>
        /// This method refer to the Animal class and checks the common values like name and age
        /// </summary>
        /// <param name="animal"></param>
        private void ReadCommonValues(ref Animal animal)
        {
            double age = 0;
            string name = boxName.Text;
            string size = boxSize.Text;

            if (string.IsNullOrEmpty(size) || (!(name is string)))
            {
                MessageBox.Show("Enter a valid size");
            }
            else
                animal.Size = size;

            if (string.IsNullOrEmpty(name) || (!(name is string)))
            {
                MessageBox.Show("Enter a valid name");
            }
            else
                animal.Name = name;



            if (double.TryParse(boxAge.Text, out age))
            {
                animal.Age = age;
            }
            else
                MessageBox.Show("Enter a valid age");
            animal.Gender = (GenderType)Enum.Parse(typeof(GenderType), boxGender.Text);
            animal.Category = ReadCategory();

        }

        /// <summary>
        /// Control method so we display the correct things each time we are running the application.
        /// </summary>
        /// <returns>animal</returns>
        private Animal CreateReptile()
        {
            Animal animal;
            double weight = 0;
            string livesInWater = cmbReptile.Text;

            if (!double.TryParse(boxSpecification1.Text, out weight))
            {
                MessageBox.Show("Please give a valid value for the weight");

            }

            ReptileSpecies species = (ReptileSpecies)Enum.Parse(typeof(ReptileSpecies), lstSpecies.Text); //parse the enum value to the lstSpecies.Text or in other words a string.
            animal = ReptileFactory.CreateReptile(species, weight, livesInWater); // make a local object

            if (species == ReptileSpecies.Frog) // if the species is a frog we call the property of venomous and assign it in the cmCharacteristics.Text
            {
                ((Frog)animal).Venomous = cmCharacteristics.Text;
                lblAnimal.Text = "Frog";
            }
            else if (species == ReptileSpecies.Snake) // else if we do the same for the snake. However we call the length property
            {
                double length = 0;
                if (!double.TryParse(txtSnake.Text, out length))
                {
                    MessageBox.Show("Please give a valid value for the length");
                    
                }
                else
                {
                    lblAnimal.Text = "Snake";
                    ((Snake)animal).Length = txtCharacteristics.Text;
                }


            }
            else //else add in the combobox continents and call the Continent property for the Lizard.
            {
                ((Lizard)animal).Continent = cmCharacteristics.Text;
                lblAnimal.Text = "Lizard";
            }

            return animal;
        }
        /// <summary>
        /// Following the same pattern as CreateReptile above. We make some validation controls and then we continue with creating a bird. However we check the index of lstSpecies 
        /// in order to get the desired result and display that at our boxes. I am not going to write how it works in details. It follows the same pattern as above.
        /// </summary>
        /// <returns>animal</returns>
        private Animal CreateBird()
        {

            Animal animal = null;
            double speed = 0;
            double wingsLength = 0;
            if (!double.TryParse(boxSpecification1.Text, out speed))
            {
                MessageBox.Show("Please give a valid value for speed");

            }
            if (!double.TryParse(boxSpecification2.Text, out wingsLength))
            {
                MessageBox.Show("Please give a value of the wings' length ");
            }


            BirdSpecies species = (BirdSpecies)Enum.Parse(typeof(BirdSpecies), lstSpecies.Text);
            animal = BirdFactory.CreateBird(species, speed, wingsLength);

            if ((BirdSpecies)lstSpecies.SelectedIndex == BirdSpecies.Dove)
            {

                string color = cmCharacteristics.Text;

                if (string.IsNullOrEmpty(color) || (!(color is string)))
                {
                    MessageBox.Show("Please enter a valid string for a color");
                }
                else
                {
                    ((Dove)animal).Colors = cmCharacteristics.Text;
                    lblAnimal.Text = "Dove";
                }
            }
            else
            {

                ((Hawk)animal).Eating = cmCharacteristics.Text;
                lblAnimal.Text = "Hawk";
            }
            return animal;
        }

        /// <summary>
        /// Folling the same pattern as in the above methods
        /// </summary>
        /// <returns>animal</returns>
        private Animal CreateMammal()
        {

            Animal animal = null;
            int numOfTeeth = 0;
            double tailLength = 0;
            if (!int.TryParse(boxSpecification1.Text, out numOfTeeth))
            {
                MessageBox.Show("Please give a valid value for the number of teeth");

            }
            if (!double.TryParse(boxSpecification2.Text, out tailLength))
            {
                MessageBox.Show("Please give a valid value for the length of tail");
            }

            MammalSpecies species = (MammalSpecies)Enum.Parse(typeof(MammalSpecies), lstSpecies.Text);
            animal = MammalFactory.CreateMammal(species, numOfTeeth, tailLength);

            if (species == MammalSpecies.Dog)
            {

                string breed = txtCharacteristics.Text;
                if (string.IsNullOrEmpty(breed) || (!(breed is string)))
                {
                    MessageBox.Show("Please enter a valid string for a color");
                }
                else
                {
                    ((Dog)animal).Breed = txtCharacteristics.Text;
                    lblAnimal.Text = "Dog";
                }


            }
            else if (species == MammalSpecies.Cat)
            {

                ((Cat)animal).Cuteness = cmCharacteristics.SelectedIndex + 1;
                lblAnimal.Text = "Cat";
            }




            return animal;
        }

        private void UpdateGUI()
        {
            string[] infoStrings = manager.ToStringArray();
            if (infoStrings != null)
            {
                lstAnimalInfo.Items.AddRange(infoStrings);
            }

            //manager.Sort(new SortByName());
        }

        /// <summary>
        /// Here we have the method for when someone clicks to the add animal button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAnimal_Click(object sender, EventArgs e)
        {

            lstAnimalInfo.Items.Clear();
            ctrlLbl.Text = "";
            Animal animal = ReadInput(); //we call the ReadInput and then we assign the lblAnimalInfo.Text by using the ToString method in order to display the information.
            if (animal != null)
            {
                manager.AddAnimal(animal);
                lblAnimalInfo.Text = animal.GetExtraInfo();
                UpdateGUI();
            }
            btnAddAnimal.Enabled = false;
            lblChange.Text = "In order to change an animal first click on the animal! The 'Add this animal' button will disappear but you can freely activate it again after pressing the 'Change' button!";

        }

        /// <summary>
        /// This method starts by making some var local variables for the enum categories. Afterwards, there is an if-elseif-else statement that clears and updates the information
        /// each time someone selectes a different type of category. There is a foreach loop that adds into species the values of the category and updates the labels of the application.
        /// .Items.Add(species) add the species in the list box.
        /// </summary>
        private void UpdateSpeciesListBox()
        {
            var mammalspecies = CategoryType.Mammal;
            var birdspecies = CategoryType.Bird;
            var reptilespecies = CategoryType.Reptile;

            if ((CategoryType)lstCategoryType.SelectedIndex == birdspecies)
            {
                lblSpeciesCharacteristic.Text = "";
                btnAddAnimal.Enabled = false;
                boxName.Enabled = false;
                txtCharacteristics.Enabled = false;
                cmCharacteristics.Enabled = false;
                ctrlLbl.Text = "Please choose the category and \n" +
                    "the animal you would like to add!";
                lstSpecies.Items.Clear();
                cmbReptile.Visible = false;
                foreach (var species in Enum.GetValues(typeof(BirdSpecies))) // If I understood correct this is another guy of adding the items in the list box. I think we could
                                                                             // use the previous lines of code as well. 
                {
                    lstSpecies.Items.Add(species); // finally add the items into the category
                    lblSpecification1.Text = "Speed in km:";
                    lblSpecification2.Text = "Length of wings in cm:";


                }
            }
            else if ((CategoryType)lstCategoryType.SelectedIndex == mammalspecies)
            {
                lblSpeciesCharacteristic.Text = "";
                ctrlLbl.Text = "Please choose the category and \n" +
                    "the animal you would like to add!";
                btnAddAnimal.Enabled = false;
                boxName.Enabled = false;
                lstSpecies.Items.Clear();
                txtCharacteristics.Enabled = false;
                cmCharacteristics.Enabled = false;
                cmbReptile.Visible = false;

                foreach (var species in Enum.GetValues(typeof(MammalSpecies)))
                {

                    lstSpecies.Items.Add(species);
                    lblSpecification1.Text = "Number of teeth: ";
                    lblSpecification2.Text = "Tails length in cm: ";
                }

            }
            else if ((CategoryType)lstCategoryType.SelectedIndex == reptilespecies)
            {
                lblSpeciesCharacteristic.Text = "";
                ctrlLbl.Text = "Please choose the category and \n" +
                    "the animal you would like to add!";
                btnAddAnimal.Enabled = false;
                boxName.Enabled = false;
                lstSpecies.Items.Clear();
                txtCharacteristics.Enabled = false;
                cmCharacteristics.Enabled = false;
                cmbReptile.Visible = true;
                cmbReptile.Enabled = false;
                cmbReptile.Items.Add("True");
                cmbReptile.Items.Add("False");
                foreach (var species in Enum.GetValues(typeof(ReptileSpecies)))
                {

                    lstSpecies.Items.Add(species);
                    lblSpecification1.Text = "Weight in kg: ";
                    lblSpecification2.Text = "Lives in water: ";

                }
            }


        }
        /// <summary>
        /// This method is a control for displaying the correct categories and animals. Afterwards, each time you select a certain index
        /// from the list with animals updates the combo box by either turning it off or on and it does the same for the text characteristics. Thus
        /// when some animals need the usage of the combo box the following function controls what to display.
        /// </summary>
        private void UpdateListSpecies()
        {

            CategoryType index = (CategoryType)lstCategoryType.SelectedIndex;
            switch (index)
            {
                case CategoryType.Mammal:
                    MammalSpecies myMammal = (MammalSpecies)lstSpecies.SelectedIndex;
                    btnAddAnimal.Enabled = false;
                    boxName.Enabled = false;
                    switch (myMammal)
                    {
                        case MammalSpecies.Cat: // if cat update the necessary information
                            cmCharacteristics.Items.Clear();
                            lblSpeciesCharacteristic.Text = "Cuteness";
                            lstCategoryType.Enabled = false;
                            txtSnake.Visible = false;
                            txtCharacteristics.Visible = false;
                            cmCharacteristics.Visible = true;
                            boxName.Enabled = true;
                            System.Object[] CutenessItems = new System.Object[10]; //make a for loop for 10 items. And add them in the CutenessItems object.
                            for (int i = 0; i <= 9; i++)
                            {
                                CutenessItems[i] = i + 1;
                            }
                            cmCharacteristics.Items.AddRange(CutenessItems);
                            ctrlLbl.Text = "Please type a name in the 'Name' box!\n" +
                                "Use 'Erase All' if you want to change the category/animal!";
                            if (!(string.IsNullOrEmpty(boxName.Text) || string.IsNullOrWhiteSpace(boxName.Text)))
                            {
                                ctrlLbl.Text = "";
                            }


                            break;
                        case MammalSpecies.Dog: // when dog do the same update certain fields
                            lblSpeciesCharacteristic.Text = "Breed";
                            txtCharacteristics.Visible = true;
                            txtSnake.Visible = false;
                            cmCharacteristics.Visible = false;
                            boxName.Enabled = true;
                            ctrlLbl.Text = "Please type a name in the 'Name' box!\n" +
                                "Use 'Erase All' if you want to change the category/animal!";
                            lstCategoryType.Enabled = false;
                            if (!(string.IsNullOrEmpty(boxName.Text) || string.IsNullOrWhiteSpace(boxName.Text)))
                            {
                                ctrlLbl.Text = "";
                            }
                            break;
                    }
                    break;
                case CategoryType.Bird:
                    BirdSpecies myBird = (BirdSpecies)lstSpecies.SelectedIndex; //same here as well

                    switch (myBird)
                    {
                        case BirdSpecies.Hawk: //update the fields
                            cmCharacteristics.Items.Clear();
                            cmCharacteristics.Text = "";
                            lblSpeciesCharacteristic.Text = "Eating mice: ";
                            txtCharacteristics.Visible = false;
                            cmCharacteristics.Visible = true;
                            txtSnake.Visible = false;
                            cmCharacteristics.Items.Add("Yes"); // add yes or no
                            cmCharacteristics.Items.Add("No");
                            boxName.Enabled = true;
                            ctrlLbl.Text = "Please type a name in the 'Name' box!\n" +
                                "Use 'Erase All' if you want to change the category/animal!";
                            lstCategoryType.Enabled = false;
                            if (!(string.IsNullOrEmpty(boxName.Text) || string.IsNullOrWhiteSpace(boxName.Text)))
                            {
                                ctrlLbl.Text = "";
                            }
                            break;
                        case BirdSpecies.Dove: //update the fields and add in the combo box some colors
                            cmCharacteristics.Items.Clear();
                            cmCharacteristics.Text = "";
                            lblSpeciesCharacteristic.Text = "Color: ";
                            txtCharacteristics.Visible = false;
                            txtSnake.Visible = false;
                            cmCharacteristics.Visible = true;
                            cmCharacteristics.Items.Add("Black");
                            cmCharacteristics.Items.Add("Gray");
                            cmCharacteristics.Items.Add("White");
                            cmCharacteristics.Items.Add("Pink");
                            cmCharacteristics.Items.Add("Gray-Black");
                            cmCharacteristics.Items.Add("Gray-White");
                            cmCharacteristics.Items.Add("Other");
                            boxName.Enabled = true;
                            ctrlLbl.Text = "Please type a name in the 'Name' box!\n" +
                                "Use 'Erase All' if you want to change the category/animal!";
                            lstCategoryType.Enabled = false;
                            if (!(string.IsNullOrEmpty(boxName.Text) || string.IsNullOrWhiteSpace(boxName.Text)))
                            {
                                ctrlLbl.Text = "";
                            }
                            break;
                    }
                    break;
                case CategoryType.Reptile: // when reptile follow the same pattern.
                    ReptileSpecies myReptile = (ReptileSpecies)lstSpecies.SelectedIndex;

                    switch (myReptile)
                    {
                        case ReptileSpecies.Lizard:

                            cmCharacteristics.Items.Clear();
                            txtCharacteristics.Visible = false;
                            cmCharacteristics.Visible = true;
                            lblSpeciesCharacteristic.Text = "Continent: ";
                            cmCharacteristics.Items.Add("Europe");
                            cmCharacteristics.Items.Add("Africa");
                            cmCharacteristics.Items.Add("Latin America");
                            cmCharacteristics.Items.Add("U.S");
                            cmCharacteristics.Items.Add("Asia");
                            boxName.Enabled = true;
                            txtSnake.Visible = false;
                            ctrlLbl.Text = "Please type a name in the 'Name' box!\n" +
                                "Use 'Erase All' if you want to change the category/animal!";
                            lstCategoryType.Enabled = false;
                            if (!(string.IsNullOrEmpty(boxName.Text) || string.IsNullOrWhiteSpace(boxName.Text)))
                            {
                                ctrlLbl.Text = "";
                            }


                            break;
                        case ReptileSpecies.Frog:
                            cmCharacteristics.Items.Clear();
                            txtCharacteristics.Visible = false;
                            cmCharacteristics.Visible = true;
                            lblSpeciesCharacteristic.Text = "Venomous: ";
                            cmCharacteristics.Items.Add("Yes");
                            cmCharacteristics.Items.Add("No");
                            boxName.Enabled = true;
                            txtSnake.Visible = false;
                            ctrlLbl.Text = "Please type a name in the 'Name' box!\n" +
                                "Use 'Erase All' if you want to change the category/animal!";
                            lstCategoryType.Enabled = false;
                            if (!(string.IsNullOrEmpty(boxName.Text) || string.IsNullOrWhiteSpace(boxName.Text)))
                            {
                                ctrlLbl.Text = "";
                            }
                            break;
                        case ReptileSpecies.Snake:
                            cmCharacteristics.Items.Clear();
                            txtSnake.Visible = true;
                            txtCharacteristics.Visible = false;
                            cmCharacteristics.Visible = false;
                            lblSpeciesCharacteristic.Text = "Length: ";
                            boxName.Enabled = true;
                            ctrlLbl.Text = "Please type a name in the 'Name' box!\n" +
                                "Use 'Erase All' if you want to change the category/animal!";
                            lstCategoryType.Enabled = false;
                            if (!(string.IsNullOrEmpty(boxName.Text) || string.IsNullOrWhiteSpace(boxName.Text)))
                            {
                                ctrlLbl.Text = "";
                            }
                            break;
                    }
                    break;
            }

        }

        private void lstSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {


            //when lstspecies are selected we call the updatelistspecies function.

            UpdateListSpecies();

        }


        private void lstCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {



            CategoryType category = ReadCategory(); // here is for the category. Call the ReadCategory function 


            UpdateSpeciesListBox(); //update some fields when choosing some sort of category.


        }

        /// <summary>
        /// Method that when you clik on the check box disables most of the fields and updates the lstSpecies by adding all of the animals in it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxAllSpecies_CheckedChanged(object sender, EventArgs e)
        {



            if (chkBoxAllSpecies.Checked)
            {
                lstSpecies.Items.Clear();
                lstCategoryType.Enabled = false;
                AllSpecies index = (AllSpecies)lstSpecies.SelectedIndex;

                foreach (var species in Enum.GetValues(typeof(AllSpecies)))
                {
                    lstSpecies.Items.Add(species);
                }





            }
            else if (!chkBoxAllSpecies.Checked) // if the check box is unchecked restore everything
            {
                lstSpecies.Items.Clear();

                lstCategoryType.Enabled = true;
                boxGender.SelectedIndex = 0;
            }



        }

        private void EraseWhenChange()
        {
            btnAddAnimal.Visible = false;
            boxGender.SelectedIndex = 0;
            lstCategoryType.SelectedIndex = 0;
            boxAge.Text = "";
            boxSize.Text = "";
            boxName.Text = "";
            lstSpecies.SelectedIndex = -1;
            boxGender.SelectedIndex = 0;
            ctrlLbl.Text = "You can only change the name, age, gender and size!";
            boxName.Enabled = true;
            boxSpecification1.Visible = false;
            boxSpecification2.Visible = false;
            cmCharacteristics.Visible = false;
            lstCategoryType.Enabled = false;
            lstSpecies.Enabled = false;
            cmbReptile.Visible = false;
            chkBoxAllSpecies.Checked = false;
        }

        private void EraseAll()
        {
            
            boxGender.SelectedIndex = 0;
            lstCategoryType.SelectedIndex = 0;
            btnAddAnimal.Enabled = false;
            boxAge.Text = "";
            boxSize.Text = "";
            boxSpecification1.Text = "";
            boxSpecification2.Text = "";
            boxName.Text = "";
            lstSpecies.SelectedIndex = -1;
            lblAnimalInfo.Text = "";
            boxGender.SelectedIndex = 0;
            ctrlLbl.Text = "Please choose the category and \n" +
                    "the animal you would like to add!";
            boxName.Enabled = false;
            boxSpecification1.Enabled = false;
            boxSpecification2.Enabled = false;
            txtCharacteristics.Enabled = false;
            cmCharacteristics.Enabled = false;
            lblSpeciesCharacteristic.Text = "";
            lstCategoryType.Enabled = true;
            lstSpecies.Enabled = true;
            txtCharacteristics.Text = "";
            cmbReptile.Enabled = false;
            chkBoxAllSpecies.Checked = false;
            lblAnimal.Text = "";
            cmbReptile.Items.Clear();
            lstFoodSchedule.Items.Clear();
            lstAnimalInfo.ClearSelected();
            txtSnake.Text = "";
            txtSnake.Enabled = false;
            btnAddAnimal.Visible = true;
            btnAddAnimal.Enabled = false;
        }

        /// <summary>
        /// Made an erase button. I thought it was a good addition. To make the programme works smoother
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            EraseAll();
        }
        /// <summary>
        /// Method that loads a certain type of photo from by using the OpenFileDialog. Then a control if that continues when the photo is a correct type. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadAnimal_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName); // update the image box with the photo.
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // fix the size of the photo.


            }
        }



        private void boxName_TextChanged(object sender, EventArgs e)
        {
            string name = boxName.Text;


            if (string.IsNullOrWhiteSpace(name) || (!(name is string)))
            {
                ctrlLbl.Text = "'Name' should not be empty. \nYou can add digits if you want!";
                boxAge.Enabled = false;
                boxGender.Enabled = false;
                boxSize.Enabled = false;
                boxSize.Text = "";
                boxAge.Text = "";
                boxSpecification1.Enabled = false;
            }
            else
            {
                ctrlLbl.Text = "";
                boxAge.Enabled = true;

            }



        }



        private void boxAge_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(boxAge.Text) || string.IsNullOrEmpty(boxAge.Text))
            {
                ctrlLbl.Text = "Please fill in the box named 'Age'";
                boxGender.Enabled = false;
                boxSpecification1.Enabled = false;
                boxSize.Enabled = false;
                boxSize.Text = "";
                boxGender.SelectedIndex = -1;
            }
            else
            {
                boxGender.Enabled = true;
                boxSize.Enabled = true;
                ctrlLbl.Text = "Choose a gender and a size \n" +
                    "Give a size in whatever unit you want!";

            }

        }

        private void boxSpecification1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void boxSpecification2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void boxAge_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void boxSpecification1_TextChanged(object sender, EventArgs e)
        {
            btnAddAnimal.Enabled = false;
            
            cmbReptile.Text = " ";
            txtCharacteristics.Text = "";
            if (string.IsNullOrWhiteSpace(boxSpecification1.Text) || string.IsNullOrEmpty(boxSpecification1.Text))
            {
                ctrlLbl.Text = "Please enter values to the characteristics below.\n" +
                    "Do not leave the boxes empty to continue!";
                txtCharacteristics.Enabled = false;
                cmCharacteristics.Enabled = false;
                boxSpecification2.Enabled = false;
                cmbReptile.Enabled = false;
            }
            else
            {
                txtCharacteristics.Enabled = true;
                cmCharacteristics.Enabled = true;
                boxSpecification2.Enabled = true;
                cmbReptile.Enabled = true;
            }
        }

        private void boxSize_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(boxSize.Text) || string.IsNullOrWhiteSpace(boxSize.Text))
            {
                ctrlLbl.Text = "Do not leave the box 'Size' empty please!";
                boxSpecification1.Enabled = false;
                boxSpecification1.Text = "";

            }
            else
            {
                boxSpecification1.Enabled = true;

            }
        }

        private void boxSpecification2_TextChanged(object sender, EventArgs e)
        {
            btnAddAnimal.Enabled = false;

            if (string.IsNullOrWhiteSpace(boxSpecification2.Text) || string.IsNullOrEmpty(boxSpecification2.Text))
            {
                ctrlLbl.Text = "Please enter values to the characteristics below.\n" +
                    "Do not leave the boxes empty to continue!";
                txtCharacteristics.Enabled = false;
                cmCharacteristics.Enabled = false;
                txtCharacteristics.Text = "";
                txtSnake.Enabled = false;

            }
            else
            {
                txtCharacteristics.Enabled = true;
                cmCharacteristics.Enabled = true;

            }
        }

        private void txtCharacteristics_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCharacteristics.Text) || string.IsNullOrWhiteSpace(txtCharacteristics.Text))
            {
                ctrlLbl.Text = "In order to add an animal \n" +
                    "you have to not leave any box empty!";
                btnAddAnimal.Enabled = false;
            }
            else
            {
                lstSpecies.Enabled = false;
                btnAddAnimal.Enabled = true;
            }
        }

        private void cmCharacteristics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmCharacteristics.Text) || string.IsNullOrWhiteSpace(cmCharacteristics.Text))
            {
                ctrlLbl.Text = "Pick an option please!";
                btnAddAnimal.Enabled = false;

            }
            else
            {
                btnAddAnimal.Enabled = true;
                lstSpecies.Enabled = false;

            }

        }

        private void cmbReptile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbReptile.Text) || string.IsNullOrWhiteSpace(cmbReptile.Text))
            {
                ctrlLbl.Text = "Please enter values to the characteristics below.\n" +
                    "Do not leave the boxes empty to continue!";
                txtCharacteristics.Enabled = false;
                cmCharacteristics.Enabled = false;
                txtSnake.Enabled = false;

            }
            else
            {

                txtCharacteristics.Enabled = true;
                cmCharacteristics.Enabled = true;
                txtSnake.Enabled = true;


            }
        }

        private void ShowInputOfAnimalInGUI(Animal animal)
        {

            boxName.Text = animal.Name;
            boxAge.Text = animal.Age.ToString();
            boxGender.Text = animal.Gender.ToString();
            boxSize.Text = animal.Size;
            
        }



        private void lstAnimalInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            btnAddAnimal.Visible = false;

            int index = lstAnimalInfo.SelectedIndex;
            if (index == -1)
            {
                return;
            }


            //AnimalManager manager = null;

            Animal animal = manager.GetAt(index);
            
            if (animal is Dog mydog)
            {
                ShowInputOfAnimalInGUI(animal);
                boxSpecification1.Text = 
                txtCharacteristics.Text = ((Dog)animal).Breed.ToString();
                boxSpecification1.Text = mydog.numOfTeeth.ToString();
                boxSpecification2.Text = mydog.tailLength.ToString();
                lstCategoryType.SelectedIndex = 1;
                lstSpecies.SelectedIndex = 1;

            }
            else if (animal is Cat mycat)
            {
                ShowInputOfAnimalInGUI(animal);
                cmCharacteristics.Text = ((Cat)animal).Cuteness.ToString();
                boxSpecification1.Text = mycat.numOfTeeth.ToString();
                boxSpecification2.Text = mycat.tailLength.ToString();
                lstCategoryType.SelectedIndex = 1;
                lstSpecies.SelectedIndex = 0;

            }
            else if (animal is Hawk myhawk)
            {
                ShowInputOfAnimalInGUI(animal);
                cmCharacteristics.Text = ((Hawk)animal).Eating.ToString();
                boxSpecification1.Text = myhawk.speed.ToString();
                boxSpecification2.Text = myhawk.wingsLength.ToString();
                lstCategoryType.SelectedIndex = 0;
                lstSpecies.SelectedIndex = 0;

            }
            else if (animal is Dove mydove)
            {
                ShowInputOfAnimalInGUI(animal);
                cmCharacteristics.Text = ((Dove)animal).Colors.ToString();
                boxSpecification1.Text = mydove.speed.ToString();
                boxSpecification2.Text = mydove.wingsLength.ToString();
                lstCategoryType.SelectedIndex = 0;
                lstSpecies.SelectedIndex = 1;

            }
            else if (animal is Lizard mylizard)
            {
                ShowInputOfAnimalInGUI(animal);
                cmCharacteristics.Text = ((Lizard)animal).Continent.ToString();
                boxSpecification1.Text = mylizard.weight.ToString();
                boxSpecification2.Text = mylizard.livesInWater.ToString();
                lstCategoryType.SelectedIndex = 2;
                lstSpecies.SelectedIndex = 0;

            }
            else if (animal is Frog myfrog)
            {
                ShowInputOfAnimalInGUI(animal);
                cmCharacteristics.Text = ((Frog)animal).Venomous.ToString();
                boxSpecification1.Text = myfrog.weight.ToString();
                boxSpecification2.Text = myfrog.livesInWater.ToString();
                lstCategoryType.SelectedIndex = 2;
                lstSpecies.SelectedIndex = 1;
            }
            else if (animal is Snake mysnake)
            {
                ShowInputOfAnimalInGUI(animal);
                txtCharacteristics.Text = ((Snake)animal).Length.ToString();
                boxSpecification1.Text = mysnake.weight.ToString();
                boxSpecification2.Text = mysnake.livesInWater.ToString();
                lstCategoryType.SelectedIndex = 2;
                lstSpecies.SelectedIndex = 2;
            }
            txtCharacteristics.Enabled = false;
            boxSpecification1.Enabled = false;
            boxSpecification2.Enabled = false;
            cmbReptile.Enabled = false;
            cmCharacteristics.Enabled = false;
            
             


            FoodSchedule foodSchedule = animal.GetFoodSchedule();
            lblAnimalInfo.Text = animal.GetExtraInfo();
            lblAnimal.Text = animal.GetAnimalString();

            lstFoodSchedule.Items.Clear();
            lstFoodSchedule.Items.Add(foodSchedule.Title());

            lblEaterType.Text = foodSchedule.Eatertype.ToString();

            string[] foodList = foodSchedule.GetFoodInfoStringArray();

            lstFoodSchedule.Items.Clear();
            lstFoodSchedule.Items.AddRange(foodList);

            lstCategoryType.Enabled = false;
            lstSpecies.Enabled = false;
            lblChange.Text = "Give again the details of the animal you want!";
            

        }

        private void lstFoodSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            FoodForm recipeForm = new FoodForm();

            if(recipeForm.ShowDialog() == DialogResult.OK)
            {
                lstRecipeList.Items.Add(recipeForm.foodItem.ToString());
            }
        }

        private void lstRecipeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {

            int index = lstAnimalInfo.SelectedIndex;
            Animal animalChange = ReadInput();
            manager.ChangeAt(animalChange, index);
            lblAnimalInfo.Text =  animalChange.GetExtraInfo();

            UpdateGUI();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstAnimalInfo.SelectedIndex;
            if (index >= 0)
            {
                manager.DeleteAt(index);
                lstFoodSchedule.Items.Clear();
                lstAnimalInfo.Items.Clear();
                lblAnimalInfo.Text = "";
                EraseAll();
                UpdateGUI();

            }


        }

        private void btnSortById_Click(object sender, EventArgs e)
        {
            manager.Sort(new SortById());
            lstAnimalInfo.Items.Clear();
            UpdateGUI();
        }

        private void btnSortByName_Click(object sender, EventArgs e)
        {

            manager.Sort(new SortByName());
            lstAnimalInfo.Items.Clear();
            UpdateGUI();


        }

        private void boxGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSnake_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtSnake_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSnake.Text) || string.IsNullOrWhiteSpace(txtSnake.Text))
            {
                ctrlLbl.Text = "In order to add an animal \n" +
                    "you have to not leave any box empty!";
                btnAddAnimal.Enabled = false;
            }
            else
            {
                lstSpecies.Enabled = false;
                btnAddAnimal.Enabled = true;
            }
        }
    }
}

