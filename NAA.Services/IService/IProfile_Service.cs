using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data;

namespace NAA.Services.IService
{
     interface IProfile_Service
    {
        /*get Profile list*/
        IList<Profile> getProfiles();

        /*get Profile detail*/
        Profile getProfile_Details(int id);

        /*edit Profile*/
        void editProfiles(Profile profile);

        /*create Profile*/
        void addProfiles(Profile profile);

        /*delete Profile*/
        void deleteProfiles(Profile profile);

        /*Search the default user's Profile */
         Profile checkUserProfile(string id);
    }
}
