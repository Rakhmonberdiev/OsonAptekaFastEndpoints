namespace OsonAptekaFastEndpoints.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
