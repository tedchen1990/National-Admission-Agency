using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class Profile_DAO : IProfile_DAO
    {
        private NAAEntities _context;
        public Profile_DAO()
        {
            _context = new NAAEntities();
        }

        /*get Profile list*/
        public IList<Profile> getProfiles()
        {
            IQueryable<Profile> _profiles;
            _profiles = from profiles
                          in _context.Profile
                          select profiles;
            return _profiles.ToList<Profile>();
        }

        /*get Profile detail*/
        public Profile getProfile_Details(int id)
        {
            IQueryable<Profile> _profileID;
            _profileID = from profile
                           in _context.Profile
                         where profile.ApplicantId == id
                         select profile;
            return _profileID.ToList().FirstOrDefault();
        }

        /*edit Profile*/
        public void editProfiles(Profile profile)
        {
            Profile _profile = getProfile_Details(profile.ApplicantId);
            _profile.ApplicantName = profile.ApplicantName;
            _profile.ApplicantAddress = profile.ApplicantAddress;
            _profile.Email = profile.Email;
            _profile.Phone = profile.Phone;
            _profile.UserId = profile.UserId;
  
            _context.SaveChanges();
        }

        /*create Profile*/
        public void addProfiles(Profile profile)
        {
            _context.Profile.Add(profile);
            _context.SaveChanges();
        }

        /*delete Profile*/
        public void deleteProfiles(Profile profile)
        {
            _context.Profile.Remove(profile);
            _context.SaveChanges();
        }

        /*Search the default user's Profile */
        public Profile checkUserProfile(string id)
        {
            IQueryable<Profile> _profileID;
            _profileID = from profile
                           in _context.Profile
                         where profile.UserId == id
                         orderby profile.ApplicantId descending
                         select profile;
            return _profileID.ToList().FirstOrDefault();
        }

    }
}
