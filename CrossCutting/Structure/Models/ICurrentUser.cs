namespace Structure.Models
{
    public interface ICurrentUser
    {
        long Id { get; }

        string Login { get; }

        string FullName { get; }

        string[] Roles { get; }
    }
}
