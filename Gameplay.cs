class Gameplay
{
    // Fields
    protected static string alert = "";
    protected static float answer = 0;
    protected static  string taskString = "";
    protected static int num1 = 0;
    protected static int num2 = 0;
    protected static int num3 = 0;
    protected static int op1 = 0;
    protected static int op2 = 0;
    protected static Pack pack = new Pack();
    protected string leaderboard = "Leaderboard.txt";
    
    // Methods
    public virtual void GameLoop()
    {

    }
    public virtual void Menu()
    {

    }
    public virtual void GenerateTask()
    {

    }
    public virtual void WriteToLeaderboard(string text)
    {

    }

}