namespace GradeMaster_API.Entities
{
    public class GradeResponse
    {
        public double Average { get; set; }
        public bool Status { get; set; }
        public double RequiredFinal { get; set; }
        public string Comment { get; set; } = null!;
    }
}
