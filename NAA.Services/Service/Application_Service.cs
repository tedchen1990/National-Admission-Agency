using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.DAO;

namespace NAA.Services.Service
{
    public class Application_Service : NAA.Services.IService.IApplication_Service
    {
        private Application_DAO _application_DAO;
        public Application_Service()
        {
            _application_DAO = new Application_DAO();
        }

        /* get Applicaion all list */
        public IList<Application> getApplication()
        {
            return _application_DAO.getApplication();
        }

        /*create Profile*/
        public void addApplication(Application application)
        {
            _application_DAO.addApplication(application);
        }

        /* One Application */
        public IList<Application> StudentApplication(int ApplicantId)
        {
            return _application_DAO.getApplicationOfID(ApplicantId);
        }

        /*delete Application*/
        public void deleteApplication(Application application)
        {
            _application_DAO.deleteApplication(application);
        }

        /* -------------------------------------------------------- Exposes  services */
        /* University Applications */
        public IList<Application> UniversityApplications(int UniversityId)
        {
           return _application_DAO.getUniApplication(UniversityId);
        }

        /* Application details*/
        public Application detailApplication(int Applicationid)
        {
            return _application_DAO.detailApplication(Applicationid);
        }
        
        /*Update applications*/
        public void editApplication(Application application)
        {
            _application_DAO.editApplication(application);
        }
    }
}
