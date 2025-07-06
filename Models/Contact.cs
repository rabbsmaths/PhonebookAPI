namespace PhonebookAPI.Models
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}
