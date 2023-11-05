using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineLearning.Entities
{
    public partial class OnlineLearningContext : DbContext
    {
        public OnlineLearningContext()
        {
        }

        public OnlineLearningContext(DbContextOptions<OnlineLearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Chapter> Chapters { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = OnlineLearning;uid=sa;pwd=123456;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Chapters)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Chapters__Course__3B75D760");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.ImageUrl)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.IsPublic).HasColumnName("isPublic");

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("lastUpdated");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Courses__categor__38996AB5");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.ChapterId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Lessons__Chapter__44FF419A");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Questions__QuizI__45F365D3");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.LessonId).HasColumnName("lessonId");

                entity.Property(e => e.PassingScore).HasColumnName("passing-score");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.TotalQuestion).HasColumnName("total-question");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Quizzes__lessonI__46E78A0C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.Avatar)
                    .IsUnicode(false)
                    .HasColumnName("avatar");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EncodedPassword)
                    .IsUnicode(false)
                    .HasColumnName("encodedPassword");

                entity.Property(e => e.IsEnabled).HasColumnName("isEnabled");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
