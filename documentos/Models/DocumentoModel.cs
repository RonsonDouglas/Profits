
using MySql.Data.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;

namespace Teste
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DocumentoModel : DbContext
    {
        public DbSet<Documento> Documento { get; set; }

        public DocumentoModel()
          : base()
        {

        }

        // Constructor to use on a DbConnection that is already opened
        public DocumentoModel(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Documento>().MapToStoredProcedures();
        }
    }

    public class Documento
    {
        [Display(Name = "Id do Documento")]
        public int id { get; set; }

        [Display(Name = "Código do Documento")]
        public string codigo { get; set; }
        
        [Display(Name = "Título")]
        public string titulo { get; set; }
        
        [Display(Name = "Revisão")]
        public string revisao { get; set; }
        
        [Display(Name = "Data Planejada")]
        public DateTime data { get; set; }
        
        [Display(Name = "Valor R$")]
        public decimal valor { get; set; }
    }
}