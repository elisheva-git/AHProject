using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AHProject.DAL.Models
{
    public partial class AHDBContext : DbContext
    {
        public AHDBContext()
        {
        }

        public AHDBContext(DbContextOptions<AHDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<ContactPerson> ContactPeople { get; set; }
        public virtual DbSet<ExperienceOptional> ExperienceOptionals { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<HolidayVolunteer> HolidayVolunteers { get; set; }
        public virtual DbSet<OptionalVolunteerToHoliday> OptionalVolunteerToHolidays { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<PrayerText> PrayerTexts { get; set; }
        public virtual DbSet<Professional> Professionals { get; set; }
        public virtual DbSet<ProfessionalHoliday> ProfessionalHolidays { get; set; }
        public virtual DbSet<SchedulingHoliday> SchedulingHolidays { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }
        public virtual DbSet<SettlementHoliday> SettlementHolidays { get; set; }
        public virtual DbSet<SettlementHoliday1> SettlementHolidays1 { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<VolunteersSettlementHoliday> VolunteersSettlementHolidays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AHDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PK__Area__2FC141AA179E3E6B");

                entity.ToTable("Area");

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.HasKey(e => e.IdContactPerson)
                    .HasName("PK__ContactP__C28238D1E1AE30B2");

                entity.ToTable("ContactPerson");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.ContactPeople)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContactPe__IdSet__3F466844");
            });

            modelBuilder.Entity<ExperienceOptional>(entity =>
            {
                entity.HasKey(e => e.IdExperience)
                    .HasName("PK__Experien__FFBB3077B841EFE2");

                entity.ToTable("ExperienceOptional");

                entity.Property(e => e.DescriptionExperience)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.IdHoliday)
                    .HasName("PK__Holidays__3B6F3E6CF63343CF");

                entity.Property(e => e.DescriptionHoliday)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HolidayVolunteer>(entity =>
            {
                entity.HasKey(e => new { e.IdSchedulingHoliday, e.IdVolunteer })
                    .HasName("PK__holidayV__7F8D694322670814");

                entity.ToTable("holidayVolunteer");

                entity.HasOne(d => d.IdPrayerNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdPrayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdPra__36B12243");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdSch__34C8D9D1");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdVol__35BCFE0A");
            });

            modelBuilder.Entity<OptionalVolunteerToHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdVolunteer, e.IdSchedulingHoliday })
                    .HasName("PK__Optional__87623940DD3D8E7F");

                entity.ToTable("OptionalVolunteerToHoliday");

                entity.HasOne(d => d.IdExperienceNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdExperience)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdExp__440B1D61");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdSch__4316F928");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdVol__4222D4EF");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.PasswordNumber)
                    .HasName("PK__Password__24C4D47E19A14C00");

                entity.Property(e => e.PasswordNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<PrayerText>(entity =>
            {
                entity.HasKey(e => e.IdPrayer)
                    .HasName("PK__PrayerTe__C24F43059F385FAB");

                entity.ToTable("PrayerText");

                entity.Property(e => e.NamePrayer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professional>(entity =>
            {
                entity.HasKey(e => e.IdProfessional)
                    .HasName("PK__Professi__1EAEDD29EC2836BF");

                entity.ToTable("Professional");

                entity.Property(e => e.DescriptionProfessional)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessionalHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdProfessional, e.IdHoliday })
                    .HasName("PK__Professi__CD182ECFA88EFFC0");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.ProfessionalHolidays)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdHol__49C3F6B7");

                entity.HasOne(d => d.IdProfessionalNavigation)
                    .WithMany(p => p.ProfessionalHolidays)
                    .HasForeignKey(d => d.IdProfessional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdPro__48CFD27E");
            });

            modelBuilder.Entity<SchedulingHoliday>(entity =>
            {
                entity.HasKey(e => e.IdSchedulingHoliday)
                    .HasName("PK__Scheduli__7982C81F9BF4D464");

                entity.ToTable("SchedulingHoliday");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.SchedulingHolidays)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedulin__IdHol__31EC6D26");
            });

            modelBuilder.Entity<Settlement>(entity =>
            {
                entity.HasKey(e => e.IdSettlement)
                    .HasName("PK__Settleme__A54EE5C2A67683D6");

                entity.ToTable("Settlement");

                entity.Property(e => e.NameSettlement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdAre__286302EC");

                entity.HasOne(d => d.IdContactPerNavigation)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.IdContactPer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdCon__59FA5E80");
            });

            modelBuilder.Entity<SettlementHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday })
                    .HasName("PK__Settleme__42D6C9432B8B5D4D");

                entity.ToTable("SettlementHoliday");

                entity.Property(e => e.AdditionalNeeds)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdExperienceNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdExperience)
                    .HasConstraintName("FK__Settlemen__IdExp__3C69FB99");

                entity.HasOne(d => d.IdPrayerNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdPrayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdPra__3B75D760");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSch__3A81B327");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSet__398D8EEE");
            });

            modelBuilder.Entity<SettlementHoliday1>(entity =>
            {
                entity.HasKey(e => new { e.IdHoliday, e.IdSettlement })
                    .HasName("PK__Settleme__013BD0305DB7AC0F");

                entity.ToTable("SettlementHolidays");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.SettlementHoliday1s)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdHol__4CA06362");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.SettlementHoliday1s)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSet__4D94879B");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer)
                    .HasName("PK__Voluntee__60FA15C158760EAC");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdAre__2B3F6F97");
            });

            modelBuilder.Entity<VolunteersSettlementHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday, e.IdVolunteer })
                    .HasName("PK__Voluntee__82B63356CCF7EC2F");

                entity.ToTable("VolunteersSettlementHoliday");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.VolunteersSettlementHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdSch__534D60F1");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.VolunteersSettlementHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdSet__52593CB8");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.VolunteersSettlementHolidays)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdVol__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
