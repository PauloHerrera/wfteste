﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication3.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class TesteEntities : DbContext
    {
        public TesteEntities()
            : base("name=TesteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Estado> Estados { get; set; }
    
        public virtual ObjectResult<ListaEstados_Result> ListaEstados(string sigla)
        {
            var siglaParameter = sigla != null ?
                new ObjectParameter("sigla", sigla) :
                new ObjectParameter("sigla", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListaEstados_Result>("ListaEstados", siglaParameter);
        }
    }
}