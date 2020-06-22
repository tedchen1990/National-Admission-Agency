using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.DAO;

namespace NAA.Data.IDAO
{
    interface IApplication_DAO
    {
        /* get all Application */
        IList<Application> getApplication();

        /* get Applications of Uni */
        IList<Application> getUniApplication(int id);

        /* get Application of applicantId */
        IList<Application> getApplicationOfID(int id);

        /*Application detail*/
        Application detailApplication(int id);

        /*create Application*/
        void addApplication(Application application);

        /*delete Application*/
        void deleteApplication(Application application);

        /*edit Application*/
        void editApplication(Application application);

    }
}
