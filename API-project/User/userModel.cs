using System.ComponentModel.DataAnnotations;

namespace UserModel
{
        public class User
        {
            public int UserId { get; set; }
            [EmailAddress]
            [Required]
            public string? Gmail { get; set; }
            [StringLength(10, ErrorMessage = ("name length cant be more than 10."))]
            public string? UserFirstName { get; set; }
            [StringLength(10, ErrorMessage = "name length cant be more than 10.")]
            public string? Userlastname { get; set; }
            [Required]
            public string? Password { get; set; }

        
    }
}
