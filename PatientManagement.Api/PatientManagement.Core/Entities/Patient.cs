namespace PatientManagement.Core.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
        public List<PatientRecord> Records { get; set; } = new();
    }
}
