namespace BlazorWasmSQLiteTest;

public class ClientSideDbContext : DbContext
{
    public ClientSideDbContext(DbContextOptions<ClientSideDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Todo>().HasData(new Todo[]
        {
            new Todo { Id = 1, Title = "Todo 1", IsComplete = false },
            new Todo { Id = 2, Title = "Todo 2", IsComplete = false },
            new Todo { Id = 3, Title = "Todo 3", IsComplete = false },
        });
    }

    public virtual DbSet<Todo> Todos { get; set; } = default!;
}
