namespace GoWHunter.World
{
    public class DropRateResultItem
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public int Id { get; set; }
        public string ReferenceName { get; set; }
        public double ChanceInAll { get; set; }
        public double ChanceInSameCategory { get; set; }
        public string Category { get; set; }
        public double ExpectationInAll { get; set; }
        public double ExpectationInSameCategory { get; set; }
        public int Stars { get; set; }
        
    }
}