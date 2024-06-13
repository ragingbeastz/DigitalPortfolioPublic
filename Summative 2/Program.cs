/*
 * Students who successfully complete an Honours degree are awarded a degree with a certain classification 
 * which is calculated from the weighted mark for your overall degree. 
 * 
 * The highest classification is First-Class Honours (First or 1st) which is awarded for marks of 70% and above. 
 * The Upper Second-Class Honours (2:1, 2.i) is awarded for marks of 60-70%. 
 * The Lower Second-Class Honours (2:2, 2.ii) is awarded for marks of 50-60%. 
 * The lowest Honours degree is the third class degree (Third or 3rd) which is awarded for marks of 40-50% 
 * All mark ranges are inclusive of their lower bounds, and exclusive of their upper bounds.
 * 
 * Write a program that requests a student's raw marks for the three elements of assessment of the Programming Portfolio module,
 * and calculates the outcome of the module. Raw marks can only be entered as whole numbers. 
 *
*/

Console.WriteLine("Programming Portfolio Results Calculator");

//Variables
int digitalPortfolioMark = 0;
int openBookProgrammingMark = 0;
int capstoneProjectMark = 0;


//Validation of Inputted Marks
//do while loop with boolean "finished" variable denoting the end of the loop. I.e if finished = true the loop ends.

bool finished = false;
do
{
    Console.WriteLine("What was the digital portfolio mark (out of 35)");
    digitalPortfolioMark = int.Parse(Console.ReadLine());

    Console.WriteLine("What was the open book programming exam mark (out of 7)");
    openBookProgrammingMark = int.Parse(Console.ReadLine());

    Console.WriteLine("What was the capstone project mark (out of 100)");
    capstoneProjectMark = int.Parse(Console.ReadLine());

    //Check to see if inputted marks are within range of each assessment
    if (digitalPortfolioMark >= 0 && digitalPortfolioMark <= 35 && openBookProgrammingMark >= 0 && openBookProgrammingMark <= 7 && capstoneProjectMark >= 0 && capstoneProjectMark <= 100)
    {
        finished = true;
    }

    else
    {
        if (digitalPortfolioMark>35 || digitalPortfolioMark < 0)
        {
            Console.WriteLine("Invalid input for Digital Portfolio mark.");
        }

        if (openBookProgrammingMark > 7 || openBookProgrammingMark < 0)
        {
            Console.WriteLine("Invalid input for Open Book Programming mark.");
        }

        if (capstoneProjectMark > 100 || capstoneProjectMark < 0)
        {
            Console.WriteLine("Invalid input for Capstone Project mark.");
        }

    }
    
} while (!finished);


//At this point in the program there are three integer variables digitalPortfolioMark, openBookProgrammingMark, capstoneProjectMark.
//We now begin to perform calculations to get our percentages



//Calculations

//Calculates float for each assesment by ((inputted mark/total mark)*100)
// Gives Percentage Values to two decimal places.
float digitalPortfolioPercentage = (digitalPortfolioMark/35f) * 100;
digitalPortfolioPercentage = (float)Math.Round(digitalPortfolioPercentage,2);

float openBookProgrammingPercentage = (openBookProgrammingMark/7f) * 100;
openBookProgrammingPercentage = (float)Math.Round(openBookProgrammingPercentage, 2);

float capstoneProjectPercentage = (capstoneProjectMark / 100f) * 100;
capstoneProjectPercentage = (float)Math.Round(capstoneProjectPercentage, 2);


//Now we calclate the overall classification by multiplying each mark by it's weighting divided by 100 and then adding the outcomes
// together.
// E.g. if a student was awarded 80% for the digital portfolio, 60% for the open book programming exam and 65% for the capstone project
// their overall module mark would be

// (80 * 50 / 100) + (60 * 25 / 100) + (65 * 25 / 100) = 40 + 15 + 16.25 = 71%

float overallClassificationPercentage = ((digitalPortfolioPercentage * 50f) / 100) + ((openBookProgrammingPercentage * 25f) / 100) + ((capstoneProjectPercentage * 25f) / 100);
overallClassificationPercentage = (float)Math.Round(overallClassificationPercentage, 2);

//If either the capstone or openbook mark percentage is below then the overall percentage is capped at 34 as well.
if (overallClassificationPercentage > 34 && (openBookProgrammingPercentage < 40 || capstoneProjectMark < 40))
{
    overallClassificationPercentage = 34;
}



//Output
//At this stage in the program all the variables are filled. Now we just need to award the degree classification 
// appropriate to the overall percentage and output the correct string.

if  (overallClassificationPercentage >= 0 && overallClassificationPercentage < 40)
{
    Console.WriteLine(string.Format("{0}% - Fail", overallClassificationPercentage));
}

else if (overallClassificationPercentage >= 40 && overallClassificationPercentage < 50)
{
    Console.WriteLine(string.Format("{0}% - 3rd", overallClassificationPercentage));
}

else if (overallClassificationPercentage >= 50 && overallClassificationPercentage < 60)
{
    Console.WriteLine(string.Format("{0}% - Lower Second 2:2", overallClassificationPercentage));
}

else if (overallClassificationPercentage >= 60 && overallClassificationPercentage < 70)
{
    Console.WriteLine(string.Format("{0}% - Upper Second 2:1", overallClassificationPercentage));
}

else if (overallClassificationPercentage >= 70)
{
    Console.WriteLine(string.Format("{0}% - 1st", overallClassificationPercentage));
}


