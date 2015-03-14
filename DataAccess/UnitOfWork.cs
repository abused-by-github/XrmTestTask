using System.Data.Entity;
using DomainModel;
using XrmTestTask.DataAccessApi;

namespace XrmTestTask.DataAccess
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public IDbSet<Resume> Resumes { get; private set; }

        public UnitOfWork() : base("DefaultConnection")
        {
            Resumes = Set<Resume>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resume>();
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
