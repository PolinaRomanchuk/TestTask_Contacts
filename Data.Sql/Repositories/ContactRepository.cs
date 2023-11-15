using Data.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Sql.Repositories
{
    public class ContactRepository : IContactRepository
    {
        protected WebContext _webContext;
        protected DbSet<Contact> _dbSet;

        public ContactRepository(WebContext webContext)
        {
            _webContext = webContext;
            _dbSet = webContext.Set<Contact>();
        }

        public Contact Create(Contact model)
        {
            _dbSet.Add(model);
            _webContext.SaveChanges();
            return model;
        }

        public Contact Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(Get(id));
            _webContext.SaveChanges();
        }

        public bool Any()
           => _dbSet.Any();

        public void UpdateData(int id, string newname, string newjob, string newphone, DateTime newbirthday)
        {
            var contact = Get(id);
            contact.Name = newname;
            contact.MobilePhone = newphone;
            contact.BirthDate = newbirthday;
            contact.JobTitle = newjob;
            _webContext.SaveChanges();
        }
    }
}
