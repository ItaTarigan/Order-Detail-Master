using System;
using BalitTanahPelayanan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BalitTanahPelayanan.Models
{
    public partial class smlpobDB : DbContext
    {
        public smlpobDB()
        {
        }

        public smlpobDB(DbContextOptions<smlpobDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounttbl> Accounttbl { get; set; }
        public virtual DbSet<Analysistypetbl> Analysistypetbl { get; set; }
        public virtual DbSet<Autonumbertbl> Autonumbertbl { get; set; }
        public virtual DbSet<Batchtbl> Batchtbl { get; set; }
        public virtual DbSet<Comoditytbl> Comoditytbl { get; set; }
        public virtual DbSet<Customertbl> Customertbl { get; set; }
        public virtual DbSet<Elementservicehistorytbl> Elementservicehistorytbl { get; set; }
        public virtual DbSet<Elementservicestbl> Elementservicestbl { get; set; }
        public virtual DbSet<Employeetbl> Employeetbl { get; set; }
        public virtual DbSet<Genustbl> Genustbl { get; set; }
        public virtual DbSet<Laboratoriumtbl> Laboratoriumtbl { get; set; }
        public virtual DbSet<Logtbl> Logtbl { get; set; }
        public virtual DbSet<MyAspnetApplications> MyAspnetApplications { get; set; }
        public virtual DbSet<MyAspnetMembership> MyAspnetMembership { get; set; }
        public virtual DbSet<MyAspnetPaths> MyAspnetPaths { get; set; }
        public virtual DbSet<MyAspnetPersonalizationallusers> MyAspnetPersonalizationallusers { get; set; }
        public virtual DbSet<MyAspnetPersonalizationperuser> MyAspnetPersonalizationperuser { get; set; }
        public virtual DbSet<MyAspnetProfiles> MyAspnetProfiles { get; set; }
        public virtual DbSet<MyAspnetRoles> MyAspnetRoles { get; set; }
        public virtual DbSet<MyAspnetSchemaversion> MyAspnetSchemaversion { get; set; }
        public virtual DbSet<MyAspnetSessioncleanup> MyAspnetSessioncleanup { get; set; }
        public virtual DbSet<MyAspnetSessions> MyAspnetSessions { get; set; }
        public virtual DbSet<MyAspnetSitemap> MyAspnetSitemap { get; set; }
        public virtual DbSet<MyAspnetUsers> MyAspnetUsers { get; set; }
        public virtual DbSet<MyAspnetUsersinroles> MyAspnetUsersinroles { get; set; }
        public virtual DbSet<MysqlMembership> MysqlMembership { get; set; }
        public virtual DbSet<Orderanalysisdetailtbl> Orderanalysisdetailtbl { get; set; }
        public virtual DbSet<Ordermastertbl> Ordermastertbl { get; set; }
        public virtual DbSet<Ordernavigationtbl> Ordernavigationtbl { get; set; }
        public virtual DbSet<Orderpricedetailtbl> Orderpricedetailtbl { get; set; }
        public virtual DbSet<Ordersampletbl> Ordersampletbl { get; set; }
        public virtual DbSet<Packagedetailtbl> Packagedetailtbl { get; set; }
        public virtual DbSet<Packagetbl> Packagetbl { get; set; }
        public virtual DbSet<Parameterstbl> Parameterstbl { get; set; }
        public virtual DbSet<Paymenttbl> Paymenttbl { get; set; }
        public virtual DbSet<Resulttbl> Resulttbl { get; set; }
        public virtual DbSet<Reviewingtbl> Reviewingtbl { get; set; }
        public virtual DbSet<Roletbl> Roletbl { get; set; }
        public virtual DbSet<Sampletypetbl> Sampletypetbl { get; set; }
        public virtual DbSet<Standarddetailtbl> Standarddetailtbl { get; set; }
        public virtual DbSet<Standardtbl> Standardtbl { get; set; }
        public virtual DbSet<Workflowlogtbl> Workflowlogtbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(AppConstants.DbConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounttbl>(entity =>
            {
                entity.HasKey(e => e.AccountNo)
                    .HasName("PRIMARY");

                entity.ToTable("Accounttbl");

                entity.HasIndex(e => e.RoleName)
                    .HasName("AccounttbltoRoleTbl");

                entity.Property(e => e.AccountNo)
                    .HasColumnName("accountNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.IsEmailVerified)
                    .HasColumnName("isEmailVerified")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleNameNavigation)
                    .WithMany(p => p.Accounttbl)
                    .HasForeignKey(d => d.RoleName)
                    .HasConstraintName("AccounttbltoRoleTbl");
            });

            modelBuilder.Entity<Analysistypetbl>(entity =>
            {
                entity.HasKey(e => e.AnalysisTypeName)
                    .HasName("PRIMARY");

                entity.ToTable("analysistypetbl");

                entity.Property(e => e.AnalysisTypeName)
                    .HasColumnName("analysisTypeName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");
            });

            modelBuilder.Entity<Autonumbertbl>(entity =>
            {
                entity.ToTable("autonumbertbl");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.LastCounter).HasColumnType("bigint(20)");

                entity.Property(e => e.NameSet)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'General'");
            });

            modelBuilder.Entity<Batchtbl>(entity =>
            {
                entity.HasKey(e => e.BatchId)
                    .HasName("PRIMARY");

                entity.ToTable("batchtbl");

                entity.HasIndex(e => e.PicAnalis)
                    .HasName("BatchTblToEmployeeTbl");

                entity.HasIndex(e => e.PicPenyelia)
                    .HasName("FK_batchtbl_employeetbl");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fileurl).HasColumnName("fileurl");

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.PicAnalis)
                    .HasColumnName("pic_analis")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PicPenyelia)
                    .HasColumnName("pic_penyelia")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'Menunggu'");

                entity.HasOne(d => d.PicAnalisNavigation)
                    .WithMany(p => p.BatchtblPicAnalisNavigation)
                    .HasForeignKey(d => d.PicAnalis)
                    .HasConstraintName("BatchTblToEmployeeTbl");

                entity.HasOne(d => d.PicPenyeliaNavigation)
                    .WithMany(p => p.BatchtblPicPenyeliaNavigation)
                    .HasForeignKey(d => d.PicPenyelia)
                    .HasConstraintName("FK_batchtbl_employeetbl");
            });

            modelBuilder.Entity<Comoditytbl>(entity =>
            {
                entity.HasKey(e => e.ComodityNo)
                    .HasName("PRIMARY");

                entity.ToTable("comoditytbl");

                entity.HasIndex(e => e.ComodityName)
                    .HasName("comodityName")
                    .IsUnique();

                entity.Property(e => e.ComodityNo)
                    .HasColumnName("comodityNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ComodityName)
                    .HasColumnName("comodityName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.DerivativeTo)
                    .HasColumnName("derivativeTo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IsGenusAvailable)
                    .HasColumnName("isGenusAvailable")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsHeavyMetalAvailable)
                    .HasColumnName("isHeavyMetalAvailable")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsPackage)
                    .HasColumnName("isPackage")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LimitDoseForFreeOfHeavyMetal)
                    .HasColumnName("limitDoseForFreeOfHeavyMetal")
                    .HasColumnType("decimal(5,0)");

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.PriceGenusPerSample)
                    .HasColumnName("priceGenusPerSample")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.PriceHeavyMetalPerSample)
                    .HasColumnName("priceHeavyMetalPerSample")
                    .HasColumnType("decimal(12,2)");
            });

            modelBuilder.Entity<Customertbl>(entity =>
            {
                entity.HasKey(e => e.CustomerNo)
                    .HasName("PRIMARY");

                entity.ToTable("customertbl");

                entity.HasIndex(e => e.AccountNo)
                    .HasName("CustomerTblAccounttbl");

                entity.Property(e => e.CustomerNo)
                    .HasColumnName("customerNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountNo)
                    .HasColumnName("accountNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CompanyAddress).HasColumnName("companyAddress");

                entity.Property(e => e.CompanyEmail)
                    .HasColumnName("companyEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyPhone)
                    .HasColumnName("companyPhone")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customerEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customerName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.Customertbl)
                    .HasForeignKey(d => d.AccountNo)
                    .HasConstraintName("CustomerTblAccounttbl");
            });

            modelBuilder.Entity<Elementservicehistorytbl>(entity =>
            {
                entity.HasKey(e => e.ElementHistoryNo)
                    .HasName("PRIMARY");

                entity.ToTable("elementservicehistorytbl");

                entity.HasIndex(e => e.ElementId)
                    .HasName("ElementServiceHistoryTbltoElementServicesTbl");

                entity.Property(e => e.ElementHistoryNo)
                    .HasColumnName("elementHistoryNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActiveDate).HasColumnName("activeDate");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.ElementId)
                    .HasColumnName("elementId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExpiredDate).HasColumnName("expiredDate");

                entity.Property(e => e.ServiceRate)
                    .HasColumnName("serviceRate")
                    .HasColumnType("decimal(12,2)");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Elementservicehistorytbl)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ElementServiceHistoryTbltoElementServicesTbl");
            });

            modelBuilder.Entity<Elementservicestbl>(entity =>
            {
                entity.HasKey(e => e.Elementid)
                    .HasName("PRIMARY");

                entity.ToTable("elementservicestbl");

                entity.HasIndex(e => e.AnalysisTypeName)
                    .HasName("ElementServicesTbltoAnalysisTypeTbl");

                entity.Property(e => e.Elementid)
                    .HasColumnName("elementid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnalysisTypeName)
                    .IsRequired()
                    .HasColumnName("analysisTypeName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'General'");

                entity.Property(e => e.ComodityNo)
                    .HasColumnName("comodityNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.ElementCode)
                    .IsRequired()
                    .HasColumnName("elementCode")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ExtractionId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsMandatory)
                    .HasColumnName("isMandatory")
                    .HasMaxLength(1)
                    .IsFixedLength()
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.NotParameterProcess)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ServiceGroup)
                    .HasColumnName("serviceGroup")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceRate)
                    .HasColumnName("serviceRate")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.ServiceStatus)
                    .HasColumnName("serviceStatus")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SortedNo)
                    .HasColumnName("sortedNo")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ValueUnit)
                    .HasColumnName("valueUnit")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.AnalysisTypeNameNavigation)
                    .WithMany(p => p.Elementservicestbl)
                    .HasForeignKey(d => d.AnalysisTypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ElementServicesTbltoAnalysisTypeTbl");
            });

            modelBuilder.Entity<Employeetbl>(entity =>
            {
                entity.HasKey(e => e.EmployeeNo)
                    .HasName("PRIMARY");

                entity.ToTable("employeetbl");

                entity.HasIndex(e => e.AccountNo)
                    .HasName("EmployeeTblAccounttbl");

                entity.HasIndex(e => e.LaboratoriumId)
                    .HasName("EmployeeTblLaboratoriumTbl");

                entity.Property(e => e.EmployeeNo)
                    .HasColumnName("employeeNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountNo)
                    .HasColumnName("accountNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.DerivativeToEmployee)
                    .HasColumnName("derivativeToEmployee")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmployeeEmail)
                    .HasColumnName("employeeEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employeeName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LaboratoriumId)
                    .HasColumnName("laboratoriumID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.Employeetbl)
                    .HasForeignKey(d => d.AccountNo)
                    .HasConstraintName("EmployeeTblAccounttbl");

                entity.HasOne(d => d.Laboratorium)
                    .WithMany(p => p.Employeetbl)
                    .HasForeignKey(d => d.LaboratoriumId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("EmployeeTblLaboratoriumTbl");
            });

            modelBuilder.Entity<Genustbl>(entity =>
            {
                entity.HasKey(e => e.GenusId)
                    .HasName("PRIMARY");

                entity.ToTable("genustbl");

                entity.HasIndex(e => e.ComodityNo)
                    .HasName("GenusPerComodityTbltoComodityTbl");

                entity.Property(e => e.GenusId)
                    .HasColumnName("genusId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComodityNo)
                    .HasColumnName("comodityNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cost).HasColumnType("decimal(12,2)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.GenusName)
                    .IsRequired()
                    .HasColumnName("genusName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.HasOne(d => d.ComodityNoNavigation)
                    .WithMany(p => p.Genustbl)
                    .HasForeignKey(d => d.ComodityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GenusPerComodityTbltoComodityTbl");
            });

            modelBuilder.Entity<Laboratoriumtbl>(entity =>
            {
                entity.HasKey(e => e.LaboratoriumId)
                    .HasName("PRIMARY");

                entity.ToTable("laboratoriumtbl");

                entity.Property(e => e.LaboratoriumId)
                    .HasColumnName("laboratoriumID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LaboratoriumName)
                    .IsRequired()
                    .HasColumnName("laboratoriumName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LaboratoriumStatus)
                    .IsRequired()
                    .HasColumnName("laboratoriumStatus")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.LaboratoriumSymbol)
                    .HasColumnName("laboratoriumSymbol")
                    .HasMaxLength(3)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Logtbl>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("logtbl");

                entity.Property(e => e.LogId)
                    .HasColumnName("logId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MyAspnetApplications>(entity =>
            {
                entity.ToTable("my_aspnet_applications");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MyAspnetMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("my_aspnet_membership");

                entity.HasComment("2");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FailedPasswordAnswerAttemptCount).HasColumnType("int(10) unsigned");

                entity.Property(e => e.FailedPasswordAttemptCount).HasColumnType("int(10) unsigned");

                entity.Property(e => e.IsApproved).HasColumnType("tinyint(1)");

                entity.Property(e => e.IsLockedOut).HasColumnType("tinyint(1)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordAnswer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordFormat).HasColumnType("tinyint(4)");

                entity.Property(e => e.PasswordKey)
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.PasswordQuestion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MyAspnetPaths>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .HasName("PRIMARY");

                entity.ToTable("my_aspnet_paths");

                entity.Property(e => e.PathId)
                    .HasColumnName("pathId")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("applicationId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LoweredPath)
                    .IsRequired()
                    .HasColumnName("loweredPath")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MyAspnetPersonalizationallusers>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .HasName("PRIMARY");

                entity.ToTable("my_aspnet_personalizationallusers");

                entity.Property(e => e.PathId)
                    .HasColumnName("pathId")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnName("lastUpdatedDate");

                entity.Property(e => e.PageSettings)
                    .IsRequired()
                    .HasColumnName("pageSettings")
                    .HasColumnType("blob");
            });

            modelBuilder.Entity<MyAspnetPersonalizationperuser>(entity =>
            {
                entity.ToTable("my_aspnet_personalizationperuser");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("applicationId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("lastUpdatedDate");

                entity.Property(e => e.PageSettings)
                    .IsRequired()
                    .HasColumnName("pageSettings")
                    .HasColumnType("blob");

                entity.Property(e => e.PathId)
                    .HasColumnName("pathId")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MyAspnetProfiles>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("my_aspnet_profiles");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Binarydata)
                    .HasColumnName("binarydata")
                    .HasColumnType("longblob");

                entity.Property(e => e.LastUpdatedDate).HasColumnName("lastUpdatedDate");

                entity.Property(e => e.Stringdata)
                    .HasColumnName("stringdata")
                    .HasColumnType("longtext");

                entity.Property(e => e.Valueindex)
                    .HasColumnName("valueindex")
                    .HasColumnType("longtext");
            });

            modelBuilder.Entity<MyAspnetRoles>(entity =>
            {
                entity.ToTable("my_aspnet_roles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("applicationId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MyAspnetSchemaversion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("my_aspnet_schemaversion");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MyAspnetSessioncleanup>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("PRIMARY");

                entity.ToTable("my_aspnet_sessioncleanup");

                entity.Property(e => e.ApplicationId).HasColumnType("int(11)");

                entity.Property(e => e.IntervalMinutes).HasColumnType("int(11)");
            });

            modelBuilder.Entity<MyAspnetSessions>(entity =>
            {
                entity.HasKey(e => new { e.SessionId, e.ApplicationId })
                    .HasName("PRIMARY");

                entity.ToTable("my_aspnet_sessions");

                entity.Property(e => e.SessionId)
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationId).HasColumnType("int(11)");

                entity.Property(e => e.Flags).HasColumnType("int(11)");

                entity.Property(e => e.LockId).HasColumnType("int(11)");

                entity.Property(e => e.Locked).HasColumnType("tinyint(1)");

                entity.Property(e => e.SessionItems).HasColumnType("longblob");

                entity.Property(e => e.Timeout).HasColumnType("int(11)");
            });

            modelBuilder.Entity<MyAspnetSitemap>(entity =>
            {
                entity.ToTable("my_aspnet_sitemap");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnType("int(11)");

                entity.Property(e => e.Roles)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MyAspnetUsers>(entity =>
            {
                entity.ToTable("my_aspnet_users");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("applicationId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsAnonymous)
                    .HasColumnName("isAnonymous")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LastActivityDate).HasColumnName("lastActivityDate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MyAspnetUsersinroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("my_aspnet_usersinroles");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MysqlMembership>(entity =>
            {
                entity.HasKey(e => e.Pkid)
                    .HasName("PRIMARY");

                entity.ToTable("mysql_membership");

                entity.HasComment("2");

                entity.Property(e => e.Pkid)
                    .HasColumnName("PKID")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.FailedPasswordAnswerAttemptCount).HasColumnType("int(10) unsigned");

                entity.Property(e => e.FailedPasswordAttemptCount).HasColumnType("int(10) unsigned");

                entity.Property(e => e.IsApproved).HasColumnType("tinyint(1)");

                entity.Property(e => e.IsLockedOut).HasColumnType("tinyint(1)");

                entity.Property(e => e.IsOnline).HasColumnType("tinyint(1)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordAnswer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordFormat).HasColumnType("tinyint(4)");

                entity.Property(e => e.PasswordKey)
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.PasswordQuestion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orderanalysisdetailtbl>(entity =>
            {
                entity.HasKey(e => e.OrderDetailNo)
                    .HasName("PRIMARY");

                entity.ToTable("orderanalysisdetailtbl");

                entity.HasIndex(e => e.ElementId)
                    .HasName("OrderAnalysisDetailTbltoElementServicesTbl");

                entity.HasIndex(e => e.OrderNo)
                    .HasName("OrderAnalysisDetailTbltoOrderMaster");

                entity.HasIndex(e => e.ParametersNo)
                    .HasName("OrderAnalysisDetailTbltoParametersTbl");

                entity.HasIndex(e => e.Pic)
                    .HasName("OrderAnalysisDetailTbltoEmployeeTbl");

                entity.HasIndex(e => e.SampleNo)
                    .HasName("OrderAnalysisDetailTbltoOrderSampleTbl");

                entity.Property(e => e.OrderDetailNo)
                    .HasColumnName("orderDetailNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.ElementId)
                    .HasColumnName("elementId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ElementValue)
                    .HasColumnName("elementValue")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FileAttachmentUrl).HasColumnName("fileAttachmentUrl");

                entity.Property(e => e.FileName)
                    .HasColumnName("fileName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LabToolFileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasColumnName("orderNo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParametersNo)
                    .HasColumnName("parametersNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pic)
                    .HasColumnName("pic")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Recalculate)
                    .HasColumnName("recalculate")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.SampleNo)
                    .IsRequired()
                    .HasColumnName("sampleNo")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Orderanalysisdetailtbl)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderAnalysisDetailTbltoElementServicesTbl");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Orderanalysisdetailtbl)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderAnalysisDetailTbltoOrderMaster");

                entity.HasOne(d => d.ParametersNoNavigation)
                    .WithMany(p => p.Orderanalysisdetailtbl)
                    .HasForeignKey(d => d.ParametersNo)
                    .HasConstraintName("OrderAnalysisDetailTbltoParametersTbl");

                entity.HasOne(d => d.PicNavigation)
                    .WithMany(p => p.Orderanalysisdetailtbl)
                    .HasForeignKey(d => d.Pic)
                    .HasConstraintName("OrderAnalysisDetailTbltoEmployeeTbl");

                entity.HasOne(d => d.SampleNoNavigation)
                    .WithMany(p => p.Orderanalysisdetailtbl)
                    .HasForeignKey(d => d.SampleNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderAnalysisDetailTbltoOrderSampleTbl");
            });

            modelBuilder.Entity<Ordermastertbl>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("PRIMARY");

                entity.ToTable("ordermastertbl");

                entity.HasIndex(e => e.AnalysisType)
                    .HasName("OrderMasterTbltoAnalysisTypeTbl");

                entity.HasIndex(e => e.BatchId)
                    .HasName("FK_ordermastertbl_batchtbl");

                entity.HasIndex(e => e.ComodityNo)
                    .HasName("OrderMasterTbltoComodityTbl");

                entity.HasIndex(e => e.CustomerNo)
                    .HasName("OrderMasterTbltoCustomerTbl");

                entity.HasIndex(e => e.Pic)
                    .HasName("OrderMasterTbltoEmployeeTbl");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("orderNo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalPrice1)
                    .HasColumnName("additionalPrice1")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.AdditionalPrice2)
                    .HasColumnName("additionalPrice2")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.AdditionalPriceRemark)
                    .HasColumnName("additionalPriceRemark")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.AnalysisType)
                    .HasColumnName("analysisType")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ApprEvaluator)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ApprManagerTeknis)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ApprPenyelia)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CalculationFilename)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComodityNo)
                    .HasColumnName("comodityNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.CustomerNo)
                    .HasColumnName("customerNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DosePerHectare)
                    .HasColumnName("dosePerHectare")
                    .HasColumnType("decimal(5,0)");

                entity.Property(e => e.EvaluationFileName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsOnLab)
                    .HasColumnName("isOnLab")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsPaid)
                    .IsRequired()
                    .HasColumnName("isPaid")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsRecalculate)
                    .HasColumnName("isRecalculate")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsReviewing)
                    .HasColumnName("isReviewing")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.LhpattachmentUrl).HasColumnName("LHPAttachmentUrl");

                entity.Property(e => e.LhpfileName)
                    .HasColumnName("LHPFileName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.PackageName)
                    .HasColumnName("packageName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentDate).HasColumnName("paymentDate");

                entity.Property(e => e.PaymentStatus)
                    .HasColumnName("paymentStatus")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pic)
                    .HasColumnName("pic")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ppn)
                    .HasColumnName("ppn")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.PriceTotal)
                    .HasColumnName("priceTotal")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.ReceiptDate).HasColumnName("receiptDate");

                entity.Property(e => e.SampleTotal)
                    .HasColumnName("sampleTotal")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusType)
                    .HasColumnName("statusType")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TotalGenus)
                    .HasColumnName("totalGenus")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.AnalysisTypeNavigation)
                    .WithMany(p => p.Ordermastertbl)
                    .HasForeignKey(d => d.AnalysisType)
                    .HasConstraintName("OrderMasterTbltoAnalysisTypeTbl");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.Ordermastertbl)
                    .HasForeignKey(d => d.BatchId)
                    .HasConstraintName("FK_ordermastertbl_batchtbl");

                entity.HasOne(d => d.ComodityNoNavigation)
                    .WithMany(p => p.Ordermastertbl)
                    .HasForeignKey(d => d.ComodityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderMasterTbltoComodityTbl");

                entity.HasOne(d => d.CustomerNoNavigation)
                    .WithMany(p => p.Ordermastertbl)
                    .HasForeignKey(d => d.CustomerNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderMasterTbltoCustomerTbl");

                entity.HasOne(d => d.PicNavigation)
                    .WithMany(p => p.Ordermastertbl)
                    .HasForeignKey(d => d.Pic)
                    .HasConstraintName("OrderMasterTbltoEmployeeTbl");
            });

            modelBuilder.Entity<Ordernavigationtbl>(entity =>
            {
                entity.ToTable("ordernavigationtbl");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommodityNo)
                    .HasColumnName("commodityNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsLeaf)
                    .IsRequired()
                    .HasColumnName("isLeaf")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsVisible)
                    .IsRequired()
                    .HasColumnName("isVisible")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("orderNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentId")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Orderpricedetailtbl>(entity =>
            {
                entity.HasKey(e => e.OrderPriceDetailNo)
                    .HasName("PRIMARY");

                entity.ToTable("orderpricedetailtbl");

                entity.HasIndex(e => e.ElementId)
                    .HasName("OrderPriceDetailtoElementServicesTbl");

                entity.HasIndex(e => e.OrderNo)
                    .HasName("OrderPriceDetailTbltoOrderMasterTbl");

                entity.Property(e => e.OrderPriceDetailNo)
                    .HasColumnName("orderPriceDetailNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ElementId)
                    .HasColumnName("elementId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderNo)
                    .HasColumnName("orderNo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(22,2)");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Orderpricedetailtbl)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("OrderPriceDetailtoElementServicesTbl");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Orderpricedetailtbl)
                    .HasForeignKey(d => d.OrderNo)
                    .HasConstraintName("OrderPriceDetailTbltoOrderMasterTbl");
            });

            modelBuilder.Entity<Ordersampletbl>(entity =>
            {
                entity.HasKey(e => e.NoBalittanah)
                    .HasName("PRIMARY");

                entity.ToTable("ordersampletbl");

                entity.HasIndex(e => e.OrderNo)
                    .HasName("OrderSampleTbltoOrderMasterTbl");

                entity.Property(e => e.NoBalittanah)
                    .HasColumnName("noBalittanah")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CountNumber)
                    .HasColumnName("countNumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsReceived)
                    .HasColumnName("isReceived")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.LandUse)
                    .HasColumnName("landUse")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasColumnName("orderNo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SampleCode)
                    .IsRequired()
                    .HasColumnName("sampleCode")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SampleDescription).HasColumnName("sampleDescription");

                entity.Property(e => e.SamplingDate).HasColumnName("samplingDate");

                entity.Property(e => e.SubDistrict)
                    .HasColumnName("subDistrict")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Village)
                    .HasColumnName("village")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Ordersampletbl)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderSampleTbltoOrderMasterTbl");
            });

            modelBuilder.Entity<Packagedetailtbl>(entity =>
            {
                entity.HasKey(e => e.PackageDetailTbl1)
                    .HasName("PRIMARY");

                entity.ToTable("packagedetailtbl");

                entity.HasIndex(e => e.ElementId)
                    .HasName("PackageDetailTbltoElementServicesTbl");

                entity.HasIndex(e => e.PackageName)
                    .HasName("PackageDetailTbltoPackageTbl");

                entity.Property(e => e.PackageDetailTbl1)
                    .HasColumnName("PackageDetailTbl")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Compulsive)
                    .HasColumnName("compulsive")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ElementId)
                    .HasColumnName("elementId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PackageName)
                    .HasColumnName("packageName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Packagedetailtbl)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("PackageDetailTbltoElementServicesTbl");

                entity.HasOne(d => d.PackageNameNavigation)
                    .WithMany(p => p.Packagedetailtbl)
                    .HasForeignKey(d => d.PackageName)
                    .HasConstraintName("PackageDetailTbltoPackageTbl");
            });

            modelBuilder.Entity<Packagetbl>(entity =>
            {
                entity.HasKey(e => e.PackageName)
                    .HasName("PRIMARY");

                entity.ToTable("packagetbl");

                entity.HasIndex(e => e.AnalysisTypeName)
                    .HasName("PackageTbltoAnalysisTypeTbl");

                entity.HasIndex(e => e.ComodityNo)
                    .HasName("PackageTbltoComodityTbl");

                entity.Property(e => e.PackageName)
                    .HasColumnName("packageName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalPrice1)
                    .HasColumnName("additionalPrice1")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.AdditionalPrice2)
                    .HasColumnName("additionalPrice2")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.AdditionalPriceDesc1)
                    .HasColumnName("additionalPriceDesc1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalPriceDesc2)
                    .HasColumnName("additionalPriceDesc2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AnalysisTypeName)
                    .HasColumnName("analysisTypeName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BundlePrice)
                    .HasColumnName("bundlePrice")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.ComodityNo)
                    .HasColumnName("comodityNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MultipleSelectedItem)
                    .HasColumnName("multipleSelectedItem")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.HasOne(d => d.AnalysisTypeNameNavigation)
                    .WithMany(p => p.Packagetbl)
                    .HasForeignKey(d => d.AnalysisTypeName)
                    .HasConstraintName("PackageTbltoAnalysisTypeTbl");

                entity.HasOne(d => d.ComodityNoNavigation)
                    .WithMany(p => p.Packagetbl)
                    .HasForeignKey(d => d.ComodityNo)
                    .HasConstraintName("PackageTbltoComodityTbl");
            });

            modelBuilder.Entity<Parameterstbl>(entity =>
            {
                entity.HasKey(e => e.ParametersNo)
                    .HasName("PRIMARY");

                entity.ToTable("parameterstbl");

                entity.Property(e => e.ParametersNo)
                    .HasColumnName("parametersNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.String0)
                    .HasColumnName("string0")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.String1)
                    .HasColumnName("string1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.String2)
                    .HasColumnName("string2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.String3)
                    .HasColumnName("string3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.String4)
                    .HasColumnName("string4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.String5)
                    .HasColumnName("string5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.String6)
                    .HasColumnName("string6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.String7)
                    .HasColumnName("string7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.String8)
                    .HasColumnName("string8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.String9)
                    .HasColumnName("string9")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paymenttbl>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PRIMARY");

                entity.ToTable("paymenttbl");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("paymentId")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AccountName)
                    .HasColumnName("accountName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNo)
                    .HasColumnName("accountNo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(12,2)");

                entity.Property(e => e.AttachmentUrl)
                    .HasColumnName("attachmentUrl")
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasColumnName("bankName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNo)
                    .HasColumnName("orderNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentReceiptUrl)
                    .HasColumnName("paymentReceiptUrl")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Resulttbl>(entity =>
            {
                entity.HasKey(e => e.ResultNo)
                    .HasName("PRIMARY");

                entity.ToTable("resulttbl");

                entity.HasIndex(e => e.OrderNo)
                    .HasName("ResultTbltoOrderMasterTbl");

                entity.HasIndex(e => e.ReviewingNo)
                    .HasName("ResultTbltoReviewingTbl");

                entity.Property(e => e.ResultNo)
                    .HasColumnName("resultNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.FileName)
                    .HasColumnName("fileName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasColumnName("orderNo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewingNo)
                    .HasColumnName("reviewingNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Resulttbl)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ResultTbltoOrderMasterTbl");

                entity.HasOne(d => d.ReviewingNoNavigation)
                    .WithMany(p => p.Resulttbl)
                    .HasForeignKey(d => d.ReviewingNo)
                    .HasConstraintName("ResultTbltoReviewingTbl");
            });

            modelBuilder.Entity<Reviewingtbl>(entity =>
            {
                entity.HasKey(e => e.ReviewingNo)
                    .HasName("PRIMARY");

                entity.ToTable("reviewingtbl");

                entity.Property(e => e.ReviewingNo)
                    .HasColumnName("reviewingNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.ElementCodeList).HasColumnName("elementCodeList");

                entity.Property(e => e.IsChemicalMaterialSurfficent)
                    .HasColumnName("isChemicalMaterialSurfficent")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsHumanResourceSurfficient)
                    .HasColumnName("isHumanResourceSurfficient")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsLabUtilitySurfficient)
                    .HasColumnName("isLabUtilitySurfficient")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsMethode)
                    .HasColumnName("isMethode")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsQualityStandard)
                    .HasColumnName("isQualityStandard")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.IsVolumeCorrect)
                    .HasColumnName("isVolumeCorrect")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.OrderNo)
                    .IsRequired()
                    .HasColumnName("orderNo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewingDate).HasColumnName("reviewingDate");

                entity.Property(e => e.Workdays)
                    .HasColumnName("workdays")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Roletbl>(entity =>
            {
                entity.HasKey(e => e.RoleName)
                    .HasName("PRIMARY");

                entity.ToTable("roletbl");

                entity.Property(e => e.RoleName)
                    .HasColumnName("roleName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");
            });

            modelBuilder.Entity<Sampletypetbl>(entity =>
            {
                entity.HasKey(e => e.TypeName)
                    .HasName("PRIMARY");

                entity.ToTable("sampletypetbl");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeStatus)
                    .HasColumnName("typeStatus")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.TypeSymbol)
                    .HasColumnName("typeSymbol")
                    .HasMaxLength(3)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Standarddetailtbl>(entity =>
            {
                entity.HasKey(e => e.StdDetailId)
                    .HasName("PRIMARY");

                entity.ToTable("standarddetailtbl");

                entity.HasIndex(e => e.ElementId)
                    .HasName("StandardDetailTbltoElementServicesTbl");

                entity.HasIndex(e => e.StdId)
                    .HasName("StandardDetailTbltoStandardTbl");

                entity.Property(e => e.StdDetailId)
                    .HasColumnName("stdDetailId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.ElementId)
                    .HasColumnName("elementId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.StdId)
                    .HasColumnName("stdId")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Standarddetailtbl)
                    .HasForeignKey(d => d.ElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StandardDetailTbltoElementServicesTbl");

                entity.HasOne(d => d.Std)
                    .WithMany(p => p.Standarddetailtbl)
                    .HasForeignKey(d => d.StdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StandardDetailTbltoStandardTbl");
            });

            modelBuilder.Entity<Standardtbl>(entity =>
            {
                entity.HasKey(e => e.StdId)
                    .HasName("PRIMARY");

                entity.ToTable("standardtbl");

                entity.HasIndex(e => e.ComodityNo)
                    .HasName("StandartdTbltoComodityTbl");

                entity.Property(e => e.StdId)
                    .HasColumnName("stdId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComodityNo)
                    .HasColumnName("comodityNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.ModBy)
                    .HasColumnName("modBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnName("modDate");

                entity.Property(e => e.StdNo)
                    .IsRequired()
                    .HasColumnName("stdNo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ComodityNoNavigation)
                    .WithMany(p => p.Standardtbl)
                    .HasForeignKey(d => d.ComodityNo)
                    .HasConstraintName("StandartdTbltoComodityTbl");
            });

            modelBuilder.Entity<Workflowlogtbl>(entity =>
            {
                entity.HasKey(e => e.WorkflowLogNo)
                    .HasName("PRIMARY");

                entity.ToTable("workflowlogtbl");

                entity.Property(e => e.WorkflowLogNo)
                    .HasColumnName("workflowLogNo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreaBy)
                    .HasColumnName("creaBy")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreaDate).HasColumnName("creaDate");

                entity.Property(e => e.LastStatus)
                    .HasColumnName("lastStatus")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceNo)
                    .IsRequired()
                    .HasColumnName("resourceNo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Task)
                    .HasColumnName("task")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDesctiption).HasColumnName("taskDesctiption");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
