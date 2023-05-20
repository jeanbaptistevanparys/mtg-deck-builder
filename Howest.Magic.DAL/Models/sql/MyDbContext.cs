#nullable disable

using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Models.sql;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<artist> artists { get; set; }
    public virtual DbSet<card> cards { get; set; }
    public virtual DbSet<card_color> card_colors { get; set; }
    public virtual DbSet<card_type> card_types { get; set; }
    public virtual DbSet<color> colors { get; set; }
    public virtual DbSet<migration> migrations { get; set; }
    public virtual DbSet<personal_access_token> personal_access_tokens { get; set; }
    public virtual DbSet<rarity> rarities { get; set; }
    public virtual DbSet<set> sets { get; set; }
    public virtual DbSet<type> types { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<card>(entity =>
        {
            entity.HasOne(d => d.artist)
                .WithMany(p => p.cards)
                .HasForeignKey(d => d.artist_id)
                .HasConstraintName("FK_cards_artists");

            entity.HasOne(d => d.rarity_codeNavigation)
                .WithMany(p => p.cards)
                .HasPrincipalKey(p => p.code)
                .HasForeignKey(d => d.rarity_code)
                .HasConstraintName("FK_cards_rarities");

            entity.HasOne(d => d.set_codeNavigation)
                .WithMany(p => p.cards)
                .HasPrincipalKey(p => p.code)
                .HasForeignKey(d => d.set_code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cards_sets");
        });

        modelBuilder.Entity<card_color>(entity =>
        {
            entity.HasKey(e => new { e.card_id, e.color_id })
                .HasName("card_colors_card_id_color_id_primary");

            entity.HasOne(d => d.card)
                .WithMany(p => p.card_colors)
                .HasForeignKey(d => d.card_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_colors_cards");

            entity.HasOne(d => d.color)
                .WithMany(p => p.card_colors)
                .HasForeignKey(d => d.color_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_colors_colors");
        });

        modelBuilder.Entity<card_type>(entity =>
        {
            entity.HasKey(e => new { e.card_id, e.type_id })
                .HasName("card_types_card_id_type_id_primary");

            entity.HasOne(d => d.card)
                .WithMany(p => p.card_types)
                .HasForeignKey(d => d.card_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_types_cards");

            entity.HasOne(d => d.type)
                .WithMany(p => p.card_types)
                .HasForeignKey(d => d.type_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_types_types");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}