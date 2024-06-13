using System;

namespace myNamespace
    {
        class myClass
        {
            static void Main()
            {
                Console.WriteLine("Welcome to the magnificent gradertron!");
                Console.WriteLine("Please enter a grade between 0 and 100");
                int grade = 0;
                string gradeString = Console.ReadLine();
                try
                {
                    grade = int.Parse(gradeString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Input - Program will now exit");
                    return;
                }

                if (grade < 0)
                {
                    Console.WriteLine("You cannot have a grade of less than 0");
                }
                else if (grade < 40)
                {
                    Console.WriteLine("I'm afraid you failed");
                }
                else if (grade < 50)
                {
                    Console.WriteLine("You have been awarded a 3rd class mark");
                }
                else if (grade < 60)
                {
                    Console.WriteLine("You have been awareded a lower 2nd class mark");
                }
                else if (grade <= 70)
                {
                    Console.WriteLine("You have been awarded a upper 2nd class mark");
                }
                else
                {
                    Console.WriteLine("You have been awarded a first class mark");
                }
            }
        }
    }
	
