namespace Structure.Models
{
    public interface ICurrentUser
    {
        long Id { get; }

        string Login { get; }

        string FullName { get; }

        string Email { get; }

        string[] Roles { get; }
    }
}
