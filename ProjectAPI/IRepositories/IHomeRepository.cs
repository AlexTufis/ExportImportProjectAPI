using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Repositories
{
    public interface IHomeRepository
    {
        List<Distribuitor> GetDistribuitors();
    }
}
