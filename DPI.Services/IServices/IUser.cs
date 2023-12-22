using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPI.Data.Models;

namespace DPI.Services.IServices
{
    public interface IUser : IScoped, ITransient, ISingleton
    {
        List<TblUser> GetUserData();
    }
}
