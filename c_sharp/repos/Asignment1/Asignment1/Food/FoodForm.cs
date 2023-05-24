using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Asignment1.Food
{
    public partial class FoodForm : Form
    {
        public FoodItem foodItem { get; set; }
        public FoodForm()
        {
            InitializeComponent();
            if(foodItem == null)
            {
                foodItem = new FoodItem();
            }
        }

        public void UpdateGUI()
        {
            lstIngredient.Items.Clear();
            lstIngredient.Items.AddRange(foodItem.Ingredients.ToStringArray());
        }

        public bool CheckInput()
        {
            if(txtRecipeName.Text == "")
            {
                MessageBox.Show("You forgot the recipe's name");
                return false;
            }
            else if(txtRecipeIngredient.Text == "")
            {
                MessageBox.Show("You forgot the ingredient");
                return false;
            }
            return true;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(CheckInput())
            {
                foodItem.Name = txtRecipeName.Text;
                foodItem.Ingredients.Add(txtRecipeIngredient.Text);
                UpdateGUI();
            }

            txtRecipeIngredient.Focus();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(lstIngredient.SelectedIndex != -1 && txtRecipeIngredient.Text != "")
            {
                foodItem.Ingredients.ChangeAt(txtRecipeIngredient.Text, lstIngredient.SelectedIndex);
                UpdateGUI();
            }
            else
            {
                MessageBox.Show("Select the item in the list and then fill the ingredients text box with the name change as well");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            foodItem.Name = txtRecipeName.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lstIngredient.SelectedIndex != 1 && txtRecipeIngredient.Text != "")
            {
                foodItem.Ingredients.DeleteAt(lstIngredient.SelectedIndex);
                UpdateGUI();
            }
        }

        private void lstIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = foodItem.Ingredients.GetAt(lstIngredient.SelectedIndex);
            txtRecipeIngredient.Text = item;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
