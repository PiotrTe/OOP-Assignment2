// class to test the functionality of the individual methods
class Test : Main, IValidation
{
    public static void Testing()
    {
        // test the calculate method
        Console.WriteLine("Testing the calculate method with different operators");
        Console.WriteLine("The result of 10 - 10 is: " + Pack.calculate(10, 10, 0));
        Console.WriteLine("The result of 10 + 10 is: " + Pack.calculate(10, 10, 1));
        Console.WriteLine("The result of 10 * 10 is: " + Pack.calculate(10, 10, 2));
        Console.WriteLine("The result of 10 / 10 is: " + Pack.calculate(10, 10, 3));

        // Test every combination of operators in the BODMAS method
        Console.WriteLine("Testing the BODMAS calculate method with every combination of operators");
        Console.WriteLine("The result of 10 - 10 - 10 is: " + Pack.calculate(10,10,10,0,0));
        Console.WriteLine("The result of 10 - 10 + 10 is: " + Pack.calculate(10,10,10,0,1));
        Console.WriteLine("The result of 10 - 10 * 10 is: " + Pack.calculate(10,10,10,0,2));
        Console.WriteLine("The result of 10 - 10 / 10 is: " + Pack.calculate(10,10,10,0,3));
        Console.WriteLine("The result of 10 + 10 - 10 is: " + Pack.calculate(10,10,10,1,0));
        Console.WriteLine("The result of 10 + 10 + 10 is: " + Pack.calculate(10,10,10,1,1));
        Console.WriteLine("The result of 10 + 10 * 10 is: " + Pack.calculate(10,10,10,1,2));
        Console.WriteLine("The result of 10 + 10 / 10 is: " + Pack.calculate(10,10,10,1,3));
        Console.WriteLine("The result of 10 * 10 - 10 is: " + Pack.calculate(10,10,10,2,0));
        Console.WriteLine("The result of 10 * 10 + 10 is: " + Pack.calculate(10,10,10,2,1));
        Console.WriteLine("The result of 10 * 10 * 10 is: " + Pack.calculate(10,10,10,2,2));
        Console.WriteLine("The result of 10 * 10 / 10 is: " + Pack.calculate(10,10,10,2,3));
        Console.WriteLine("The result of 10 / 10 - 10 is: " + Pack.calculate(10,10,10,3,0));
        Console.WriteLine("The result of 10 / 10 + 10 is: " + Pack.calculate(10,10,10,3,1));
        Console.WriteLine("The result of 10 / 10 * 10 is: " + Pack.calculate(10,10,10,3,2));
        Console.WriteLine("The result of 10 / 10 / 10 is: " + Pack.calculate(10,10,10,3,3));

        // Deal 5 cards and display them to the user
        Console.WriteLine("Testing the deal method");
        System.Console.WriteLine("Creating a new pack of cards");
        Pack.Populate();
        System.Console.WriteLine("Dealing 5 cards");
        Pack.deal(5);
        Console.WriteLine("The cards in the hand are:");
        for (int i = 0; i < Pack.hand.Count; i++)
        {
            Console.WriteLine(Pack.hand[i].Rank + " of " + Pack.hand[i].Suit);
        }
        System.Console.WriteLine("Resetting the deck");
        Main.VarReset();
        System.Console.WriteLine("Dealing 5 cards again to show randomisation and the reset function");
        Pack.Populate();
        Pack.deal(5);
        Console.WriteLine("The cards in the hand are:");
        for (int i = 0; i < Pack.hand.Count; i++)
        {
            Console.WriteLine(Pack.hand[i].Rank + " of " + Pack.hand[i].Suit);
        }
        Main.VarReset();

        // Test the validation methods
        Console.WriteLine("Testing the int validation method");
        IValidation.GetIntInput("Please enter a test input");
        System.Console.WriteLine("Value Accepted");
        Console.WriteLine("Testing the range int validation method");
        IValidation.GetIntInput("Please enter a test input", 0, 10);
        System.Console.WriteLine("Value Accepted");
        
        Console.WriteLine("Testing the float validation method");
        IValidation.GetFloatInput("Please enter a test input");
        System.Console.WriteLine("Value Accepted");
        Console.WriteLine("Testing the range float validation method");
        IValidation.GetFloatInput("Please enter a test input", 0, 10);
        System.Console.WriteLine("Value Accepted");

        // Generate 5 tasks and display them to the user
        Console.WriteLine("Testing the task generation method");
        System.Console.WriteLine("Generating 5 tasks");
        for (int i = 0; i < 5; i++)
        {
            Pack.Populate();
            Pack.deal(5);
            Main.GenerateTask();
            Console.WriteLine(Main.taskString);
            Main.VarReset();
        }

        // Test writing to a file
        Console.WriteLine("Testing the file writing method");
        System.Console.WriteLine("Writing a test string to a file");
        Main.WriteToLeaderboard("Test Entry");
        System.Console.WriteLine("Check the Leaderboard.txt file for the entry");

        System.Console.WriteLine("Method testing complete");

        // Test menu method
        Console.WriteLine("Input anything to continue to the main menu");
        Console.ReadLine();
        Main.GameLoop();
    }
}