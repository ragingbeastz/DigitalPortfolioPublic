/* This time you're going to calculate the cost to hire a car.
 * When a customer hires the car is has a full tank of petrol. The tank holds 50 litres of fuel.
 * The car hire cost is £25 per day hired, plus £2.50 per litre of petrol used and a £10 booking fee.
 * Your program should ask the user how many days the car was hired for, then how many litres of fuel were left in the tank when it was returned.
*/



Console.WriteLine("Car Hire Charge Calculator");


//Inputs - "how many days the car was hired for, then how many litres of fuel were left in the tank when it was returned"

Console.WriteLine("Please enter the duration of the car hire in days:");
float carDurationDays = float.Parse(Console.ReadLine());

Console.WriteLine("Please enter the volume of fuel in car when it was returned:");
float fuelAmountLitres = float.Parse(Console.ReadLine());



//Calculation - "£25 per day hired, plus £2.50 per litre of petrol used and a £10 booking fee."

float durationCostFloat = carDurationDays * 25;
float petrolCostFloat = 2.5f * (50 - fuelAmountLitres);

//Total Cost
float totalCostFloat = 10 + durationCostFloat + petrolCostFloat;



//Ouput
Console.WriteLine("The total cost for the car hire is £" + totalCostFloat);