using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FactoryManagement.Entities.Concrete.CustomIdentity
{
    public class AppRole:IdentityRole<int>
    {
    }
}
