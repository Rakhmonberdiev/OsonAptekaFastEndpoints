namespace OsonAptekaFastEndpoints.Data.Repository.Base
{
    public interface IBaseRepo
    {
        IStudentRepo StudentRepos { get; }
        IClassRepo ClassRepos { get; }
        Task<bool> Complete();
    }
}
