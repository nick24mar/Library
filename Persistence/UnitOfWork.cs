using System.Threading.Tasks;
using SmcLibrary.Core;

namespace SmcLibrary.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDataContext context;
        public UnitOfWork(LibraryDataContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}