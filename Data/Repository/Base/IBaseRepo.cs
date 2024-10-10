namespace OsonAptekaFastEndpoints.Data.Repository.Base
{
    public interface IBaseRepo
    {
        IStudentRepo StudentRepos { get; }
        Task<bool> Complete();
    }
}
