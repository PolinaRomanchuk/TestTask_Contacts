using Contacts.Models;
using Contacts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        private IContactService _contactService;
        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult ContactList()
        {
            var viewModels = _contactService.CreateContactsViewModelsFromDBModels();
            return View(viewModels);
        }

        [HttpPost]
        public IActionResult CreateNewContact(ContactViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _contactService.CreateContact(viewModel);
            return RedirectToAction("ContactList");
        }

        [HttpPost]
        public IActionResult UpdateContact(ContactViewModel viewModel)
        {
            _contactService.UpdateContact(viewModel.Id, viewModel.Name, viewModel.JobTitle, viewModel.MobilePhone, DateTime.Parse(viewModel.BirthDate));
            return RedirectToAction("ContactList");
        }

        public IActionResult DeleteContact(int id)
        {
            _contactService.DeleteContact(id);
            return RedirectToAction("ContactList");
        }
    }
}