using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Models.Account
{
    [Table("User", Schema = "Account")]
    public class User
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        public bool IsActive { get; set; }
    }
}