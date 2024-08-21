using EmployeeManageProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManageProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    }
}
