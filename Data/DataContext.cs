using maldeaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace maldeaBackend.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Reader> Readers { get; set; }
}