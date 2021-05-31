using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorBlazor.Model;

namespace AuthorBlazor.Data
{
    public interface IBookService
    {
        Task<IList<Book>> GetBookAsync();

        Task<Book> AddBookAsync(Book book);

        // Task<Book> DeleteBookAsync(int ISBN);
    }
}