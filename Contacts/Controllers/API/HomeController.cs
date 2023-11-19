using Contacts.Services;
using Data.Sql.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers.API
{
    [ApiController]
    [Route("/api/contact")]
    public class HomeApiController : Controller
    {
        private IContactService _contactService;
        private IContactRepository _contactRepository;
        public HomeApiController(IContactService contactService, IContactRepository contactRepository)
        {
            _contactService = contactService;
            _contactRepository = contactRepository;
        }
       
        [Route("GetModel")]
        public Object GetModel(int id)
        {
            return _contactRepository.Get(id);
        }
    }
}