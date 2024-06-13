# Summative 4
## Challenge Description

Portfolio Results Calculator Revisited - A revised program of Summative 2 that allows for files of a specific format to be read and calculates each students grade.

## Code Listing

```cs
using System;
using System.IO;
using System.Reflection;
using System.Reflection.PortableExecutable;


//File Handling

//Get List of Files
string[] GetFileNames()
{
    //Get Directory Containing required Files. Edit to correct path.
    string directoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).Replace("bin\\Debug\\net6.0", "MarkFiles\\");

    //Get string array of File Names
    string[] files = Directory.GetFiles(directoryPath);
    return files;

}

//Get Individual File Name
string GetIndividualFileName(int fileNumber)
{
    string[] files = GetFileNames();
    string fileName = files[fileNumber];
    int indexStart = fileName.IndexOf("MarkFiles\\") + 10;
    int indexEnd = fileName.IndexOf(".mark");

    string fileString = fileName.Substring(indexStart,indexEnd-indexStart);

    return fileString;
}

//Choose File
int ChooseFile()
{
    string[] files = GetFileNames();
    Console.WriteLine("FILES:");



    //Output To Console File Names
    for (int i = 0; i < files.Length; i++)
    {
        int index = files[i].IndexOf("MarkFiles\\")+10;
        string fileString = files[i].Substring(index);
        Console.WriteLine(string.Format("{0}. {1}",i+1, fileString));
    }

    //Choosing File. Includes Error Handling.
    Console.WriteLine("Please Select a file to load:");
    if (int.TryParse(Console.ReadLine(), out int fileNumber) == true)
    {
        fileNumber = fileNumber - 1;

        if (fileNumber >= 0 && fileNumber <= 12)
        {
            Console.WriteLine();
            return fileNumber;
        }

        else
        {
            Console.Clear();
            Console.WriteLine("Incorrect entry");
            return ChooseFile();
        }
    }

    else
    {
        Console.Clear();
        Console.WriteLine("Incorrect entry");
        return ChooseFile();
    }

}

int GetLineCountFromFile(int fileNumber)
{
    int lineCount = 0;
    string[] filepaths = GetFileNames();

    //Get Number Of Lines In File
    using (StreamReader reader = new StreamReader(filepaths[fileNumber]))
    {
        while (reader.ReadLine() != null)
        {
            lineCount++;
        }
    } 
    
    return lineCount;
}

//Read all Strings From File
string[] GetFileStringRecordArray(int fileNumber)
{
    int lineCount = GetLineCountFromFile(fileNumber);
    string[] filepaths = GetFileNames();

    //Creates Array of Strings for each line in file
    using (StreamReader reader = new StreamReader(filepaths[fileNumber]))
    {
        string[] recordArray = new string[lineCount];
        int count = 0;
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            recordArray[count] = line;
            count++;
        }

        return recordArray;
    }

}


//Data Handling

//Retrieve information from file string. Loop to get individual strings.
string[] GetDataStringArray(string readString)
{


    //Get positions of '[' and ']'
    int[] openingBracketIndexes = new int[3];
    int[] closingBracketIndexes = new int[3];

    int count = 0;

    //Positions of '['
    for (int i = 0; i < readString.Length; i++)
    {
        if (readString[i] == '[')
        {
            openingBracketIndexes[count] = i;
            count++;
        }
    }

    count = 0;

    //Positions of ']'
    for (int i = 0; i < readString.Length; i++)
    {
        if (readString[i] == ']')
        {
            closingBracketIndexes[count] = i;
            count++;
        }
    }


    //Split String By Correct Indexes to produce manageable strings
    //e.g.

    /*[ID:2022232445,LastName:Grey,FirstName:Simon],[Challenges:[2, 3, 4, 5, 3, 2, 4, 5, 5],[Exam:7,Capstone:85] becomes:
     * 
     * [ID:2022232445,LastName:Grey,FirstName:Simon]
     * [Challenges:[2, 3, 4, 5, 3, 2, 4, 5, 5]
     * [Exam:7,Capstone:85]
    */

    string student = readString.Substring(openingBracketIndexes[0], closingBracketIndexes[0] - openingBracketIndexes[0] + 1);
    string marksChallenges = readString.Substring(openingBracketIndexes[1], closingBracketIndexes[1] - openingBracketIndexes[1] + 1);
    string marksExams = "[" + readString.Substring(closingBracketIndexes[1] + 2);

    //Create New String Array to store each variable
    string[] outputString = { student, marksChallenges, marksExams };

    return outputString;
}

//Retrieve Identification Data from DataStringArray
string GetIdentificationStringFromDataArray(string[] outputString)
{
    //Separate ID string into array of three 
    string[] identification = (outputString[0].Substring(1, outputString[0].Length - 2)).Split(',');

    //For ID string
    string studentID = identification[0].Substring(3).TrimStart().TrimEnd();

    //For FirstName String
    string firstName = identification[2].Substring(10).TrimStart().TrimEnd();

    //For LastName String
    string lastName = identification[1].Substring(9).TrimStart().TrimEnd();

    //Combine into Signature
    string signature = ($"{firstName} {lastName} ({studentID})");


    return signature;
}

//Retrieve DigitalPortfolioMarks Data from DataStringArray
int[] GetDigitalPortfolioMarksArrayFromStringArray(string[] outputString)
{
    //Get Array of marks from output Array in string format
    string digitalPortfolioMarksString = outputString[1].Substring(13, outputString[1].Length - 14);
    string[] digitalPortfolioMarksStringArray = digitalPortfolioMarksString.Split(",");



    //Convert Array of strings to array of digits
    int[] digitalPortfolioMarksArray = new int[9];

    for (int i = 0; i < digitalPortfolioMarksStringArray.Length; i++)
    {
        digitalPortfolioMarksStringArray[i] = digitalPortfolioMarksStringArray[i].TrimStart().TrimEnd();
        digitalPortfolioMarksArray[i] = int.Parse(digitalPortfolioMarksStringArray[i]);
    }



    return digitalPortfolioMarksArray;
}

//Retrieve OpenBookMark Data from DataStringArray
int GetOpenBookMarkFromStringArray(string[] outputString)
{
    //Get OpenBookMark
    string a = (outputString[2]).Substring(6);
    string[] b = a.Split(',');

    int output = int.Parse(b[0]);


    return output;
}

//Retrieve CapstoneMark Data from DataStringArray
int GetCapstoneMarkFromStringArray(string[] outputString)
{
    //Get CapstoneMark

    string a = outputString[2].Substring(17);
    string CapstoneMark = a.Substring(0, a.Length - 1);

    return int.Parse(CapstoneMark);
}



//Calculations

//Calculate Digital Portfolio Percentage
decimal GetDigitalPortfolioPercentageFromParts(int[] digitalPortfolioMarksArray)
{
    //Get two new arrays that hold the first 5 elements for Semester 1, and the last four for Semester 2
    int[] firstSemester = new int[5];
    Array.Copy(digitalPortfolioMarksArray, firstSemester, 5);

    int[] secondSemester = new int[4];
    Array.Copy(digitalPortfolioMarksArray, digitalPortfolioMarksArray.Length - 4, secondSemester, 0, 4);


    //Get smallest element from each and get total marks from each
    int semester1SmallestMark = 5;
    int semester1Total = 0;

    int semester2SmallestMark = 5;
    int semester2Total = 0;


    foreach (int mark in firstSemester)
    {
        semester1Total = semester1Total + mark;


    
        if (mark < semester1SmallestMark)
        {
            semester1SmallestMark = mark;
        }
    }

    foreach (int mark in secondSemester)
    {
        semester2Total = semester2Total + mark;

        if (mark < semester2SmallestMark)
        {
            semester2SmallestMark = mark;
        }
    }

    // Minus smallest marks from total marks
    semester1Total = semester1Total - semester1SmallestMark;
    semester2Total = semester2Total - semester2SmallestMark;

    //Get Total
    int digitalPortfolioMark = semester1Total + semester2Total;


    //Get Percentage
    decimal digitalPortfolioPercentage = (digitalPortfolioMark / 35M) * 100;


    return digitalPortfolioPercentage;
}

//Calculate Open Book Percentage
decimal GetOpenBookProgrammingPercentage(int openBookProgrammingMark)
{
    //Get Percentage
    decimal openBookProgrammingPercentage = (openBookProgrammingMark / 7M) * 100;


    return openBookProgrammingPercentage;
}

//Calculate Capstone Percentage
decimal GetCapstonePercentage(int capstoneProjectMark)
{
    //Get Percentage
    decimal capstoneProjectPercentage = (capstoneProjectMark / 100M) * 100;

    return capstoneProjectPercentage;
}

//Calculate OverallClassification Percentage
decimal GetOverallClassification (int capstoneProjectMark, decimal digitalPortfolioPercentage, decimal openBookProgrammingPercentage, decimal capstoneProjectPercentage)
{
    //Get Percentage for overall classification from other percentages
    decimal overallClassificationPercentage = ((digitalPortfolioPercentage * 50M) / 100) + ((openBookProgrammingPercentage * 25M) / 100) + ((capstoneProjectPercentage * 25M) / 100);
    overallClassificationPercentage = Math.Round(overallClassificationPercentage, 0);

    //Check if failed core modules
    if (overallClassificationPercentage > 34 && (openBookProgrammingPercentage < 40 || capstoneProjectPercentage < 40))
    {
        overallClassificationPercentage = 34;
        return overallClassificationPercentage;
    }

    else
    {
        return overallClassificationPercentage;
    }

}

//Calculate Result
string GetResult(decimal overallClassificationPercentage)
{
    if (overallClassificationPercentage >= 0 && overallClassificationPercentage < 40)
    {
        return "fail";
    }

    else if (overallClassificationPercentage >= 40 && overallClassificationPercentage < 50)
    {
        return "third";

    }

    else if (overallClassificationPercentage >= 50 && overallClassificationPercentage < 60)
    {
        return "lowersecond";
    }

    else if (overallClassificationPercentage >= 60 && overallClassificationPercentage < 70)
    {
        return "uppersecond";
    }

    else if (overallClassificationPercentage >= 70)
    {
        return "first";
    }

    else
    {
        return "error";
    }
}

//InsertionSortResults
string[] GetSortedOutputStringArray(string[] identityStringArray, decimal[] scoreIndexArray)
{

    for (int i = 0; i < identityStringArray.Length; i++)                                                        //Insertion Sort whilst also maintaining index Position
    {
        decimal key = scoreIndexArray[i];                                                                       //Set original score
        string nameKey = identityStringArray[i];                                                                //Set original identity
        int previousIndex = i - 1;                                                                              //Set the previous index 

        while (previousIndex >= 0 && scoreIndexArray[previousIndex] < key)                                      //Loop while it is not the first element and the previous element in the list is bigger than the current element
        {
            scoreIndexArray[previousIndex + 1] = scoreIndexArray[previousIndex];                                //Swap the two Scores
            identityStringArray[previousIndex + 1] = identityStringArray[previousIndex];                        //Swap the identities
            previousIndex--;                                                                                    //Decrease the previousIndex value so that we continue the sort until we find the correct position for "key"
        }

        scoreIndexArray[previousIndex + 1] = key;                                                               //After the while loop we ensure the correct positions are maintained within both arrays
        identityStringArray[previousIndex + 1] = nameKey;

    }

    //Round Decimal percentages to nearest percentage
    for (int i = 0; i < scoreIndexArray.Length; i++)
    {
        scoreIndexArray[i] = Math.Round(scoreIndexArray[i], 0);
    }



    //Create New string Array with correctly modified texts
    string[] SortedOutputStringArray = new string[identityStringArray.Length];

    for (int i = 0; i < identityStringArray.Length; i++)
    {
        SortedOutputStringArray[i] = string.Format("{0} - {1}", scoreIndexArray[i], identityStringArray[i]);
    }

    return SortedOutputStringArray;


}



//Output
void OutputResults(int filenumber = 10)
{
    //Get Array of strings from file
    string[] ArrayofStringsInFile = GetFileStringRecordArray(filenumber);

    //Two Arrays for Identity String and Identity Index
    int lineCount = GetLineCountFromFile(filenumber);
    string[] identityStringArray = new string[lineCount];
    decimal[] scoreIndexArray = new decimal[lineCount];

    //Incrementing index each pass
    int count = 0;



    //Declare Variables
    int fail = 0;
    int third = 0;
    int lowersecond = 0;
    int uppersecond = 0;
    int first = 0;
    int error = 0;

    //Loop over each line in file
    foreach (string data in ArrayofStringsInFile)
    {
        string[] newString = GetDataStringArray(data);

        int[] digitalPortfolioMarksArray = GetDigitalPortfolioMarksArrayFromStringArray(newString);
        int openBookProgrammingMark = GetOpenBookMarkFromStringArray(newString);
        int capstoneMark = GetCapstoneMarkFromStringArray(newString);


        decimal digitalPortfolioPercentage = GetDigitalPortfolioPercentageFromParts(digitalPortfolioMarksArray);
        decimal openBookProgrammingPercentage = GetOpenBookProgrammingPercentage(openBookProgrammingMark);
        decimal capstonePercentage = GetCapstonePercentage(capstoneMark);
        decimal classificationdecimal = GetOverallClassification(capstoneMark, digitalPortfolioPercentage, openBookProgrammingPercentage, capstonePercentage);

        string result = GetResult(classificationdecimal);

        //Create Arrays for Identities
        string idString = GetIdentificationStringFromDataArray(newString);
        identityStringArray[count] = idString;
        scoreIndexArray[count] = classificationdecimal;
        count++;



        //Check Classification, incrementing total
        if (result == "fail")
        {
            fail++;
        }

        else if (result == "third")
        {
            third++;

        }

        else if (result == "lowersecond")
        {
            lowersecond++;


        }

        else if (result == "uppersecond")
        {
            uppersecond++;

        }

        else if (result == "first")
        {
            first++;
        }

        else if (result == "error")
        {
            error++;
        }

    }

    //Output to File
    string[] sortedStringArray = GetSortedOutputStringArray(identityStringArray, scoreIndexArray);
    string fileName = GetIndividualFileName(filenumber);
    string location = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).Replace("bin\\Debug\\net6.0", "Output\\");

    using (StreamWriter writer = new StreamWriter(string.Format("{0}\\{1}Output.txt", location, fileName)))
    {
        for (int i = 0; i < sortedStringArray.Length; i++)
        {
            writer.WriteLine(sortedStringArray[i]);
        }

    }



    //Output to console
    Console.WriteLine(String.Format("{0} people received a First.", first));
    Console.WriteLine(String.Format("{0} people received a Upper Second.", uppersecond));
    Console.WriteLine(String.Format("{0} people received a Lower Second.", lowersecond));
    Console.WriteLine(String.Format("{0} people received a Third.", third));
    Console.WriteLine(String.Format("{0} people failed.", fail));



}

//Main Execution
void main()
{
    bool running = true;
    do
    {
        int file = ChooseFile();
        OutputResults(file);
        Console.WriteLine();


        Console.Write("Continue? Enter y: ");
        string choice = Console.ReadLine();

        if (choice.ToLower() == "y")
        {
            Console.Clear();
        }

        else
        {
            running = false;
        }

    } while (running);
}



main();
```

## Test Plan

| **Test Number** | **Input File**                      | **Expected Output**                                                                  | **Output File**                          | **Comment**                                                                                                                                                           | **Pass/Fail** |
|-----------------|-------------------------------------|--------------------------------------------------------------------------------------|------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------|
| **1**           | 1StudentFail33.mark                 | ![image](/Assets/Summative4/Test1.PNG)                                               | 1StudentFail33Output.txt                 | Files with just 1 student<br>can help test individual <br>paths through your code <br>and identify bugs                                                               |    **PASS**   |
| **2**           | 1StudentFail35.mark                 | ![image](/Assets/Summative4/Test2.PNG)                                               | 1StudentFail35Output.txt                 | Files with just 1 student<br>can help test individual <br>paths through your code <br>and identify bugs                                                               |    **PASS**   |
| **3**           | 1StudentFail39.mark                 | ![image](/Assets/Summative4/Test3.PNG)                                               | 1StudentFail39Output.txt                 | Files with just 1 student <br>can help test individual <br>paths through your code <br>and identify bugs                                                              |    **PASS**   |
| **4**           | 1StudentFailCappedCapstone34.mark   | ![image](/Assets/Summative4/Test4.PNG)                                               | 1StudentFailCappedCapstone34Output.txt   | Files with just 1 student <br>can help test individual <br>paths through your code <br>and identify bugs                                                              |    **PASS**   |
| **5**           | 1StudentFailCappedExam34.mark       | ![image](/Assets/Summative4/Test5.PNG)                                               | 1StudentFailCappedExam34Output.txt       | Files with just 1 student <br>can help test individual <br>paths through your code <br>and identify bugs                                                              |    **PASS**   |
| **6**           | 1StudentFailZeroMarks.mark          | ![image](/Assets/Summative4/Test6.PNG)                                               | 1StudentFailZeroMarksOutput.txt          | Files with just 1 student <br>can help test individual <br>paths through your code <br>and identify bugs                                                              |    **PASS**   |
| **7**           | 1StudentFirst71.mark                | ![image](/Assets/Summative4/Test7.PNG)                                               | 1StudentFirst71Output.txt                | Files with just 1 student <br>can help test individual <br>paths through your code <br>and identify bugs                                                              |    **PASS**   |
| **8**           | 1StudentThird41.mark                | ![image](/Assets/Summative4/Test8.PNG)                                               | 1StudentThird41Output.txt                | Files with just 1 student <br>can help test individual <br>paths through your code <br>and identify bugs                                                              |    **PASS**   |
| **9**           | 1StudentTwoOne61.mark               | ![image](/Assets/Summative4/Test9.PNG)                                               | 1StudentTwoOne61Output.txt               | Files with just 1 student <br>can help test individual <br>paths through your code <br>and identify bugs                                                              |    **PASS**   |
| **10**          | 1StudentTwoTwo59.mark               | ![image](/Assets/Summative4/Test10.PNG)                                              | 1StudentTwoTwo59Output.txt               | Files with just 1 student <br>can help test individual <br>paths through your code <br>and identify bugs                                                              |    **PASS**   |
| **11**          | 5StudentsOneEachClassification.mark | ![image](/Assets/Summative4/Test11.PNG)                                              | 5StudentsOneEachClassificationOutput.txt | Files with a small number <br>of students can help identify <br>issues with counting the <br>number of students in each <br>classification and <br>sorting the output |    **PASS**   |
| **12**          | 326Students.mark                    | ![image](/Assets/Summative4/Test12.PNG)                                              | 326StudentsOutput.txt                    | Big data file                                                                                                                                                         |    **PASS**   |
| **13**          | 256Students.mark                    | ![image](/Assets/Summative4/Test13.PNG)                                              | 256StudentsOutput.txt                    | Big data file with less<br>possibility of rounding <br>errors                                                                                                         |    **PASS**   |

## Feedback Request

If there is anything specific you want to ask for feedback on include that here
