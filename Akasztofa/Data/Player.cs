namespace Data
{
    public class Player
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Difficulty Difficulty { get; set; }
        public TimeSpan SolutionTime { get; set; }
    }
}
