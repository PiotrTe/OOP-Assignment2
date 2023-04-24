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

        shuffleCardPack();
    }

    // Method for shuffling the pack of cards


    private void shuffleCardPack()
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

    public float calculate(float num1, float num2, int op)
    {
        float result = 0;
        switch (op)
        {
            case 0:
                result = (num1 - num2);
                break;
            case 1:
                result = (num1 + num2);
                break;
            case 2:
                result = (num1 * num2);
                break;
            case 3:
                result = (num1 / num2);
                break;
            default:
                Console.WriteLine("Invalid operator");
                break;
        }
        return result;
    }

    // function to deal a number of cards from the pack to the hand
    public static void deal(int numCards)
    {
        for (int i = 0; i < numCards; i++)
        {
            if (pack.Count <= 0) // check if there are any cards left in the deck
            {
                Console.WriteLine("There are no more cards in the deck");
                break;
            }
            else
            {
                hand.Add(pack[0]); 
                pack.RemoveAt(0); 
            }
        }
    }
}

