import os  # import os in order to use os.getcwd()


def count_occurences(lst):  # contructing the occurrences
    freq = {}                 # use the brackets because we are talking about occurrence
    for n in lst:
        n = n.lower()  # do not forget to use .lower() to make all the letters return as low capital letters
        if n in "abcdefghijklmnopqrstuvwxyz":  # if n in the english alphabet continue otherwise pass
            # The keys() method returns a view object. The view object contains the keys of the dictionary, as a list.
            keys = freq.keys()
            if n in keys:
                freq[n] += 1  # counting the letters
            else:
                freq[n] = 1
        else:
            pass  # pass if it is not an english character
    return freq


# use two parameters because it is smoother later
def print_histogram(occurences, occurences_per_star):
    # Define 'print variable' and print text line
    print_out = "Histogram (where each star represents %s occurences):\n\n" % occurences_per_star
    # going through the letters in alphabetically sorted order
    for key in sorted(occurences.keys()):
        print_out += "%s | %s\n" % (key, "*" *  # calculating how many stars we will show per letter(total number devided by occurrences per star)
                                    int(occurences[key]/occurences_per_star))
    return print_out  # returning our combined print variable


def readintegers(file_path, occurences_per_star):
    lst = []  # define empty list
    try:
        # open the file and use encoding because Windows 10 could not open the file
        with open(file_path, encoding='utf-8') as file:
            for line in file:
                # the strip() method removes any leading (spaces at the beginning) and trailing (spaces at the end) characters (space is the default leading character to remove)
                for c in line.strip("\n"):
                    # The append() method appends an element to the end of the list.
                    lst.append(c)
        occurences = count_occurences(lst)  # define the variable occurences
        print("Number of different chars = %s \n\n" %
              occurences)  # use string interpolation
        # return the print histrogram with the two paremeters
        return print_histogram(occurences, occurences_per_star)
    except IOError:  # fails for an I/O-related reason
        print("There is no such a file", file_path,
              "You should check and try again")
    except Exception:  # for any other errors
        print("An error occured for some reason. You should check the error and try again")


print("\nFile of newspaper:\n")
# here is where we are using the second parameter making smoother the graph in the end
print(readintegers(os.getcwd() + "\\ng222iu_assign3\\eng_news_100K-sentences.txt", 20000))
print("\nFile of holy grail:\n")
# same goes here
print(readintegers(os.getcwd() + "\\ng222iu_assign3\\holy_grail.txt", 100))

# in my opinion the frequency is super close and this is because some letters have higher probability occuring
print("Yes, I would say that the files have almost the same frequency")
