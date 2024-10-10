namespace OsonAptekaFastEndpoints.RequestDtos.Students
{
    public class StudentUpdateReq
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ClassId { get; set; }
    }
}
