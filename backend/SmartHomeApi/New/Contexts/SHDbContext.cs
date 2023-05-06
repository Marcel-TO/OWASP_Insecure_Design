using Microsoft.EntityFrameworkCore;
using SmartHomeApi.New.Models;
namespace SmartHomeApi.New.Contexts;

 public class SHDbContext : DbContext
 {
    public SHDbContext(DbContextOptions options):base(options){}

    public DbSet<Account> Accounts{get;set;}
 }