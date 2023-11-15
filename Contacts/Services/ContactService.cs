using Contacts.Models;
using Data.Sql.Models;
using Data.Sql.Repositories;

namespace Contacts.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void CreateContact(ContactViewModel viewModel)
        {
            var dbContactModel = new Contact()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                MobilePhone = viewModel.MobilePhone,
                JobTitle = viewModel.JobTitle,
                BirthDate = viewModel.BirthDate,
            };

            _contactRepository.Create(dbContactModel);
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository
                .GetAll()
                .ToList();
        }

        public ContactViewModel CreateContactViewModelFromDBModelById(int id)
        {
            var contactDb = _contactRepository.Get(id);
            return new ContactViewModel
            {
                Id = contactDb.Id,
                Name = contactDb.Name,
                BirthDate = contactDb.BirthDate,
                JobTitle = contactDb.JobTitle,
                MobilePhone = contactDb.MobilePhone,
            };
        }

        public List<ContactViewModel> CreateContactsViewModelsFromDBModels()
        {
            return GetAllContacts().Select(dbModel => new ContactViewModel
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                MobilePhone = dbModel.MobilePhone,
                BirthDate = dbModel.BirthDate,
                JobTitle = dbModel.JobTitle,
            }).ToList();
        }

        public void UpdateContact(int id, string newname, string newjob, string newphone, DateTime newbirthday)
        {
            _contactRepository.UpdateData(id, newname, newjob, newphone, newbirthday);
        }

        public void DeleteContact(int id)
        {
            _contactRepository.Delete(id);
        }
    }
}

