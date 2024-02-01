/* Dice Roller Lab
 * Mattalynn Darden
 * GC C# 
 * 1/31/2024 */

//Declaring and Initializing Variables w/ default values
int userInput = 0;
string sixSidedDiceOutput1 = "default";
string sixsidedDiceOutput2 = "default";
string tenSidedDiceOutput = "default";

Console.WriteLine("Enter the number of sides for a pair of dice");

//Exception handling
try
{
    userInput = int.Parse(Console.ReadLine());
}
catch(FormatException)
{
    Console.WriteLine("You didn't enter a valid number.");
}

Console.WriteLine("Are you ready to roll the dice? (y / n)");
string userDecision = Console.ReadLine();
if (userDecision.ToLower().Trim() == "y")
{
    do
    {
        int diceRoll1 = GenerateRandomNumber(userInput);
        int diceRoll2 = GenerateRandomNumber(userInput);

        //“Rolls” two n-sided dice, displaying the results of each along with a total
        Console.WriteLine($"The first dice rolled a {diceRoll1}. The second dice rolled a {diceRoll2}.");
        Console.WriteLine($"The sum of your dice roll is {diceRoll2 + diceRoll1}");

        //6 sided dice
        if (userInput == 6)
        {
            sixSidedDiceOutput1 = SixSidedDice(diceRoll1, diceRoll2);
            sixsidedDiceOutput2 = SixSidedDice2(diceRoll1, diceRoll2);

            if (sixSidedDiceOutput1 != "")
            {
                Console.WriteLine(sixSidedDiceOutput1);
            }
            else { }
            if (sixsidedDiceOutput2 != "")
            {
                Console.WriteLine(sixsidedDiceOutput2); 
            }
        }
        //10 sided dice; Xtra credit
        else if (userInput == 10)
        {
            tenSidedDiceOutput = TenSidedDice(diceRoll1, diceRoll2);

            if (tenSidedDiceOutput != "")
            {
                Console.WriteLine(tenSidedDiceOutput);
            }
        }
        else { }

        //Ask the user if they want to roll the dice again
        Console.WriteLine("Do you want to roll the dice again? (y / n)");
        userDecision = Console.ReadLine();
    }
    while (userDecision.ToLower().Trim() == "y");

    Console.WriteLine("You're a coward. Goodbye!");
}
else
{
    Console.WriteLine("You're a coward. Goodbye!");
}

//Static method to generate random numbers w/ in user specified range
static int GenerateRandomNumber (int userInput)
{
    Random random = new Random();
    int randomNumber = random.Next(1,userInput++);
    return randomNumber;
}

/* static method for six-sided dice that takes two dice values as parameters, and returns a string for one of the valid combinations (e.g. Snake Eyes, etc.) 
 * or an empty string if the dice don’t match one of the combination */
 static string SixSidedDice (int diceValue1,  int diceValue2)
{
    string returnValue = "default";
    if ((diceValue1  == 1) && (diceValue2 == 1))
    {
        returnValue = "Snake Eyes";
    }
    else if ((diceValue1 == 1) & (diceValue2 == 2) | (diceValue1 == 2) & (diceValue2 == 1))
    {
        returnValue = "Ace Due";
    }
    else if ((diceValue1 & diceValue2) == 6)
    {
        returnValue = "Box Cars";
    }
    else
    {
        returnValue = "";
    }
        return returnValue;
}

/* Create a static method for six-sided dice that takes two dice values as parameters, 
 * and returns a string for one of the valid totals (e.g. Win, etc.) or an empty string if the dice don’t match one of the totals. */
static string SixSidedDice2(int diceValue1, int diceValue2)
{
    string returnValue = "default";
    if (((diceValue1 + diceValue2) == 7) | ((diceValue1 + diceValue2) == 11))
    {
        returnValue = "Win";
    }
    else if (((diceValue1 + diceValue2) == 2) | ((diceValue1 + diceValue2) == 3) | ((diceValue1 + diceValue2) == 12))
    {
        returnValue = "Craps";
    }
    else
    {
        returnValue = "";
    }
    return returnValue;
}

//Extra credit
static string TenSidedDice(int diceValue1, int diceValue2)
{
    string returnValue = "default";
    if (((diceValue1 + diceValue2) == 20) | ((diceValue1 + diceValue2) == 10))
    {
        returnValue = "Win!!";
    }
    else if (diceValue1 == diceValue2)
    {
        returnValue = "Doubles!!";
    }
    else
    {
        returnValue = "";
    }
    return returnValue;
}