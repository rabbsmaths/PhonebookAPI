using PhonebookAPI.Models;

namespace PhonebookAPI.Interfaces
{
    public interface IContact
    {
        IEnumerable<Contact> GetAll();
        Contact? GetByPhone(string phoneNumber);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(string phoneNumber);
        IEnumerable<Contact> Search(string query);
    }
}
