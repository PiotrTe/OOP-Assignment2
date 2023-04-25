class Card
{
    // Define two properties: Suit and Rank
    public Suit Suit { get; set; }
    public Rank Rank { get; set; }

    // Define a constructor for the Card class that takes a Rank and a Suit as parameters
    public Card(Rank rank, Suit suit)
    {
        // Assign the passed-in Rank and Suit values to the Suit and Rank properties of the Card instance

        // basic error handling before assigning the values
        
        if (Enum.IsDefined(typeof(Suit), suit))
        {
            Suit = suit;
        }
        else
        {
            throw new ArgumentException("Invalid Suit", "suit");
        }
        if (Enum.IsDefined(typeof(Rank), rank))
        {
            Rank = rank;
        }
        else
        {
            throw new ArgumentException("Invalid Rank", "rank");
        }

    }
}