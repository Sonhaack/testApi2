using System.Collections.Generic;
using System.Threading.Tasks;
using Authorblazer.Model;


namespace Authorblazer.Data
{
    public interface IBookService
    {
        Task<IList<Book>> GetBookAsync();

        Task<Book> AddBookAsync(Book book);

        // Task<Book> DeleteBookAsync(int ISBN);
    }
}