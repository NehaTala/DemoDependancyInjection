using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPI.Services.IServices
{
    public interface ITransient
    {
        Guid GetGUID();
    }
}
