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
        public virtual DbSet<OptionalSettlementToHoliday> OptionalSettlementToHolidays { get; set; }
        public virtual DbSet<OptionalVolunteerToHoliday> OptionalVolunteerToHolidays { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<PrayerText> PrayerTexts { get; set; }
        public virtual DbSet<Professional> Professionals { get; set; }
        public virtual DbSet<ProfessionalHoliday> ProfessionalHolidays { get; set; }
        public virtual DbSet<ProfessionalToSchedulingHoliday> ProfessionalToSchedulingHolidays { get; set; }
        public virtual DbSet<ProfessionalToVolunteer> ProfessionalToVolunteers { get; set; }
        public virtual DbSet<SchedulingHoliday> SchedulingHolidays { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }
        public virtual DbSet<SettlementHoliday> SettlementHolidays { get; set; }
        public virtual DbSet<SettlementHoliday1> SettlementHolidays1 { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }

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
                    .HasName("PK__Area__2FC141AA723EE88E");

                entity.ToTable("Area");

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.HasKey(e => e.IdContactPerson)
                    .HasName("PK__ContactP__C28238D14ACED98B");

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
            });

            modelBuilder.Entity<ExperienceOptional>(entity =>
            {
                entity.HasKey(e => e.IdExperience)
                    .HasName("PK__Experien__FFBB3077C05715A7");

                entity.ToTable("ExperienceOptional");

                entity.Property(e => e.DescriptionExperience)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .HasColumnName("icon")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.IdHoliday)
                    .HasName("PK__Holidays__3B6F3E6C741518A9");

                entity.Property(e => e.DescriptionHoliday)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HolidayVolunteer>(entity =>
            {
                entity.HasKey(e => new { e.IdSchedulingHoliday, e.IdVolunteer })
                    .HasName("PK__holidayV__7F8D69435C8A250C");

                entity.ToTable("holidayVolunteer");

                entity.HasOne(d => d.IdPrayerNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdPrayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdPra__49C3F6B7");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdSch__47DBAE45");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdVol__48CFD27E");

                entity.HasOne(d => d.IdS)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => new { d.IdSettlement, d.IdSchedulingHoliday })
                    .HasConstraintName("FK__holidayVolunteer__57DD0BE4");
            });

            modelBuilder.Entity<OptionalSettlementToHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday })
                    .HasName("PK__Optional__42D6C9436895D36A");

                entity.ToTable("OptionalSettlementToHoliday");

                entity.HasOne(d => d.IdExperienceNavigation)
                    .WithMany(p => p.OptionalSettlementToHolidays)
                    .HasForeignKey(d => d.IdExperience)
                    .HasConstraintName("FK__OptionalS__IdExp__75A278F5");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.OptionalSettlementToHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalS__IdSch__74AE54BC");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.OptionalSettlementToHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalS__IdSet__73BA3083");
            });

            modelBuilder.Entity<OptionalVolunteerToHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdVolunteer, e.IdSchedulingHoliday })
                    .HasName("PK__Optional__876239403FF5DD80");

                entity.ToTable("OptionalVolunteerToHoliday");

                entity.HasOne(d => d.IdExperienceNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdExperience)
                    .HasConstraintName("FK__OptionalV__IdExp__5BE2A6F2");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdSch__5AEE82B9");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdVol__59FA5E80");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.PasswordNumber)
                    .HasName("PK__Password__24C4D47EC8FFAF9E");

                entity.Property(e => e.PasswordNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<PrayerText>(entity =>
            {
                entity.HasKey(e => e.IdPrayer)
                    .HasName("PK__PrayerTe__C24F4305D646F4B2");

                entity.ToTable("PrayerText");

                entity.Property(e => e.NamePrayer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professional>(entity =>
            {
                entity.HasKey(e => e.IdProfessional)
                    .HasName("PK__Professi__1EAEDD2933754F50");

                entity.ToTable("Professional");

                entity.Property(e => e.DescriptionProfessional)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessionalHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdProfessional, e.IdHoliday })
                    .HasName("PK__Professi__CD182ECFCFC2A06A");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.ProfessionalHolidays)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdHol__619B8048");

                entity.HasOne(d => d.IdProfessionalNavigation)
                    .WithMany(p => p.ProfessionalHolidays)
                    .HasForeignKey(d => d.IdProfessional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdPro__60A75C0F");
            });

            modelBuilder.Entity<ProfessionalToSchedulingHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday, e.IdProfessional })
                    .HasName("PK__Professi__6AC8679ED125948C");

                entity.ToTable("ProfessionalToSchedulingHoliday");

                entity.HasOne(d => d.IdProfessionalNavigation)
                    .WithMany(p => p.ProfessionalToSchedulingHolidays)
                    .HasForeignKey(d => d.IdProfessional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdPro__6C190EBB");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.ProfessionalToSchedulingHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdSch__6B24EA82");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.ProfessionalToSchedulingHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdSet__6A30C649");
            });

            modelBuilder.Entity<ProfessionalToVolunteer>(entity =>
            {
                entity.HasKey(e => new { e.IdVolunteer, e.IdSchedulingHoliday, e.IdProfessional })
                    .HasName("PK__Professi__AF7C979DD4B2E4D4");

                entity.ToTable("ProfessionalToVolunteer");

                entity.HasOne(d => d.IdProfessionalNavigation)
                    .WithMany(p => p.ProfessionalToVolunteers)
                    .HasForeignKey(d => d.IdProfessional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdPro__70DDC3D8");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.ProfessionalToVolunteers)
                    .HasForeignKey(d => new { d.IdSchedulingHoliday, d.IdVolunteer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProfessionalToVo__3A4CA8FD");
            });

            modelBuilder.Entity<SchedulingHoliday>(entity =>
            {
                entity.HasKey(e => e.IdSchedulingHoliday)
                    .HasName("PK__Scheduli__7982C81F9DB98223");

                entity.ToTable("SchedulingHoliday");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.SchedulingHolidays)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedulin__IdHol__44FF419A");
            });

            modelBuilder.Entity<Settlement>(entity =>
            {
                entity.HasKey(e => e.IdSettlement)
                    .HasName("PK__Settleme__A54EE5C276A015A4");

                entity.ToTable("Settlement");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NameSettlement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdAre__3B75D760");

                entity.HasOne(d => d.IdContactPerNavigation)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.IdContactPer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdCon__76969D2E");
            });

            modelBuilder.Entity<SettlementHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday })
                    .HasName("PK__Settleme__42D6C943F12E482C");

                entity.ToTable("SettlementHoliday");

                entity.Property(e => e.AdditionalNeeds)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPrayerNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdPrayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdPra__4E88ABD4");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSch__4D94879B");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSet__4CA06362");
            });

            modelBuilder.Entity<SettlementHoliday1>(entity =>
            {
                entity.HasKey(e => new { e.IdHoliday, e.IdSettlement })
                    .HasName("PK__Settleme__013BD0304F21A624");

                entity.ToTable("SettlementHolidays");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.SettlementHoliday1s)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdHol__6477ECF3");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.SettlementHoliday1s)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSet__656C112C");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer)
                    .HasName("PK__Voluntee__60FA15C1E79ADB7B");

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
                    .HasConstraintName("FK__Volunteer__IdAre__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
