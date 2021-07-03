using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AHProject.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
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
        public virtual DbSet<TblCity> TblCities { get; set; }
        public virtual DbSet<TblCustomer> TblCustomers { get; set; }
        public virtual DbSet<TblDepartment> TblDepartments { get; set; }
        public virtual DbSet<TblEmployee> TblEmployees { get; set; }
        public virtual DbSet<TblEmployeeSalary> TblEmployeeSalaries { get; set; }
        public virtual DbSet<TblOrder> TblOrders { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<VolunteersSettlementHoliday> VolunteersSettlementHolidays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PK__Area__2FC141AA0286ED10");

                entity.ToTable("Area");

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.HasKey(e => e.IdContactPerson)
                    .HasName("PK__ContactP__C28238D125727803");

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
                    .HasConstraintName("FK__ContactPe__IdSet__5832119F");
            });

            modelBuilder.Entity<ExperienceOptional>(entity =>
            {
                entity.HasKey(e => e.IdExperience)
                    .HasName("PK__Experien__FFBB30779CA63981");

                entity.ToTable("ExperienceOptional");

                entity.Property(e => e.DescriptionExperience)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.IdHoliday)
                    .HasName("PK__Holidays__3B6F3E6C9490B6B6");

                entity.Property(e => e.DescriptionHoliday)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HolidayVolunteer>(entity =>
            {
                entity.HasKey(e => new { e.IdSchedulingHoliday, e.IdVolunteer })
                    .HasName("PK__holidayV__7F8D69433834B0EA");

                entity.ToTable("holidayVolunteer");

                entity.HasOne(d => d.IdPrayerNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdPrayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdPra__4AD81681");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdSch__48EFCE0F");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.HolidayVolunteers)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__holidayVo__IdVol__49E3F248");
            });

            modelBuilder.Entity<OptionalVolunteerToHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdVolunteer, e.IdSchedulingHoliday })
                    .HasName("PK__Optional__876239405CF22562");

                entity.ToTable("OptionalVolunteerToHoliday");

                entity.HasOne(d => d.IdExperienceNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdExperience)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdExp__5CF6C6BC");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdSch__5C02A283");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.OptionalVolunteerToHolidays)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OptionalV__IdVol__5B0E7E4A");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.PasswordNumber)
                    .HasName("PK__Password__24C4D47E9F21B8B2");

                entity.Property(e => e.PasswordNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<PrayerText>(entity =>
            {
                entity.HasKey(e => e.IdPrayer)
                    .HasName("PK__PrayerTe__C24F4305D1CE4976");

                entity.ToTable("PrayerText");

                entity.Property(e => e.NamePrayer)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professional>(entity =>
            {
                entity.HasKey(e => e.IdProfessional)
                    .HasName("PK__Professi__1EAEDD294DC207F7");

                entity.ToTable("Professional");

                entity.Property(e => e.DescriptionProfessional)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessionalHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdProfessional, e.IdHoliday })
                    .HasName("PK__Professi__CD182ECF58A1B23F");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.ProfessionalHolidays)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdHol__62AFA012");

                entity.HasOne(d => d.IdProfessionalNavigation)
                    .WithMany(p => p.ProfessionalHolidays)
                    .HasForeignKey(d => d.IdProfessional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Professio__IdPro__61BB7BD9");
            });

            modelBuilder.Entity<SchedulingHoliday>(entity =>
            {
                entity.HasKey(e => e.IdSchedulingHoliday)
                    .HasName("PK__Scheduli__7982C81FC35B9359");

                entity.ToTable("SchedulingHoliday");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.SchedulingHolidays)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedulin__IdHol__46136164");
            });

            modelBuilder.Entity<Settlement>(entity =>
            {
                entity.HasKey(e => e.IdSettlement)
                    .HasName("PK__Settleme__A54EE5C23A320FA6");

                entity.ToTable("Settlement");

                entity.Property(e => e.NameSettlement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdAre__3C89F72A");

                entity.HasOne(d => d.IdContactPerNavigation)
                    .WithMany(p => p.Settlements)
                    .HasForeignKey(d => d.IdContactPer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdCon__695C9DA1");
            });

            modelBuilder.Entity<SettlementHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday })
                    .HasName("PK__Settleme__42D6C9439A099A5F");

                entity.ToTable("SettlementHoliday");

                entity.Property(e => e.AdditionalNeeds)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdExperienceNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdExperience)
                    .HasConstraintName("FK__Settlemen__IdExp__5090EFD7");

                entity.HasOne(d => d.IdPrayerNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdPrayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdPra__4F9CCB9E");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSch__4EA8A765");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.SettlementHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSet__4DB4832C");
            });

            modelBuilder.Entity<SettlementHoliday1>(entity =>
            {
                entity.HasKey(e => new { e.IdHoliday, e.IdSettlement })
                    .HasName("PK__Settleme__013BD03025F66914");

                entity.ToTable("SettlementHolidays");

                entity.HasOne(d => d.IdHolidayNavigation)
                    .WithMany(p => p.SettlementHoliday1s)
                    .HasForeignKey(d => d.IdHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdHol__658C0CBD");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.SettlementHoliday1s)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Settlemen__IdSet__668030F6");
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__tbl_Citi__B4BEB95E4791EB35");

                entity.ToTable("tbl_Cities");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.CityName)
                    .HasMaxLength(20)
                    .HasColumnName("cityName");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_tbl_customers");

                entity.ToTable("tbl_Customers");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.CustomerFirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("customerFirstName");

                entity.Property(e => e.CustomerLastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("customerLastName");

                entity.Property(e => e.EmployeeContactPerson).HasColumnName("employeeContactPerson");

                entity.Property(e => e.PermanentDiscount).HasColumnName("permanentDiscount");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .HasColumnName("phoneNumber");
            });

            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__tbl_Depa__F9B8346D968DB856");

                entity.ToTable("tbl_Departments");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("departmentName");

                entity.Property(e => e.MinimumWorkingHours).HasColumnName("minimumWorkingHours");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__tbl_Empl__C134C9C19070FF68");

                entity.ToTable("tbl_Employees");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.CityId).HasColumnName("cityId");

                entity.Property(e => e.DateBeginWork)
                    .HasColumnType("date")
                    .HasColumnName("dateBeginWork");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("lastName");

                entity.Property(e => e.Street)
                    .HasMaxLength(20)
                    .HasColumnName("street");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .HasColumnName("telephone");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblEmployees)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__tbl_Emplo__cityI__145C0A3F");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Emplo__depar__15502E78");
            });

            modelBuilder.Entity<TblEmployeeSalary>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.SalaryDate })
                    .HasName("PK_tbl_employeeSalary");

                entity.ToTable("tbl_EmployeeSalary");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.SalaryDate)
                    .HasColumnType("date")
                    .HasColumnName("salaryDate");

                entity.Property(e => e.Bonus).HasColumnName("bonus");

                entity.Property(e => e.SalaryAmount).HasColumnName("salaryAmount");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrdNum)
                    .HasName("PK__tbl_orde__00BE61D7169A7304");

                entity.ToTable("tbl_Orders");

                entity.Property(e => e.OrdNum)
                    .ValueGeneratedNever()
                    .HasColumnName("ordNum");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.DiscountPercent).HasColumnName("discountPercent");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__tbl_order__produ__34C8D9D1");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tbl_Prod__2D10D16A41AA3C70");

                entity.ToTable("tbl_Products");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("productId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .HasColumnName("productName");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.HasKey(e => e.IdVolunteer)
                    .HasName("PK__Voluntee__60FA15C1046C143C");

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
                    .HasConstraintName("FK__Volunteer__IdAre__3F6663D5");
            });

            modelBuilder.Entity<VolunteersSettlementHoliday>(entity =>
            {
                entity.HasKey(e => new { e.IdSettlement, e.IdSchedulingHoliday, e.IdVolunteer })
                    .HasName("PK__Voluntee__82B63356440ADC79");

                entity.ToTable("VolunteersSettlementHoliday");

                entity.HasOne(d => d.IdSchedulingHolidayNavigation)
                    .WithMany(p => p.VolunteersSettlementHolidays)
                    .HasForeignKey(d => d.IdSchedulingHoliday)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdSch__546180BB");

                entity.HasOne(d => d.IdSettlementNavigation)
                    .WithMany(p => p.VolunteersSettlementHolidays)
                    .HasForeignKey(d => d.IdSettlement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdSet__536D5C82");

                entity.HasOne(d => d.IdVolunteerNavigation)
                    .WithMany(p => p.VolunteersSettlementHolidays)
                    .HasForeignKey(d => d.IdVolunteer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__IdVol__5555A4F4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
