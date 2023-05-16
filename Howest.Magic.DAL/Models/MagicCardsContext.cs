using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Howest.MagicCards.DAL.Models;

public partial class MagicCardsContext : DbContext
{
    public MagicCardsContext(DbContextOptions<MagicCardsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }
    public virtual DbSet<CardColor> CardColors { get; set; }
    public virtual DbSet<CardType> CardTypes { get; set; }
    public virtual DbSet<Color> Colors { get; set; }
    public virtual DbSet<Artist> Artists { get; set; }
    public virtual DbSet<Type> Types { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("cards");


            entity.Navigation(x => x.CardColors).AutoInclude();
            entity.Navigation(x => x.CardTypes).AutoInclude();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.Property(e => e.ManaCost)
                .HasMaxLength(255)
                .HasColumnName("mana_cost");

            entity.Property(e => e.ConvertedManaCost)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("converted_mana_cost");

            entity.HasMany(e => e.CardTypes)
                .WithOne(e => e.Card)
                .HasForeignKey(d => d.CardId);


            entity.HasMany(e => e.CardColors)
                .WithOne(e => e.Card)
                .HasForeignKey(d => d.CardId);

            entity.Property(e => e.Text)
                .HasMaxLength(255)
                .HasColumnName("text");

            entity.Property(e => e.Flavor)
                .HasMaxLength(255)
                .HasColumnName("flavor");

            entity.HasOne(c => c.Artist)
                .WithMany(a => a.Cards)
                .HasForeignKey(c => c.ArtistId)
                .HasConstraintName("FK_cards_artists");

            entity.HasOne(c => c.Rarity)
                .WithMany(a => a.Cards)
                .HasPrincipalKey(r => r.Code)
                .HasForeignKey(c => c.RarityCode)
                .HasConstraintName("FK_cards_rarities");

            entity.HasOne(c => c.Set)
                .WithMany(a => a.Cards)
                .HasPrincipalKey(s => s.Code)
                .HasForeignKey(c => c.SetCode)
                .HasConstraintName("FK_cards_sets");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__artists__3213E83FC867953C");

            entity.ToTable("artists");

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("full_name");
        });

        modelBuilder.Entity<CardColor>(entity =>
        {
            entity.HasKey(e => new { e.CardId, e.ColorId })
                .HasName("card_colors_card_id_color_id_primary");

            entity.ToTable("card_colors");

            entity.Property(e => e.CardId).HasColumnName("card_id");

            entity.Property(e => e.ColorId).HasColumnName("color_id");

            entity.HasOne(cc => cc.Color)
                .WithMany(c => c.CardColor)
                .HasForeignKey(cc => cc.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_colors_colors");

            entity.HasOne(cc => cc.Card)
                .WithMany(c => c.CardColors)
                .HasForeignKey(cc => cc.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_colors_cards");
        });

        modelBuilder.Entity<CardType>(entity =>
        {
            entity.HasKey(e => new { e.CardId, e.TypeId })
                .HasName("card_types_card_id_type_id_primary");

            entity.ToTable("card_typed");

            entity.Property(e => e.CardId).HasColumnName("card_id");

            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(cc => cc.Type)
                .WithMany(c => c.CardType)
                .HasForeignKey(cc => cc.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_types_types");

            entity.HasOne(cc => cc.Card)
                .WithMany(c => c.CardTypes)
                .HasForeignKey(cc => cc.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_types_cards");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("colors");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Rarity>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("rarities");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("sets");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("types");

            entity.Property(e => e.type)
                .IsRequired()
                .HasColumnName("type");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
        });
    }
}