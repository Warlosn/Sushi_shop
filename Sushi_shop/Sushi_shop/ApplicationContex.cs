using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Entity;


namespace Sushi_shop
{
    class ApplicationContex : DbContext
    { 
    public DbSet<Client> Clients { get; set; }

        public ApplicationContex() : base("DefaultConnection") { }
    }
    
}
