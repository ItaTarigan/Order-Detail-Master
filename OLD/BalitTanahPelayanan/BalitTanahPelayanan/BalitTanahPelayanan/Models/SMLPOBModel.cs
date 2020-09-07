namespace BalitTanahPelayanan.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SMLPOBModel : DbContext
    {
        public SMLPOBModel()
            : base("name=SMLPOBModels")
        {
        }

        public virtual DbSet<accounttbl> accounttbls { get; set; }
        public virtual DbSet<analysistypetbl> analysistypetbls { get; set; }
        public virtual DbSet<comoditytbl> comoditytbls { get; set; }
        public virtual DbSet<customertbl> customertbls { get; set; }
        public virtual DbSet<elementservicestbl> elementservicestbls { get; set; }
        public virtual DbSet<employeetbl> employeetbls { get; set; }
        public virtual DbSet<fileattachmenttbl> fileattachmenttbls { get; set; }
        public virtual DbSet<logtbl> logtbls { get; set; }
        public virtual DbSet<orderdetailtbl> orderdetailtbls { get; set; }
        public virtual DbSet<ordermastertbl> ordermastertbls { get; set; }
        public virtual DbSet<parameterstbl> parameterstbls { get; set; }
        public virtual DbSet<resulttbl> resulttbls { get; set; }
        public virtual DbSet<roletbl> roletbls { get; set; }
        public virtual DbSet<sampletbl> sampletbls { get; set; }
        public virtual DbSet<standarddetailtbl> standarddetailtbls { get; set; }
        public virtual DbSet<standardtbl> standardtbls { get; set; }
        public virtual DbSet<workflowlogtbl> workflowlogtbls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<accounttbl>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<accounttbl>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<accounttbl>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<accounttbl>()
                .Property(e => e.isEmailVerified)
                .IsUnicode(false);

            modelBuilder.Entity<accounttbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<accounttbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<analysistypetbl>()
                .Property(e => e.analysisTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<analysistypetbl>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<analysistypetbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<analysistypetbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<analysistypetbl>()
                .HasMany(e => e.elementservicestbls)
                .WithRequired(e => e.analysistypetbl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<comoditytbl>()
                .Property(e => e.comodityName)
                .IsUnicode(false);

            modelBuilder.Entity<comoditytbl>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<comoditytbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<comoditytbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<comoditytbl>()
                .HasMany(e => e.ordermastertbls)
                .WithRequired(e => e.comoditytbl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customertbl>()
                .Property(e => e.customerName)
                .IsUnicode(false);

            modelBuilder.Entity<customertbl>()
                .Property(e => e.customerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<customertbl>()
                .Property(e => e.companyName)
                .IsUnicode(false);

            modelBuilder.Entity<customertbl>()
                .Property(e => e.companyAddress)
                .IsUnicode(false);

            modelBuilder.Entity<customertbl>()
                .Property(e => e.companyPhone)
                .IsUnicode(false);

            modelBuilder.Entity<customertbl>()
                .Property(e => e.companyEmail)
                .IsUnicode(false);

            modelBuilder.Entity<customertbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<customertbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<customertbl>()
                .HasMany(e => e.ordermastertbls)
                .WithRequired(e => e.customertbl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<elementservicestbl>()
                .Property(e => e.elementCode)
                .IsUnicode(false);

            modelBuilder.Entity<elementservicestbl>()
                .Property(e => e.analysisTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<elementservicestbl>()
                .Property(e => e.serviceGroup)
                .IsUnicode(false);

            modelBuilder.Entity<elementservicestbl>()
                .Property(e => e.serviceStatus)
                .IsUnicode(false);

            modelBuilder.Entity<elementservicestbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<elementservicestbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<elementservicestbl>()
                .HasMany(e => e.orderdetailtbls)
                .WithRequired(e => e.elementservicestbl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<elementservicestbl>()
                .HasMany(e => e.standarddetailtbls)
                .WithRequired(e => e.elementservicestbl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employeetbl>()
                .Property(e => e.employeeName)
                .IsUnicode(false);

            modelBuilder.Entity<employeetbl>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<employeetbl>()
                .Property(e => e.employeeEmail)
                .IsUnicode(false);

            modelBuilder.Entity<employeetbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<employeetbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<employeetbl>()
                .HasMany(e => e.orderdetailtbls)
                .WithOptional(e => e.employeetbl)
                .HasForeignKey(e => e.pic);

            modelBuilder.Entity<employeetbl>()
                .HasMany(e => e.ordermastertbls)
                .WithOptional(e => e.employeetbl)
                .HasForeignKey(e => e.pic);

            modelBuilder.Entity<fileattachmenttbl>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<fileattachmenttbl>()
                .Property(e => e.fileName)
                .IsUnicode(false);

            modelBuilder.Entity<fileattachmenttbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<logtbl>()
                .Property(e => e.source)
                .IsUnicode(false);

            modelBuilder.Entity<logtbl>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<logtbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<orderdetailtbl>()
                .Property(e => e.sampleNo)
                .IsUnicode(false);

            modelBuilder.Entity<orderdetailtbl>()
                .Property(e => e.elementCode)
                .IsUnicode(false);

            modelBuilder.Entity<orderdetailtbl>()
                .Property(e => e.elementValue)
                .IsUnicode(false);

            modelBuilder.Entity<orderdetailtbl>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<orderdetailtbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<orderdetailtbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<orderdetailtbl>()
                .HasMany(e => e.fileattachmenttbls)
                .WithRequired(e => e.orderdetailtbl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ordermastertbl>()
                .Property(e => e.orderNo)
                .IsUnicode(false);

            modelBuilder.Entity<ordermastertbl>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<ordermastertbl>()
                .Property(e => e.isPayed)
                .IsUnicode(false);

            modelBuilder.Entity<ordermastertbl>()
                .Property(e => e.isAppr)
                .IsUnicode(false);

            modelBuilder.Entity<ordermastertbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<ordermastertbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<ordermastertbl>()
                .HasMany(e => e.resulttbls)
                .WithRequired(e => e.ordermastertbl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ordermastertbl>()
                .HasMany(e => e.sampletbls)
                .WithRequired(e => e.ordermastertbl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.string0)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.string1)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.string2)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.string3)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.string4)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.string5)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.string6)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.string7)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.string8)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.srting9)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<parameterstbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<resulttbl>()
                .Property(e => e.orderNo)
                .IsUnicode(false);

            modelBuilder.Entity<resulttbl>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<resulttbl>()
                .Property(e => e.fileName)
                .IsUnicode(false);

            modelBuilder.Entity<resulttbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<resulttbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<roletbl>()
                .Property(e => e.roleName)
                .IsUnicode(false);

            modelBuilder.Entity<roletbl>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<roletbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<roletbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.noBalittanah)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.orderNo)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.sampleCode)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.sampleDescription)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.village)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.subDistrict)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.district)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.provice)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.gpsCoordeinate)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .Property(e => e.isReceived)
                .IsUnicode(false);

            modelBuilder.Entity<sampletbl>()
                .HasMany(e => e.orderdetailtbls)
                .WithRequired(e => e.sampletbl)
                .HasForeignKey(e => e.sampleNo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<standarddetailtbl>()
                .Property(e => e.elementCode)
                .IsUnicode(false);

            modelBuilder.Entity<standarddetailtbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<standarddetailtbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<standardtbl>()
                .Property(e => e.stdNo)
                .IsUnicode(false);

            modelBuilder.Entity<standardtbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);

            modelBuilder.Entity<standardtbl>()
                .Property(e => e.modBy)
                .IsUnicode(false);

            modelBuilder.Entity<standardtbl>()
                .HasMany(e => e.standarddetailtbls)
                .WithRequired(e => e.standardtbl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<workflowlogtbl>()
                .Property(e => e.resourceNo)
                .IsUnicode(false);

            modelBuilder.Entity<workflowlogtbl>()
                .Property(e => e.task)
                .IsUnicode(false);

            modelBuilder.Entity<workflowlogtbl>()
                .Property(e => e.taskDesctiption)
                .IsUnicode(false);

            modelBuilder.Entity<workflowlogtbl>()
                .Property(e => e.lastStatus)
                .IsUnicode(false);

            modelBuilder.Entity<workflowlogtbl>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<workflowlogtbl>()
                .Property(e => e.creaBy)
                .IsUnicode(false);
        }
    }
}
