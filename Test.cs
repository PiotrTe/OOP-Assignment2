class Test : IValidation
{
    static float answer = 0;
    static string taskString = "";

    static int num1 = 0;
    static int num2 = 0;
    static int num3 = 0;
    static int op1 = 0;
    static int op2 = 0;
    public static void TestClass()
    {
        float userInput = 0;

        while (true)
        {
            Reset();
            Menu();
            if (Pack.hand.Count == 0)
            {
                continue;
            }
            
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
            // clear the console window
            Console.Clear();
            System.Console.WriteLine("The answer is: " + answer);
            System.Console.WriteLine("Your task is: " + taskString);

            userInput = IValidation.GetFloatInput("Please enter your answer: ", -10000, 10000);

            if (userInput == answer)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }


    }
    private static void Menu()
    {
        Pack pack = new Pack();
        float tempResult = 0;

        Console.WriteLine("Welcome to the Maths Tutor Application. \nPlease choose one of the following menu options: \n [1] Instructions \n [2] Play ( 3 Cards ) \n [3] Play ( 5 Cards )\n [4] Exit \n");
        string? input = Console.ReadLine();
        switch (input)
        {
            case "1": // Instructions
                Console.WriteLine("\nInstructions: You will be given 3 or 5 cards.\ncards will be represented by numbers and operators.\nYou will be asked to calculate the result of the cards\nand provide it with accuracy of 2 decimal places.\nYour time, amount of tries and current hand will be saved after you win.\n");
                break;

            case "2": // 3 cards
                Pack.deal(3);
                num1 = (int)Pack.hand[0].Rank;
                num2 = (int)Pack.hand[2].Rank;
                op1 = (int)Pack.hand[1].Suit;

                answer = pack.calculate(num1, num2, op1);
                answer = (float)Math.Round(answer, 2);
                break;

            case "3": // 5 cards
                Pack.deal(5);
                num1 = (int)Pack.hand[0].Rank;
                num2 = (int)Pack.hand[2].Rank;
                num3 = (int)Pack.hand[4].Rank;
                op1 = (int)Pack.hand[1].Suit;
                op2 = (int)Pack.hand[3].Suit;

                if (op1 < op2)
                {
                    tempResult = pack.calculate(num2 , num3, op2);
                    answer = pack.calculate(num1, tempResult, op1);
                    answer = (float)Math.Round(answer, 2);
                }
                else
                {
                    tempResult = pack.calculate(num1, num2, op1);
                    answer = pack.calculate(tempResult, num3, op2);
                    answer = (float)Math.Round(answer, 2);
                }
                break;

            case "4": // Exit
                Console.WriteLine("Thank you for playing");
                // wait 2 seconds
                Thread.Sleep(2000);
                // exit the program
                Environment.Exit(0);
                break;

            default:  // Invalid input
                Console.WriteLine("Invalid input");
                break;
        }
    }
    private static void Reset()
    {
        answer = 0;
        taskString = "";
        num1 = 0;
        num2 = 0;
        num3 = 0;
        op1 = 0;
        op2 = 0;
        Pack.hand.Clear();
    }
}