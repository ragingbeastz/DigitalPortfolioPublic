# Summative 1

## Challenge Description

Calculating the Cost of a car hire using given charges. 
These included £25 per day hired, £2.50 per litre of fuel used and a £10 booking fee. 
The program asked the user for the duration of hire and fuel usage of their car after a hire

## Code Listing

```cs
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
```

## Test Plan

| **Test Number** | **Input**      | **Expected Output**                         | **Actual Output**                           | **Pass/Fail** |
|-----------------|----------------|---------------------------------------------|---------------------------------------------|---------------|
| 1               | "0", "50"      | "The total cost for the car hire is £10"    | "The total cost for the car hire is £10"    | PASS          |
| 2               | "1", "50"      | "The total cost for the car hire is £35"    | "The total cost for the car hire is £35"    | PASS          |
| 3               | "0", "49"      | "The total cost for the car hire is £12.5"  | "The total cost for the car hire is £12.5"  | PASS          |
| 4               | "1", "30"      | "The total cost for the car hire is £85"    | "The total cost for the car hire is £85"    | PASS          |
| 5               | "3", "50"      | "The total cost for the car hire is £85"    | "The total cost for the car hire is £85"    | PASS          |
| 6               | "2", "15"      | "The total cost for the car hire is £147.5" | "The total cost for the car hire is £147.5" | PASS          |
| 7               | "5", "20"      | "The total cost for the car hire is £210"   | "The total cost for the car hire is £210"   | PASS          |
| 8               | "cheeseburger" | Program crashes - unhandled exception       | Program crashes - unhandled exception       | PASS          |



## Feedback Request
How would one handle converting for example £2.5 to £2.50? Does my commenting look sufficient?
