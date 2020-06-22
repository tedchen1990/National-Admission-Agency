using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class Application_DAO : IApplication_DAO
    {
        private NAAEntities _context;
        public Application_DAO()
        {
            _context = new NAAEntities();
        }


        /* get All Application */
        public IList<Application> getApplication()
        {
            IQueryable<Application> _Applications;
            _Applications = from app
                          in _context.Application
                            select app;
            return _Applications.ToList<Application>();
        }

        /* get Applications of Uni */
        public IList<Application> getUniApplication(int id)
        {
            IQueryable<Application> _Applications;
            _Applications = from app
                          in _context.Application
                            where app.UniversityId == id
                            select app;
            return _Applications.ToList<Application>();
        }

        /* get Application of ApplicantId */
        public IList<Application> getApplicationOfID(int id)
        {
            IQueryable<Application> _Applications;
            _Applications = from app
                          in _context.Application
                            where app.ApplicantId == id
                            select app;
            return _Applications.ToList<Application>();
        }

        /*create Application*/
        public void addApplication(Application application)
        {
            _context.Application.Add(application);
            _context.SaveChanges();
        }

        /*delete Application*/
        public void deleteApplication(Application application)
        {
            _context.Application.Remove(application);
            _context.SaveChanges();
        }

        /* Application details*/
        public Application detailApplication(int id)
        {
            IQueryable<Application> _applicationID;
            _applicationID = from applicationid
                           in _context.Application
                         where applicationid.ApplicationId == id
                         select applicationid;
            return _applicationID.ToList().First();
        }

        /* Edit application*/
        public void editApplication(Application application)
        {
            Application _appliction = detailApplication(application.ApplicationId);
            _appliction.ApplicantId = application.ApplicantId;
            _appliction.CourseName = application.CourseName;
            _appliction.PersonalStatement = application.PersonalStatement;
            _appliction.TeacherContactDetails = application.TeacherContactDetails;
            _appliction.TeacherReference = application.TeacherReference;
            _appliction.UniversityOffer = application.UniversityOffer;
            _appliction.UniversityId = application.UniversityId;
            _appliction.Firm = application.Firm;

            _context.SaveChanges();
        }
    }
}
