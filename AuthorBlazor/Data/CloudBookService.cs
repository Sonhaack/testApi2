using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AuthorBlazor.Model;

namespace AuthorBlazor.Data
{
    public class CloudBookService : IBookService
    {
        private HttpClient client;

        public CloudBookService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Book>> GetBookAsync()
        {
            string message = await client.GetStringAsync("https://localhost:5003/books");
            List<Book> result = JsonSerializer.Deserialize<List<Book>>(message);
            return result;
        }

        public async Task AddBookAsync(Book book)
        {
            string todoSerialized = JsonSerializer.Serialize(book);
            StringContent content = new StringContent(
                todoSerialized,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:5003/books", content);
            
        }
    }
}