using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;

namespace NAA.Services.IService
{
    interface IUniversity_Service
    {
        /* get Univserity */
        IList<University> getUniversity();
    }
}
