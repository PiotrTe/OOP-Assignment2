class Main : IValidation
{
    public static void MainClass()
    {
        Console.WriteLine("Welcome to the Maths Tutor Application. \nPlease choose one of the following menu options: \n [1] Instructions \n [2] Play ( 3 Cards ) \n [3] Play ( 5 Cards )\n [4] Exit \n");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("Instructions: You will be given 3 or 5 cards, cards will represent numbers and operators. You will be asked to calculate the result of the cards. \nYour time and cards will be recorded. \n");
                break;
            case "2":

            case "3":

            case "4":

            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
}