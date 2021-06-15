using ProjectAPI.Data;
using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private ApplicationDbContext context;

        public HomeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<Distribuitor> GetDistribuitors()
        {
            var distribuitors = context.Distribuitors.ToList();
            return distribuitors;
        }
    }
}
