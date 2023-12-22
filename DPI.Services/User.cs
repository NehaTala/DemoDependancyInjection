using DPI.Services.IServices;
using DPI.Data.Models;

namespace DPI.Services
{
    public class UserMethod : ITransient, ISingleton, IScoped
    {
        Guid id;
        TestCoreContext context = new TestCoreContext();

        public UserMethod()
        {
            id = Guid.NewGuid();
        }

        public List<TblUser> GetAddUsers()
        {
            return context.TblUsers.ToList();
        }

        public Guid GetGUID()
        {
            return id;
        }
    }
}