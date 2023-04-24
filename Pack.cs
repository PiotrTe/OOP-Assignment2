public enum Suit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades   
}

public enum Rank
{
    Ace = 1,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}
class Pack : IValidation
{
    // List of cards in the pack and the current hand
    public static List<Card> pack = new List<Card>();
    public static List<Card> hand = new List<Card>();

    // Constructor for creating a new pack of cards
    public Pack()
    {
        // Loop through each rank and suit to create a new card of each combination
        foreach (Rank rank in Enum.GetValues(typeof(Rank)))
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                pack.Add(new Card(rank, suit));
            }
        }
    }

    // Method for shuffling the pack of cards


    public static void shuffleCardPack(List<Card> pack)
    {
        Random rng = new Random();
        int n = pack.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card temp = pack[k];
            pack[k] = pack[n];
            pack[n] = temp;
        }
    }

    public float calculate(float num1, float num2, string op)
    {
        float result = 0;
        switch (op)
        {
            case "+":
                result = (num1 + num2);
                break;
            case "-":
                result = (num1 - num2);
                break;
            case "*":
                result = (num1 * num2);
                break;
            case "/":
                result = (num1 / num2);
                break;
            default:
                Console.WriteLine("Invalid operator");
                break;
        }
        return result;
    }

    // Methods for dealing one card from the pack to the hand

    // function to deal a specified number of cards to the player
    public static void deal3()
    {
        if (pack.Count <= 0) // check if there are any cards left in the deck
        {
            Console.WriteLine("There are no more cards in the deck");
        }
        else
        {
            hand.Add(pack[0]); 
            pack.RemoveAt(0); 
        }
    }
}

