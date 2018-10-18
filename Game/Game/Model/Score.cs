namespace Game.Model
{
    /// <summary>
    /// Handles and saves player score
    /// </summary>
    internal class Score
    {
        public string Name;
        public int PlayerScore;

        public Score(string n, int s)
        {
            Name = n;
            PlayerScore = s;
        }
    }
}