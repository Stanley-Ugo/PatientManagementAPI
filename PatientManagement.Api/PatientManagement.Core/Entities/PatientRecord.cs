namespace PatientManagement.Core.Entities
{
    public class PatientRecord
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public bool IsDeleted { get; set; }
    }
}
