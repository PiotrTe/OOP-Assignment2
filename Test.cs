class Test : IValidation
{
    public static void TestClass()
    {
        float answer = 0;
        string taskString = "";
        int op1 = 0;
        int op2 = 0;
        Pack pack = new Pack();
        
        Console.WriteLine("Welcome to the Maths Tutor Application. \nPlease choose one of the following menu options: \n [1] Instructions \n [2] Play ( 3 Cards ) \n [3] Play ( 5 Cards )\n [4] Exit \n");
        string? input = Console.ReadLine();
        switch (input)
        {
            case "1": // Instructions
                Console.WriteLine("Instructions: You will be given 3 or 5 cards, cards will represent numbers and operators. \nYou will be asked to calculate the result of the cards. \nYour time and cards will be recorded. \n");
                break;

            case "2": // 3 cards
                Pack.deal(3);
                answer = pack.calculate((float)Pack.hand[0].Rank, (float)Pack.hand[2].Rank, (int)Pack.hand[1].Suit);
                break;

            case "3": // 5 cards
                Pack.deal(5);
                op1 = (int)Pack.hand[1].Suit;
                op2 = (int)Pack.hand[3].Suit;
                // swap the order of the operators depending on the order of the operators according to the BODMAS rule
                if (op1 < op2)
                {
                    Card temp = Pack.hand[1];
                    Pack.hand[1] = Pack.hand[3];
                    Pack.hand[3] = temp;
                }

                answer = pack.calculate(pack.calculate((float)Pack.hand[0].Rank, (float)Pack.hand[2].Rank, (int)Pack.hand[1].Suit), (float)Pack.hand[4].Rank, (int)Pack.hand[3].Suit);
                break;

            case "4": // Exit
                Console.WriteLine("Thank you for playing");
                break;

            default:  // Invalid input
                Console.WriteLine("Invalid input");
                break;
        }
        System.Console.WriteLine("The answer is: " + answer);
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
        System.Console.WriteLine("Your task is: " + taskString);
    }
}