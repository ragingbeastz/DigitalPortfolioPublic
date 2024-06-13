using Summative_7;


Console.WriteLine("Hello, Mini Heroes Quest!");
Console.WriteLine();


// Here we create some instances of characters
Ranger ranger = new Ranger("John");
Barbarian barbarian = new Barbarian("Susan");
Mage mage = new Mage("Richard");
Warrior warrior = new Warrior("Samuel");



// This is how this should be used
Console.WriteLine("Original Values");
Console.WriteLine($"{barbarian.HealthPoints}");
Console.WriteLine(ranger.EnergyPoints);
Console.WriteLine();

ranger.FireArrows(barbarian);
Console.WriteLine();

Console.WriteLine("Changed Values");
Console.WriteLine($"{barbarian.HealthPoints}");
Console.WriteLine(ranger.EnergyPoints);
Console.WriteLine();

barbarian.SwingAxe(ranger);
mage.Resurrect(ranger);
mage.Heal(mage);
ranger.CollectArrows();
ranger.FireArrows(barbarian);
mage.Heal(ranger);

warrior.SwingSword(mage);
warrior.ShieldBlock(ranger);


/*
// This is undesirable behaviour that we want to stop happening
barbarian.FireArrows(mage);
mage.SwingAxe(barbarian);
mage.ChangeCharacterHealth(mage,20000);
*/

