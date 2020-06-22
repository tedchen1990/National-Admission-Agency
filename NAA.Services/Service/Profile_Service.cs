using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;
using NAA.Data.DAO;

namespace NAA.Services.Service
{
    public class Profile_Service : NAA.Services.IService.IProfile_Service
    {
        private Profile_DAO _profile_DAO;
        public Profile_Service()
        {
            _profile_DAO = new Profile_DAO();
        }

        /*get Profile list*/
        public IList<Profile> getProfiles()
        {
            return _profile_DAO.getProfiles();
        }

        /*get Profile detail*/
        public Profile getProfile_Details(int id)
        {
            return _profile_DAO.getProfile_Details(id);
        }

        /*edit Profile*/
        public void editProfiles(Profile profile)
        {
            _profile_DAO.editProfiles(profile);
        }

        /*create Profile*/
        public void addProfiles(Profile profile)
        {
            _profile_DAO.addProfiles(profile);
        }

        /*delete Profile*/
        public void deleteProfiles(Profile profile)
        {
            _profile_DAO.deleteProfiles(profile);
        }

        /*Search the default user's Profile */
        public Profile checkUserProfile(string id)
        {
            return _profile_DAO.checkUserProfile(id);
        }
    }
}
