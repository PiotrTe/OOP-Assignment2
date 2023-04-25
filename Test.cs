using System.Diagnostics;
class Test : IValidation
{
    public static string alert = "";
    static float answer = 0;
    static string taskString = "";
    static int num1 = 0;
    static int num2 = 0;
    static int num3 = 0;
    static int op1 = 0;
    static int op2 = 0;
    static Pack pack = new Pack();
    public static void TestClass()
    {
        string leaderboard = "Leaderboard.txt";
        if (!File.Exists(leaderboard))
        {
            using (StreamWriter writer = new StreamWriter(leaderboard))
            {
                writer.WriteLine("This is an example.");
            }
        }
        float userInput = 0;
        int tries = 0;
        Stopwatch sw = new Stopwatch();
        while (true)
        {
            Pack.Populate();
            Menu();
            foreach (Card card in Pack.hand)
            {
                if (Pack.hand.IndexOf(card) % 2 == 1)
                {
                    if ((int)card.Suit == 0)
                    {
                        taskString += " - ";
                    }
                    if ((int)card.Suit == 1)
                    {
                        taskString += " + ";
                    }
                    if ((int)card.Suit == 2)
                    {
                        taskString += " * ";
                    }
                    if ((int)card.Suit == 3)
                    {
                        taskString += " / ";
                    } 
                }
                else
                {
                    taskString += (int)card.Rank;
                }                
            }
            if (Pack.hand.Count == 0)
            {
                continue;
            }
            // clear the console window
            Console.Clear();
            System.Console.WriteLine("The answer is: " + answer);
            System.Console.WriteLine("Your task is: " + taskString);
            sw.Restart();

            while(true)
            {
                // get user input
                userInput = IValidation.GetFloatInput("Please enter your answer: ", -10000, 10000);

                if (userInput == answer) // if user input is correct
                {
                    tries++;
                    sw.Stop();
                    Console.WriteLine("Correct");
                    string scoreString = $"Hand: {taskString} | Time: {sw.Elapsed} | Tries: {tries}";
                    System.IO.File.AppendAllText(Leaderboard, scoreString + Environment.NewLine);
                    alert = scoreString;
                    tries = 0;
                    sw.Reset();
                    VarReset();
                    break;
                }
                else
                {
                    tries++;
                    Console.WriteLine("Incorrect");
                }
            }
        }


    }
    // method for resetting the game
    private static void Menu()
    {
        float tempResult = 0;
        Console.Clear();
        Console.WriteLine("\nWelcome to the Maths Tutor Application.\n\nPlease choose one of the following menu options: \n\n [1] Instructions \n [2] Play ( 3 Cards ) \n [3] Play ( 5 Cards ) \n [4] Exit \n");
        if (alert != "") System.Console.WriteLine($"{alert}");
        alert = "";
        string? input = Console.ReadLine();
        switch (input)
        {
            case "1": // Instructions
                alert = ("\nInstructions: You will be given 3 or 5 cards.\ncards will be represented by numbers and operators.\nYou will be asked to calculate the result of the cards\nand provide it with accuracy of 2 decimal places.\nYour time, amount of tries and current hand will be saved after you win.\n");
                break;

            case "2": // 3 cards
                Pack.deal(3);
                num1 = (int)Pack.hand[0].Rank;
                num2 = (int)Pack.hand[2].Rank;
                op1 = (int)Pack.hand[1].Suit;

                answer = Pack.calculate(num1, num2, op1);
                answer = (float)Math.Round(answer, 2);
                break;

            case "3": // 5 cards
                Pack.deal(5);
                num1 = (int)Pack.hand[0].Rank;
                num2 = (int)Pack.hand[2].Rank;
                num3 = (int)Pack.hand[4].Rank;
                op1 = (int)Pack.hand[1].Suit;
                op2 = (int)Pack.hand[3].Suit;

                if (op1 < op2) // if first operator is lower than second operator
                {
                    tempResult = Pack.calculate(num2 , num3, op2); // calculate the first BODMAS step result
                    answer = Pack.calculate(num1, tempResult, op1); // calculate the result of the whole equation
                    answer = (float)Math.Round(answer, 2);
                }
                else // swap the order of calculations
                {
                    tempResult = Pack.calculate(num1, num2, op1);
                    answer = Pack.calculate(tempResult, num3, op2);
                    answer = (float)Math.Round(answer, 2);
                }
                break;

            case "4": // Exit
                Console.Clear();
                Console.WriteLine("\nThank you for playing");
                // wait 2 seconds
                Thread.Sleep(2000);
                // exit the program
                Environment.Exit(0);
                break;

            default:  // Invalid input
                alert = "!!!   Invalid input   !!!";
                break;
        }
    }
    // Reset all variables
    private static void VarReset()
    {
        taskString = "";
        answer = 0;
        num1 = 0;
        num2 = 0;
        num3 = 0;
        op1 = 0;
        op2 = 0;
        Pack.hand.Clear();
        Pack.pack.Clear();
    }
}