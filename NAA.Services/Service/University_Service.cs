using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.DAO;

namespace NAA.Services.Service
{
     public class University_Service: NAA.Services.IService.IUniversity_Service
    {
        private University_DAO _University_DAO;
        public University_Service()
        {
            _University_DAO = new University_DAO();
        }
        /* get Univserity */
        public IList<University> getUniversity()
        {
            return _University_DAO.getUniversity();
        }
    }
}
