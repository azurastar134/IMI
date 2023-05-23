import os  # import os in order to be able to use os.getcwd()
file_path = os.getcwd()  # general pathing
# add the following path way to the general pathing
file_path += "\\ng222iu_assign3\\duck_story.txt"


def readfiles(file_path):  # define the function
    try:  # use the try in order to make the exceptions later
        lst = []               # define variable lst
        with open(file_path, "r") as a:  # open the file for reading
            for line in a:
                # add to list the line stripped lines
                lst.append(line.strip("\n"))
    except IOError:  # fails for an I/O-related reason
        print("There is no such a file", file_path,
              "You should check and try again")
    except Exception:  # for any other errors
        print("An error occured for some reason. You should check the error and try again")
    return lst


print(readfiles(file_path))


def writefiles(lines, file_path):
    try:
        with open(file_path, "w") as a:  # open the file and write
            for line in lines:
                a.write(line + "\n")  # write in the file and then line gap
    except IOError:  # fails for an I/O-related reason
        print("There is no such a file", file_path,
              "You should check and try again")
    # Raised when an operation or function is applied to an object of inappropriate type.
    except TypeError:
        print("It seems that there is no file. You should check and try again")
    except Exception:  # for any other errors
        print("An error occured for some reason. You should check the error and try again")


# where the file is headed
filepathout = (os.getcwd() + "\\ng222iu_assign3\\duck_story2.txt")
lines = readfiles(file_path)  # define lines according to the first function
writefiles(lines, filepathout)  # in order to get the file
