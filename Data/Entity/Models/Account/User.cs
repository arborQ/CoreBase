namespace Data.Entity.Models.Account {
    public class User {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }
    }
}