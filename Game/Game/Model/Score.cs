namespace Game.Model
{
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