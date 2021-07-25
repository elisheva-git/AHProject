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
                    .HasName("PK__Area__2FC141AA9081C771");

                entity.ToTable("Area");

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.HasKey(e => e.IdContactPerson)
                    .HasName("PK__ContactP__C28238D168D6AABA");

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
                    .HasName("PK__Experien__FFBB30777A6D497C");

                entity.ToTable("ExperienceOptional");

                entity.Property(e => e.DescriptionExperience)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.IdHoliday)
                    .HasName("PK__Holidays__3B6F3E6CEC744CE0");

                entity.Property(e => e.DescriptionHoliday)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HolidayVolunteer>(entity =>
            {
                entity.HasKey(e => new { e.IdSchedulingHoliday, e.IdVolunteer })
                    .HasName("PK__holidayV__7F8D694388C0A388");

                entity.ToTable("holidayVolunteer");

                entity.HasOne(d => d.IdPrayerNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdPrayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdPra__22AA2996");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdSch__20C1E124");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdVol__21B6055D");
            });

            modelBuilder.Entity<OptionalSettlementToHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday })
                    .HasName("PK__Optional__42D6C943867B03CD");

                entity.ToTable("OptionalSettlementToHoliday");

                entity.HasOne(d => d.IdExperienceNavigation)
                    .WithMany(p => p.OptionalSettlementToHolidays)
                    .HasForeignKey(d => d.IdExperience)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalS__IdExp__4E88ABD4");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.OptionalSettlementToHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalS__IdSch__4D94879B");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.OptionalSettlementToHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalS__IdSet__4CA06362");
            });

            modelBuilder.Entity<OptionalVolunteerToHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdVolunteer, e.IdSchedulingHoliday })
                    .HasName("PK__Optional__87623940B8A76BBF");

                entity.ToTable("OptionalVolunteerToHoliday");

                entity.HasOne(d => d.IdExperienceNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdExperience)
                    .HasConstraintName("FK__OptionalV__IdExp__34C8D9D1");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdSch__33D4B598");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdVol__32E0915F");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.PasswordNumber)
                    .HasName("PK__Password__24C4D47ED956E7C5");

                entity.Property(e => e.PasswordNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<PrayerText>(entity =>
            {
                entity.HasKey(e => e.IdPrayer)
                    .HasName("PK__PrayerTe__C24F430510940AB9");

                entity.ToTable("PrayerText");

                entity.Property(e => e.NamePrayer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professional>(entity =>
            {
                entity.HasKey(e => e.IdProfessional)
                    .HasName("PK__Professi__1EAEDD29CEC9D2B3");

                entity.ToTable("Professional");

                entity.Property(e => e.DescriptionProfessional)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessionalHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdProfessional, e.IdHoliday })
                    .HasName("PK__Professi__CD182ECF2A094D7D");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.ProfessionalHolidays)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdHol__3A81B327");

                entity.HasOne(d => d.IdProfessionalNavigation)
                    .WithMany(p => p.ProfessionalHolidays)
                    .HasForeignKey(d => d.IdProfessional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdPro__398D8EEE");
            });

            modelBuilder.Entity<ProfessionalToSchedulingHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday, e.IdProfessional })
                    .HasName("PK__Professi__6AC8679E1C590810");

                entity.ToTable("ProfessionalToSchedulingHoliday");

                entity.HasOne(d => d.IdProfessionalNavigation)
                    .WithMany(p => p.ProfessionalToSchedulingHolidays)
                    .HasForeignKey(d => d.IdProfessional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdPro__44FF419A");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.ProfessionalToSchedulingHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdSch__440B1D61");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.ProfessionalToSchedulingHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdSet__4316F928");
            });

            modelBuilder.Entity<ProfessionalToVolunteer>(entity =>
            {
                entity.HasKey(e => new { e.IdVolunteer, e.IdSchedulingHoliday, e.IdProfessional })
                    .HasName("PK__Professi__AF7C979DE3B785F5");

                entity.ToTable("ProfessionalToVolunteer");

                entity.HasOne(d => d.IdProfessionalNavigation)
                    .WithMany(p => p.ProfessionalToVolunteers)
                    .HasForeignKey(d => d.IdProfessional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdPro__49C3F6B7");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.ProfessionalToVolunteers)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdSch__48CFD27E");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.ProfessionalToVolunteers)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdVol__47DBAE45");
            });

            modelBuilder.Entity<SchedulingHoliday>(entity =>
            {
                entity.HasKey(e => e.IdSchedulingHoliday)
                    .HasName("PK__Scheduli__7982C81FD7B4D07E");

                entity.ToTable("SchedulingHoliday");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.SchedulingHolidays)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedulin__IdHol__1DE57479");
            });

            modelBuilder.Entity<Settlement>(entity =>
            {
                entity.HasKey(e => e.IdSettlement)
                    .HasName("PK__Settleme__A54EE5C2D21642B9");

                entity.ToTable("Settlement");

                entity.Property(e => e.NameSettlement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdAre__145C0A3F");

                entity.HasOne(d => d.IdContactPerNavigation)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.IdContactPer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdCon__4F7CD00D");
            });

            modelBuilder.Entity<SettlementHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday })
                    .HasName("PK__Settleme__42D6C943EF2E286E");

                entity.ToTable("SettlementHoliday");

                entity.Property(e => e.AdditionalNeeds)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdExperienceNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdExperience)
                    .HasConstraintName("FK__Settlemen__IdExp__286302EC");

                entity.HasOne(d => d.IdPrayerNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdPrayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdPra__276EDEB3");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSch__267ABA7A");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSet__25869641");
            });

            modelBuilder.Entity<SettlementHoliday1>(entity =>
            {
                entity.HasKey(e => new { e.IdHoliday, e.IdSettlement })
                    .HasName("PK__Settleme__013BD030F91AAD2C");

                entity.ToTable("SettlementHolidays");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.SettlementHoliday1s)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdHol__3D5E1FD2");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.SettlementHoliday1s)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSet__3E52440B");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer)
                    .HasName("PK__Voluntee__60FA15C1C9B9D1C9");

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
                    .HasConstraintName("FK__Volunteer__IdAre__173876EA");
            });

            modelBuilder.Entity<VolunteersSettlementHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday, e.IdVolunteer })
                    .HasName("PK__Voluntee__82B6335663CA0039");

                entity.ToTable("VolunteersSettlementHoliday");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.VolunteersSettlementHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdSch__2C3393D0");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.VolunteersSettlementHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdSet__2B3F6F97");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.VolunteersSettlementHolidays)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdVol__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
