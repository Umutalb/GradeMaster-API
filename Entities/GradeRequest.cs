namespace GradeMaster_API.Entities
{
    public class GradeRequest
    {
        public double Midterm { get; set; }
        public double Final { get; set; }
        public float MidtermWeight { get; set; } = 0.4f;
        public float FinalWeight { get; set; } = 0.6f;
        public double PassingGrade { get; set; } = 45;
    }
}
