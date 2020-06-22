using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;

namespace NAA.Services.IService
{
     interface IApplication_Service
    {
        IList<Application> getApplication();

        /*create Application*/
        void addApplication(Application application);

        /* One Application */
        IList<Application> StudentApplication(int ApplicantId);

        /*delete Application*/
        void deleteApplication(Application application);


        /* -------------------------------------------------------- Exposes  services */

        /* University Applications */
        IList<Application> UniversityApplications(int UniversityId);

        /* Application detail*/
        Application detailApplication(int Applicationid);
        
        /* Update an Application */
        void editApplication(Application application);
    }
}
