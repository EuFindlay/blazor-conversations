using System.ComponentModel.DataAnnotations;

namespace client.Models
{
    public class LoginModel 
    {
        [Required]
        public string Name {get;set;}
    }
}