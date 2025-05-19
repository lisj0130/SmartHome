namespace Backend.Models
{
    public class Log
    {
        public int LogID { get; set; } // PK
        public double InsideTemp { get; set; }
        public double OutsideTemp { get; set; }
        public List<string> LightsOn { get; set; } = new List<string>();
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
