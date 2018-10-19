namespace Game.Model
{
    /// <summary>
    /// Handles and saves player score
    /// </summary>
    internal class Score
    {
        public string Name;
        public int PlayerScore;

        /// <summary>
        /// Creates a new sore
        /// </summary>
        /// <param name="n">Player name</param>
        /// <param name="s">Player score</param>
        public Score(string n, int s)
        {
            Name = n;
            PlayerScore = s;
        }
    }
}