using System.Collections.Generic;
using System.Threading.Tasks;
using testApi2.Model;

namespace testApi2.Data
{
    public interface IAuthorService
    {
        Task<IList<Author>> GetAuthorsAsync();
        Task<Author> AddAuthorAsync(Author author);
        
    }
}