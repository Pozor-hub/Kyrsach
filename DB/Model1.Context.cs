//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kyrsach.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class k_09Entities : DbContext
    {
        public k_09Entities()
            : base("name=k_09Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Бронь> Бронь { get; set; }
        public virtual DbSet<Номера> Номера { get; set; }
        public virtual DbSet<Регистрация> Регистрация { get; set; }
        public virtual DbSet<Статусы_номеров> Статусы_номеров { get; set; }
    }
}
