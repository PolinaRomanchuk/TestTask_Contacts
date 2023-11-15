using Contacts.Models;
using Data.Sql.Models;

namespace Contacts.Services
{
    public interface IContactService
    {
        void CreateContact(ContactViewModel viewModel);
        List<Contact> GetAllContacts();
        ContactViewModel CreateContactViewModelFromDBModelById(int id);
        List<ContactViewModel> CreateContactsViewModelsFromDBModels();
        void UpdateContact(int id, string newname, string newjob, string newphone, DateTime newbirthday);
        void DeleteContact(int id);
    }
}
