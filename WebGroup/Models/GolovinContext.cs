using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebGroup.Models
{
    public partial class GolovinContext : DbContext
    {
        public GolovinContext()
        {
        }

        public GolovinContext(DbContextOptions<GolovinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<AuthorFeedback> AuthorFeedbacks { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ContactPerson> ContactPeople { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<RequestProcessed> RequestProcesseds { get; set; }
        public virtual DbSet<StatusStudent> StatusStudents { get; set; }
        public virtual DbSet<TypeProject> TypeProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.50.136;Database=Golovin;User Id=Golovin;Password=QWEasd123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.ToTable("Achievement");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Photo).IsRequired();

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Achievements)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Achievement_Member");
            });

            modelBuilder.Entity<AuthorFeedback>(entity =>
            {
                entity.ToTable("AuthorFeedback");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");


                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(350);

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_Member");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");


                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_AuthorFeedback");

                

                entity.HasOne(d => d.OwnerCommentNavigation)
                    .WithMany(p => p.InverseOwnerCommentNavigation)
                    .HasForeignKey(d => d.OwnerComment)
                    .HasConstraintName("FK_Comment_Comment");

                entity.HasOne(d => d.PublicationNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Publication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Blog");

                
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.ToTable("ContactPerson");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Post)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_AuthorFeedback");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_StatusStudent");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.DatePublication).HasColumnType("datetime");

                entity.Property(e => e.Photo).IsRequired();

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_News_Member");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.AuthorNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Member");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_TypeProject");
            });

            modelBuilder.Entity<RequestProcessed>(entity =>
            {
                entity.ToTable("RequestProcessed");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.RequestProcesseds)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestProcessed_ContactPerson");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RequestProcesseds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestProcessed_Member");
            });

            modelBuilder.Entity<StatusStudent>(entity =>
            {
                entity.ToTable("StatusStudent");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TypeProject>(entity =>
            {
                entity.ToTable("TypeProject");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
