import math  # import math for using sqrt
import os  # import os in order to use os.getcwd()


def readintegers(file_path):
    lst = []  # define an empyy list again
    try:  # try in order to use except
        with open(file_path, "r") as file:  # open the file
            for line in file:
                # replace some of the characters for simplification
                line = line.replace(":-", ", ").replace(":", ", ")
                # strip every line and method splits a string into a list.
                for i in line.strip("\n").split(", "):
                    # add every i which is an integer in the list
                    lst.append(i)
    except IOError:  # fails for an I/O-related reason
        print("There is no such a file", file_path,
              "You should check and try again")
    except Exception:  # for any other errors
        print("An error occured for some reason. You should check the error and try again")
    # using string interpolation and assign mean and std and return
    return ("mean = %s, standard deviation = %s" % (mean(lst), std(lst)))


def mean(lst):
    count = 0
    for i in lst:  # counting the i with each interation
        count += int(i)
    return count/len(lst)  # count over lenght of the list


def std(lst):
    avg = mean(lst)  # define avg
    count = 0
    for i in lst:
        # the formula for getting the nominator of std
        count += (int(i)-avg)*(int(i)-avg)
    return math.sqrt(count/len(lst))        # over the length and we are done


print("File A: %s" % readintegers(os.getcwd() +
                                  "\\ng222iu_assign3\\file_10000integers_A.txt"))  # print mean and std for file A
print("File B: %s" % readintegers(os.getcwd() +
                                  "\\ng222iu_assign3\\file_10000integers_B.txt"))  # print mean and stf for file B
