using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpecialPrograms2Core.Models;
using SpecialPrograms2Core.Models;

namespace SpecialPrograms2Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<ErrorViewModel> ErrorViewModels { get; set; }
        public DbSet<SpecialHalqa> SpecialHalqas { get; set; }
        public DbSet<SpecialStudentEvaluation> SpecialStudentEvaluations { get; set; }
        public DbSet<SpecialHalqatStudent> SpecialHalqatStudents { get; set; }
        public DbSet<SpecialStudent> SpecialStudents { get; set; }
        public DbSet<SpecialHalqatTeacher> SpecialHalqatTeachers { get; set; }
        public DbSet<HalqaAuditLog> HalqaAuditLogs { get; set; }
        public DbSet<HalqaProgram> HalqaPrograms { get; set; }
        public DbSet<SessionTime> SessionTimes { get; set; }
        public DbSet<SessionType> SessionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // تكوينات إضافية إذا كانت هناك حاجة
        }
    }
}