using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.DAL
{
    using Clinic.Domain.Model;
    using Microsoft.EntityFrameworkCore;


    public partial class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
        }

        public virtual DbSet<AccessRight> AccessRights { get; set; }
        public virtual DbSet<Analisis> Analisis { get; set; }
        public virtual DbSet<AnalisisKind> AnalisisKinds { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<MedicalCard> MedicalCards { get; set; }
        public virtual DbSet<MedicalCardRecord> MedicalCardRecords { get; set; }
        public virtual DbSet<MedicalDetails> MedicalDetails { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<OnlineConsultation> OnlineConsultations { get; set; }
        public virtual DbSet<OnlineConsultationMessage> OnlineConsultationMessages { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMenu> UserMenus { get; set; }
        public virtual DbSet<UserAccessRight> UserAccessRights { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<WorkerKind> WorkerKinds { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserMenu>()
        //        .HasOne(bc => bc.Menu)
        //        .WithMany(b => b.UserMenus)
        //        .HasForeignKey(bc => bc.MenuId);

        //    modelBuilder.Entity<UserMenu>()
        //        .HasOne(bc => bc.User)
        //        .WithMany(c => c.UserMenus)
        //        .HasForeignKey(bc => bc.UserId);
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Analisi>()
        //        .HasMany(e => e.Documents)
        //        .WithOptional(e => e.Analisi)
        //        .HasForeignKey(e => e.AnalisisId);

        //    modelBuilder.Entity<AnalisisKind>()
        //        .HasMany(e => e.Analisis)
        //        .WithRequired(e => e.AnalisisKind)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<MedicalCard>()
        //        .HasMany(e => e.MedicalCardRecords)
        //        .WithRequired(e => e.MedicalCard)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Menu>()
        //        .HasMany(e => e.Menu1)
        //        .WithOptional(e => e.Menu2)
        //        .HasForeignKey(e => e.ParentMenuId);

        //    modelBuilder.Entity<OnlineConsultation>()
        //        .HasMany(e => e.OnlineConsultationMessages)
        //        .WithRequired(e => e.OnlineConsultation)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Patient>()
        //        .HasMany(e => e.Appointments)
        //        .WithRequired(e => e.Patient)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Patient>()
        //        .HasMany(e => e.MedicalCards)
        //        .WithRequired(e => e.Patient)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Role>()
        //        .HasMany(e => e.AccessRights)
        //        .WithRequired(e => e.Role)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Role>()
        //        .HasMany(e => e.Menus)
        //        .WithRequired(e => e.Role)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Role>()
        //        .HasMany(e => e.UserRoles)
        //        .WithRequired(e => e.Role)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<User>()
        //        .Property(e => e.Login)
        //        .IsFixedLength();

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.OnlineConsultationMessages)
        //        .WithRequired(e => e.User)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.Patients)
        //        .WithRequired(e => e.User)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.UserRoles)
        //        .WithRequired(e => e.User)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.Workers)
        //        .WithRequired(e => e.User)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Worker>()
        //        .HasMany(e => e.MedicalCardRecords)
        //        .WithRequired(e => e.Worker)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Worker>()
        //        .HasMany(e => e.OnlineConsultations)
        //        .WithRequired(e => e.Worker)
        //        .WillCascadeOnDelete(false);
        //}
    }
}
