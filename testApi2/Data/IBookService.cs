using System.Collections.Generic;
using System.Threading.Tasks;
using testApi2.Model;

namespace testApi2.Data
{
    public interface IBookService
    {
        Task<IList<Book>> GetBookAsync();

        Task<Book> AddBookAsync(Book book);

        // Task<Book> DeleteBookAsync(int ISBN);
    }
}