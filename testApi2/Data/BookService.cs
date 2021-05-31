using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using testApi2.Model;

namespace testApi2.Data
{
    public class BookService : IBookService
    {
        private string bookFile = "books.json";
        private IList<Book> books;

        public BookService()
        {
            if (!File.Exists(bookFile))
            {
                string productAsJson = JsonSerializer.Serialize(books);
                File.WriteAllText(bookFile, productAsJson);
            }
            else
            {
                string content = File.ReadAllText(bookFile);
                books = JsonSerializer.Deserialize<List<Book>>(content);
            }
        }

        public async Task<IList<Book>> GetBookAsync()
        {
            List<Book> tmp = new List<Book>(books);
            return tmp;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            books.Add(book);
            string productsAsJson = JsonSerializer.Serialize(books);
            File.WriteAllText(bookFile, productsAsJson);
            return book;
        }

        // public async Task<Book> DeleteBookAsync(int ISBN)
        // {
        //     books.IndexOf(ISBN)
        //     string productsAsJson = JsonSerializer.Serialize(books);
        //     File.WriteAllText(bookFile, productsAsJson);
        //     return book;
        // }
    }
}