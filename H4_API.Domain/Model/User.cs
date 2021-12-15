using System.ComponentModel.DataAnnotations;
using H4_API.Core;

namespace H4_API.Domain.Model
{
    public class User : Entity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}