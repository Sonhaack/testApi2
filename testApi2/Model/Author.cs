using System.ComponentModel.DataAnnotations;

namespace testApi2.Model
{
    public class Author
    {
        [Key]
        public int Id {get; set; }
        
        [Required, MaxLength(15)]
        public string FirstName {get; set; }
        
        [Required, MaxLength(15)]
        public string LastName {get; set; }
       
    }
}