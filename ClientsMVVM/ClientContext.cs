using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using ClientsMVVM.Model;

namespace ClientsMVVM
{
    class ClientContext : DbContext
    {
        public ClientContext() : base("ClientDB")
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}
