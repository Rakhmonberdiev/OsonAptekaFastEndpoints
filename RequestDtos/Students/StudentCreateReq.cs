namespace OsonAptekaFastEndpoints.RequestDtos.Students
{
    public class StudentCreateReq
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ClassId { get; set; }
    }
}
