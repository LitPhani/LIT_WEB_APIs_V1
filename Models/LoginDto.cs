using System.ComponentModel.DataAnnotations;

namespace LIT_WEB_APIs_V1.Models
{
    public class LoginDto
    {
        [Required]
        public string sEmailID { get; set; }
        [Required]
        public string sPassword { get; set; }
    }
}
