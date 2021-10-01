using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Pessoa
    {
       [Key]

       public int Id { get; set; }
       public string Name { get; set; }
       public string City { get; set; }
       public int Age { get; set; }
       
   
        
    }
}