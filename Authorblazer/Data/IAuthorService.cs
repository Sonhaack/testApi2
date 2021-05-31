using System.Collections.Generic;
using System.Threading.Tasks;
using Authorblazer.Model;

namespace Authorblazer.Data
{
    public interface IAuthorService
    {
        Task<IList<Author>> GetAuthorsAsync();
        Task AddAuthorAsync(Author author);
    }
}