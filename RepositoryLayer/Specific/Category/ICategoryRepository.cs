using InterfaceLayer.Interfaces;
using PocoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Specific
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
