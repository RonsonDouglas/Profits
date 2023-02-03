using System;
using System.Collections.Generic;
using System.Data.Entity;
using MySql.Data.EntityFramework;
using System.Linq;
using System.Web;
using Teste;

namespace documentos.Data
{
    public class documentosContext : DbContext
    {
        
        public documentosContext() : base("name=documentosContext")
        {
        }

        public DbSet<Documento> Documento { get; set; }
    }
}
