using System.Data.Entity;
using DomainModel;

namespace XrmTestTask.DataAccessApi
{
    public interface IUnitOfWork
    {
        IDbSet<Resume> Resumes { get; }
        void Commit();
    }
}
