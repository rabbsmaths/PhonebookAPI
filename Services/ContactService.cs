using PhonebookAPI.Interfaces;
using PhonebookAPI.Models;

using System.Xml.Linq;

namespace PhonebookAPI.Services
{
    public class ContactService: IContact
    {
        private readonly List<Contact> _contacts = new();

        public IEnumerable<Contact> GetAll() => _contacts;

        public Contact? GetByPhone(string phoneNumber) => _contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);

        public void Add(Contact contact)
        {
            if (_contacts.Any(c => c.PhoneNumber == contact.PhoneNumber))
                throw new InvalidOperationException("Phone number must be unique.");
            _contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            var existing = GetByPhone(contact.PhoneNumber);
            if (existing is null) throw new KeyNotFoundException("Contact not found.");
            existing.Name = contact.Name;
            existing.Email = contact.Email;
        }

        public void Delete(string phoneNumber)
        {
            var contact = GetByPhone(phoneNumber);
            if (contact != null) _contacts.Remove(contact);
        }

        public IEnumerable<Contact> Search(string query)
        {
            query = query.ToLower();
            return _contacts.Where(c => c.Name.ToLower().Contains(query) || c.PhoneNumber.Contains(query));
        }
    }
}
