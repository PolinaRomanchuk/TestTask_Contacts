using Data.Sql.Models;

namespace Data.Sql.Repositories
{
    public interface IContactRepository
    {
        Contact Create(Contact model);
        Contact Get(int id);
        IEnumerable<Contact> GetAll();
        void UpdateData(int id, string newname, string newjob, string newphone, DateTime newbirthday);
        void Delete(int id);
        bool Any();
    }
}
