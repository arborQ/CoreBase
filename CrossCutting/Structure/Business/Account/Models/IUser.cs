namespace Structure.Business.Account.Models
{
    public interface IUser
    {
        long Id { get; }

        string Login { get; }

        string FullName { get; }

        string Email { get; }
    }
}
