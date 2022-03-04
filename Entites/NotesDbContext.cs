using Microsoft.EntityFrameworkCore;

namespace PrivateNotes.Entites;

public class NotesDbContext : DbContext
{
    public NotesDbContext(DbContextOptions<NotesDbContext> options)
        :base(options)
    {
    }
    
    public DbSet<Note> Notes { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email");

            entity.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password");
        });
        
        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("note");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.Content)
                .IsRequired()
                .HasColumnName("content");

            entity.Property(e => e.CreationDate)
                .IsRequired()
                .HasDefaultValueSql("now()")
                .HasColumnName("creation_date");
            
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id");
            
            entity.HasOne(p => p.User)
                .WithMany(b => b.Notes)
                .HasForeignKey(p => p.UserId);
        });

    }
}