using Contacts.Services;
using Data.Sql.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers.API
{
    [ApiController]
    [Route("/api/contact")]
    public class HomeApiController : Controller
    {
        private IContactRepository _contactRepository;
        public HomeApiController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
       
        [Route("GetModel")]
        public Object GetModel(int id)
        {
            return _contactRepository.Get(id);
        }
    }
}