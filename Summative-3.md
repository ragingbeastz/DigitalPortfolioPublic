# Summative 3

## Challenge Description

Program that allows you to enter the number of competitors in an oyster competition, the name of each competitor, and the number of oysters each competitor ate. Once all the competitors and their scores are entered the program sorts them from highest score to lowest and outputs the results to the console and a separate text file.

## Code Listing

```cs
/*"At the New Orleans Oyster Festival, 
 * eight eaters will slurp down as many mollusks as they can in the allotted eight minutes. 
 * The winner takes home $1,000 from Major League Eating (MLE), 
 * which also oversees the ESPN-televised Nathan’s Famous hot dog eating contest on Coney Island every summer.
 * " (The world of competitive oyster eating: 'your stomach is like a human Tetris' | Food | The Guardian.)
 */

using System.IO;



Console.WriteLine("Oyster Eating Competition");

bool success  = false;
int competitorsAmount = 0;

do                             //Validation of Input
{
    Console.WriteLine("How Many Competitors are there?: ");
    if (int.TryParse(Console.ReadLine(), out competitorsAmount))                //Check if value is a number
    {
        if (competitorsAmount > 8 || competitorsAmount <= 0)                    //Check if input is between 1 and 8 inclusive
        {
            Console.WriteLine("Invalid input. Must be between 1 and 8.");
            continue;
        }

        else;
        success = true;
    }

    else
    {
        Console.WriteLine("Must Enter a Number. Please Try Again");
        continue;
    }

} while (!success);

        
int[] oystersEaten = new int[competitorsAmount];        //Declare arrays for how many oysters eaten and their names
string[] name = new string[competitorsAmount];


for (int i = 0; i < competitorsAmount; i++)
{
    Console.WriteLine("What is competitor number {0}'s name?", i+1);
    name[i] = Console.ReadLine();

    Console.WriteLine("How many oysters did {0} eat?", name[i]);
    oystersEaten[i] = int.Parse(Console.ReadLine());


}



for (int i = 0; i < competitorsAmount; i++)     //Insertion Sort whilst also maintaining index Position
{
    int key = oystersEaten[i];                  //Set original amount of oysters eaten
    string nameKey = name[i];                   //Set original name of competitor
    int previousIndex = i - 1;                  //Set the previous index 

    while (previousIndex >= 0 && oystersEaten[previousIndex] < key)         //Loop while it is not the first element and the previous element in the list is bigger than the current element
    {
        oystersEaten[previousIndex + 1] = oystersEaten[previousIndex];  //Swap the two OystersEaten Scores
        name[previousIndex + 1] = name[previousIndex];                  //Swap the respective player names
        previousIndex--;                                                //Decrease the previousIndex value so that we continue the sort until we find the correct position for "key"
    }

    oystersEaten[previousIndex + 1] = key;      //After the while loop we ensure the correct positions are maintained
    name[previousIndex + 1] = nameKey;
    

}


//System.Reflection.Assembly.GetExecutingAssembly().Location is a way to retrieve the file path of the currently executing assembly
//Path.GetDirectoryName() returns the containing folder of the currently executing file
//.Replace() replaces a substring with another substring

//Using them altogether:

string csFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Replace("\\", "\\\\") + "\\\\";   //Returns usable file Path of current \bin\Debug\net6.0\ folder


StreamWriter sw = new StreamWriter(csFilePath + "results.txt");                 //Creates New results.txt to put results into using StreamWriter

for (int i = 0; i < competitorsAmount; i++)                                             //Loops through our arrays 
{
    Console.WriteLine("{0}. {1} ate {2} oysters", i+1, name[i], oystersEaten[i]);
    sw.WriteLine("{0}. {1} ate {2} oysters", i + 1, name[i], oystersEaten[i]);              //Outputs correct format of results both to console and text file
}


sw.Flush();
sw.Close();                     //Flushes text file buffer and closes it
```

## Test Plan

| **Test Number** | **Input**                                                                                                                                                                      | **Expected Output**                                                                                                                                                                                                                                                                     | **Actual Output**                                                                                                                                                                                                                                                                       | **Pass/Fail** |
|-----------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------|
| 1               | 5<br>Simon Grey<br>232<br>David Parker<br>286<br>John Dixon<br>212<br>Adrian Morgan<br>432<br>Sonya Thomas<br>492                                                              | 1. Sonya Thomas ate 492 oysters<br>2. Adrian Morgan ate 432 oysters<br>3. David Parker ate 286 oysters<br>4. Simon Grey ate 232 oysters<br>5. John Dixon ate 212 oysters<br>![image](/Assets/sum3_Test1.PNG)                                                                                 | 1. Sonya Thomas ate 492 oysters<br>2. Adrian Morgan ate 432 oysters<br>3. David Parker ate 286 oysters<br>4. Simon Grey ate 232 oysters<br>5. John Dixon ate 212 oysters<br>![image](/Assets/sum3_Test1.PNG)                                                                                  | PASS          |
| 2               | 3<br>Michelle Lesco<br>324<br>Darron Breeden<br>480<br>Adrian Morgan<br>312                                                                                                    | 1. Darron Breeden ate 480 oysters<br>2. Michelle Lesco ate 324 oysters<br>3. Adrian Morgan ate 312 oysters<br>![image](/Assets/sum3_Test2.PNG)                                                                                                                                                                | 1. Darron Breeden ate 480 oysters<br>2. Michelle Lesco ate 324 oysters<br>3. Adrian Morgan ate 312 oysters<br>![image](/Assets/sum3_Test2.PNG)                                                                                                                                                                 | PASS          |
| 3               | 8<br>Lily Anderson<br>47<br>Ethan Miller<br>53<br>Olivia Smith<br>39<br>Jackson White<br>61<br>Sophia Lee<br>45<br>Noah Johnson<br>50<br>Ava Brown<br>55<br>Mason Harris<br>48 | 1. Jackson White ate 61 oysters<br>2. Ava Brown ate 55 oysters<br>3. Ethan Miller ate 53 oysters<br>4. Noah Johnson ate 50 oysters<br>5. Mason Harris ate 48 oysters<br>6. Lily Anderson ate 47 oysters<br>7. Sophia Lee ate 45 oysters<br>8. Olivia Smith ate 39 oysters<br>![image](/Assets/sum3_Test3.PNG) | 1. Jackson White ate 61 oysters<br>2. Ava Brown ate 55 oysters<br>3. Ethan Miller ate 53 oysters<br>4. Noah Johnson ate 50 oysters<br>5. Mason Harris ate 48 oysters<br>6. Lily Anderson ate 47 oysters<br>7. Sophia Lee ate 45 oysters<br>8. Olivia Smith ate 39 oysters<br>![image](/Assets/sum3_Test3.PNG)  | PASS          |

## Feedback Request

If there is anything specific you want to ask for feedback on include that here
