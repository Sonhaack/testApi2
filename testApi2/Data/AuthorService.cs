using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using testApi2.Model;

namespace testApi2.Data
{
    public class AuthorService : IAuthorService
    {
        private string authorFile = "authors.json";
        private IList<Author> _authors;

        public AuthorService()
        {
            if (!File.Exists(authorFile))
            {
                string productAsJson = JsonSerializer.Serialize(_authors);

                File.WriteAllText(authorFile, productAsJson);
                
            }
            else
            {
                string content = File.ReadAllText(authorFile);
                _authors = JsonSerializer.Deserialize<List<Author>>(content);
            }
        }

        public async Task<IList<Author>> GetAuthorsAsync()
        {
            List<Author> tmp = new List<Author>(_authors);
            return tmp;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            int max = _authors.Max(author => author.Id);
            author.Id = (++max);
            _authors.Add(author);
            string productAsJson = JsonSerializer.Serialize(_authors);
            File.WriteAllText(authorFile, productAsJson);
            return author;

        }

        
    }
}