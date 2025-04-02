namespace Data
{
    internal class Player
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Difficulty difficulty { get; set; }
        public TimeSpan SolutionTime { get; set; }
    }
}
