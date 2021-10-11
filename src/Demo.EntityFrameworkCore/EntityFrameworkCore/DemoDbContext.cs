using Demo.Authors;
using Demo.Books;
using Demo.Borrowers;
using Demo.Students;
using Demo.MeetingInspector;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Demo.MeetingParticipent;
using Demo.CivitMeetings;
using Demo.InspectSchMeetings;
using Demo.InspectMasterCategory;

namespace Demo.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class DemoDbContext : 
        AbpDbContext<DemoDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */
        
        #region Entities from the modules
        
        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */
        
        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        
        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion
        
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<MeetingInspectors> meetingInspectors { get; set; }
        public DbSet<MeetingParticipents> meetingParticipents { get; set; }
        public DbSet<CivitMeeting> civitMeetings { get; set; }
        public DbSet<InspectSchMeeting> IspectSchMeeting { get; set; }
        public DbSet<InspectProjHead> InspectProjHead { get; set; }
        public DbSet<InspectSchVirtualMeetInfo> InspectSchVirtualMeetInfo { get; set; }
        public DbSet<InspectMstCategory> InspectMstCategory { get; set; }
  


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(DemoConsts.DbTablePrefix + "YourEntities", DemoConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<Book>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "Books",
                    DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
                b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
            });
            builder.Entity<Author>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "Authors",
                    DemoConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(AuthorConsts.MaxNameLength);

                b.HasIndex(x => x.Name);
            });
            builder.Entity<Student>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "Students",
                    DemoConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(StudentConsts.MaxNameLength);

                b.Property(x => x.Email)
                    .IsRequired();
                b.Property(x => x.Class)
                    .IsRequired();
                //b.HasIndex(x => x.Name);
                b.HasOne<Book>().WithMany().HasForeignKey(x => x.BookId);
            });
            builder.Entity<Borrow>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "Borrow",
                    DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //b.Property(x => x.Name).IsRequired().HasMaxLength(128);
                b.HasOne<Book>().WithMany().HasForeignKey(x => x.BookID);
                b.HasOne<Student>().WithMany().HasForeignKey(x => x.StudentID);
                b.Property(x => x.Duration)
                    .IsRequired();
                b.Property(x => x.Price)
                    .IsRequired();
            });

            builder.Entity<MeetingInspectors>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "MeetingInspectors",
                    DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.InspectorId);
                b.Property(x => x.Name).IsRequired();
                b.Property(x => x.MeetingId).IsRequired();

            });
            builder.Entity<CivitMeeting>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "CivitMeeting",
                    DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.OrgID).HasMaxLength(4);
                b.Property(x => x.Subject);
                b.Property(x => x.Description);
                b.Property(x => x.MeetingMode).HasMaxLength(4);
                b.Property(x => x.Meetinginvitation);
                b.Property(x => x.SlotDate);
                b.Property(x => x.SlotStart);
                b.Property(x => x.SlotEnd);
                b.Property(x => x.ScheduleStatus).HasMaxLength(3);
                b.Property(x => x.Compliancestatus).HasMaxLength(2);
                b.Property(x => x.IsCanceled);
                b.Property(x => x.CanceledById);
                b.Property(x => x.Description);
                b.Property(x => x.CancelationReason);
                //b.HasMany(x => x.meetingParticipents).WithOne(x => x.CivitMeeting).HasForeignKey(x => x.MeetingID).IsRequired();
            });
            builder.Entity<MeetingParticipents>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "MeetingParticipents",
                    DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.ParticipentID);
                b.Property(x => x.Name);
                b.Property(x => x.Email).HasMaxLength(50);
                b.Property(x => x.Mobile).HasMaxLength(20);
                b.HasOne<CivitMeeting>(c => c.CivitMeeting).WithMany(x => x.MeetingParticipents).HasForeignKey(x => x.MeetingID).IsRequired();
            });
            builder.Entity<InspectSchMeeting>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "InspectSchMeeting",
                    DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.InsProjHeadID).HasMaxLength(4);
                //b.Property(x => x.MeetingMode).HasMaxLength(4);
                b.Property(x => x.MeetingDate);
                b.Property(x => x.SlotStart);
                b.Property(x => x.SlotEnd);
                b.Property(x => x.MeetingStatus);
                b.HasOne(a => a.InspectSchVirtualMeetInfo)
    .WithOne(a => a.InspectSchMeeting)
    .HasForeignKey<InspectSchVirtualMeetInfo>(c => c.InspectSchID);

                //              b.HasOne<InspectProjHead>(c => c.InspectProjHead).WithOne(ad => ad.InspectSchMeeting)
                //.HasForeignKey<InspectSchMeeting>(ad => ad.InsProjHeadID);

            });
            builder.Entity<InspectProjHead>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "InspectProjHead",
                    DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props                
                b.Property(x => x.OrgID).HasMaxLength(4);
                b.Property(x => x.ProjectID).HasMaxLength(4);
                b.Property(x => x.InspectSeqNum);
                b.Property(x => x.Status);         
     b.HasOne(a => a.InspectSchMeeting)
     .WithOne(a => a.InspectProjHead)
     .HasForeignKey<InspectSchMeeting>(c => c.InsProjHeadID);


            });
            builder.Entity<InspectSchVirtualMeetInfo>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "InspectSchVirtualMeetInfo",
                    DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.InspectSchID).IsRequired();
                b.Property(x => x.VirtualMeetApp);
                b.Property(x => x.MeetingLink).HasMaxLength(200);
   
            });
            builder.Entity<InspectMstCategory>(b =>
            {
                b.ToTable(DemoConsts.DbTablePrefix + "InspectMstCategory",
                    DemoConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.OrgID).IsRequired();
                b.Property(x => x.InspectCatIdnCode);
                b.Property(x => x.PermitIdnCode);
                b.Property(x => x.AppTypeIdnCode);
                b.Property(x => x.ChkFormID);
            });

            //        builder.Entity<InspectProjHead>()
            //.HasOne<InspectSchMeeting>(s => s.InspectSchMeeting)
            //.WithOne(ad => ad.InspectProjHead)
            //.HasForeignKey<InspectSchMeeting>(ad => ad.InsProjHeadID);
        }
    }
}
