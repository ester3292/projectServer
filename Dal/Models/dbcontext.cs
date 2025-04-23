using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<MarksForStudent> MarksForStudents { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\תיקייה כללית חדש\\שנה ב תשפה\\קבוצה א\\תלמידות\\00000000 Esty & Chaya\\Final Project\\Diploma.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Classes__A25C5AA601F47218");

            entity.Property(e => e.Name)
                .HasMaxLength(4)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<MarksForStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0737E02E47");

            entity.Property(e => e.Notes)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Subject)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Student).WithMany(p => p.MarksForStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Marks_ToTable");

            entity.HasOne(d => d.Teacher).WithMany(p => p.MarksForStudents)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK_MarksForStudents_ToTable");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC076D12713F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Class).HasColumnName("class");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");

            entity.HasOne(d => d.ClassNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.Class)
                .HasConstraintName("FK_Students_ToTable");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC07AEFB3DB5");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Educator).HasColumnName("educator");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
