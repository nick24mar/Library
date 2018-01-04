using System.Threading.Tasks;

namespace SmcLibrary.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}