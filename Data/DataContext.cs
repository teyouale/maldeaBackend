using maldeaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace maldeaBackend.Data;

public class DataContext:DbContext
{
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Company> Companys { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { set; get; }
    public DbSet<Reader> Readers { get; set; }

    
    public DbSet<History> History { get; set; }
    
    public DbSet<Newspaper> Newspapers { get; set; }
    
    public DbSet<Subscription> Subscriptions { get; set; }
    
}