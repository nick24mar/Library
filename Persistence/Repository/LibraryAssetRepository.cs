using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmcLibrary.Core.InterfacesRepository;
using SmcLibrary.Core.Models;

namespace SmcLibrary.Persistence.Repository
{
    public class LibraryAssetRepository : ILibraryAsset
    {
        private readonly LibraryDataContext context;

        public LibraryAssetRepository(LibraryDataContext context)
        {
            this.context = context;
        }

        public void AddAsset(LibraryAsset asset)
        {
            context.Add(asset);
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location)
                .ToList();
        }

        public LibraryAsset GetById(int id)
        {
            return GetAll().SingleOrDefault(asset => asset.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (findBookById(id))
                return GetBooksProperty(id).DeweyIndex;

            else return "";
        }

        public string GetISBN(int id)
        {
            if (findBookById(id))
                return GetBooksProperty(id).ISBN;

            else return "";
        }

        public string GetTitle(int id)
        {
            if (findBookById(id))
                return GetBooksProperty(id).Title;

            else return "";
        }

        public string GetType(int id)
        {
            var book = context.LibraryAssets.OfType<Book>()
                .Where(b => b.Id == id);

            return book.Any() ? "Book" : "Video";
        }
        public string GetAuthorOrDirector(int id)
        {
            var isBook = context.LibraryAssets.OfType<Book>()
                .Where(asset => asset.Id == id).Any();

            var isVideo = context.LibraryAssets.OfType<Video>()
                .Where(asset => asset.Id == id).Any();

            return isBook ? 
                context.Books.SingleOrDefault(b => b.Id == id).Author :
                context.Videos.SingleOrDefault(v => v.Id == id).Director
                ?? "Uknown";
        }

        private Book GetBooksProperty(int id)
        {
           return context.Books.SingleOrDefault(book => book.Id == id);
        }

        private bool findBookById(int id)
        {
            return context.Books.Any(book => book.Id == id);
        }
    }
}