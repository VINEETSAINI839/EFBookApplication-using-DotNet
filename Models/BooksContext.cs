using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookEF2.Models;

public partial class BooksContext : DbContext
{
    public BooksContext()
    {
    }

    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBook> TblBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBook>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__tmp_ms_x__3DE0C207B9C47826");

            entity.ToTable("tbl_books");

            entity.Property(e => e.BookAuthor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BookName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BookPrice).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
