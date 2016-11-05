using XParkMinder.Domain.Library.Entities;

namespace XParkMinder.Domain.Library.Contracts
{
    public interface IUnitOfWork
    {

        void SaveChanges();

        void RollBackChanges();
    }
}