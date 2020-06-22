using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAA.Data.IDAO;

namespace NAA.Data.DAO
{
    public class University_DAO : IUniversity_DAO
    {
        private NAAEntities _context;

        public University_DAO()
        {
            _context = new NAAEntities();
        }
        /* get Univserity */
        public IList<University> getUniversity()
        {
            IQueryable<University> _Universities;
            _Universities = from Universities
                          in _context.University
                            select Universities;
            return _Universities.ToList<University>();
        }
    }
}
