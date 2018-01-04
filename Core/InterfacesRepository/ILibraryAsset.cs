using System.Collections.Generic;
using System.Threading.Tasks;
using SmcLibrary.Core.Models;

namespace SmcLibrary.Core.InterfacesRepository
{
    public interface ILibraryAsset
    {
        IEnumerable<LibraryAsset> GetAll();
        LibraryAsset GetById(int id);

        void AddAsset(LibraryAsset asset);
        string GetAuthorOrDirector(int id);
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetISBN(int id);

        LibraryBranch GetCurrentLocation(int id);

    }
}