using Structure.Business.Account.Models;

namespace Account.Dtos
{
    internal class UserDto : IUser
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
