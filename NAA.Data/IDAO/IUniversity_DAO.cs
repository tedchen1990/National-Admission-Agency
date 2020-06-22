using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.DAO;

namespace NAA.Data.IDAO
{
    interface IUniversity_DAO
    {
        /* get University */
        IList<University> getUniversity();
    }
}
