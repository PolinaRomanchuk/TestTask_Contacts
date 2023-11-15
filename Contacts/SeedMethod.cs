using Data.Sql.Models;
using Data.Sql.Repositories;

namespace Contacts
{
    public static class SeedMethod
    {
        public static void Seed(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                SeedContact(scope);
            }
        }

        private static void SeedContact(IServiceScope scope)
        {
            var contactRepository = scope.ServiceProvider.GetRequiredService<IContactRepository>();

            if (!contactRepository.Any())
            {
                var contactdefault = new Contact
                {
                    Name = "Polina",
                    MobilePhone = "+375291231212",
                    JobTitle = "Softaware engineer",
                    BirthDate = DateTime.Now.Date,
                };
                contactRepository.Create(contactdefault);
            }
        }
    }
}