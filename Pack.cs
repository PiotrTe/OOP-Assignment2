public enum Suit
{
    Addition = "+",
    Subtraction = "-",
    Multiplication = "*",
    
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
    public static bool shuffleCardPack()
    {
        // Ask the user to choose a shuffling method
        int shuffleType = IValidation.GetIntInput($"Choose shuffling method:\n" +
            $"[1] Fisher Yates shuffle\n" +
            $"[2] Riffle shuffle\n" +
            $"[3] No shuffle\n", 1, 3);

        // Perform the selected shuffling method
        if (shuffleType == 1) // Fisher Yates shuffle
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
            return true;
        }
        if (shuffleType == 2) // Riffle shuffle
        {
            for (int i = 0; i < 5; i++)
            {
                Random rng = new Random();
                int n = pack.Count / 2;
                List<Card> left = new List<Card>(pack.GetRange(0, n));
                List<Card> right = new List<Card>(pack.GetRange(n, n));
                pack.Clear();
                while (left.Count > 0 && right.Count > 0)
                {
                    if (rng.NextDouble() < 0.5)
                    {
                        pack.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        pack.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                pack.AddRange(left);
                pack.AddRange(right);
            }
            return true;
        }
        if (shuffleType == 3) // No shuffle
        {
            return false;
            // Do nothing
        }
        return false;
    }

    // Methods for dealing one card from the pack to the hand

    // function to deal one card to the player
    public static Card deal()
    {
        if (pack.Count <= 0) // check if there are any cards left in the deck
        {
            Console.WriteLine("There are no more cards in the deck");
        }
        else
        {
            hand.Add(pack[0]); // add the top card from the deck to the player's hand
            pack.RemoveAt(0); // remove the card from the deck
        }
        return pack[0];
    }

    // function to deal a specified number of cards to the player
    public static List<Card> dealCard(int amount)
    {
        List<Card> temp = new List<Card>();

        for (int i = 0; i < amount; i++)
        {
            if (pack.Count <= 0) // check if there are any cards left in the deck
            {
                Console.WriteLine("There are no more cards in the deck");
                break;
            }
            else
            {
                temp.Add(pack[0]);
                hand.Add(pack[0]); // add the top card from the deck to the player's hand
                pack.RemoveAt(0); // remove the card from the deck
            }
        }
        return temp;
    }
}

