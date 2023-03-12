using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Data;

public partial class AnkiDbContext : DbContext
{
    public AnkiDbContext()
    {
    }

    public AnkiDbContext(DbContextOptions<AnkiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Col> Cols { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<Deck> Decks { get; set; }

    public virtual DbSet<DeckConfig> DeckConfigs { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Grafe> Graves { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Notetype> Notetypes { get; set; }

    public virtual DbSet<Revlog> Revlogs { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.ToTable("cards");

            entity.HasIndex(e => e.Odid, "idx_cards_odid");

            entity.HasIndex(e => e.Nid, "ix_cards_nid");

            entity.HasIndex(e => new { e.Did, e.Queue, e.Due }, "ix_cards_sched");

            entity.HasIndex(e => e.Usn, "ix_cards_usn");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Did).HasColumnName("did");
            entity.Property(e => e.Due).HasColumnName("due");
            entity.Property(e => e.Factor).HasColumnName("factor");
            entity.Property(e => e.Flags).HasColumnName("flags");
            entity.Property(e => e.Ivl).HasColumnName("ivl");
            entity.Property(e => e.Lapses).HasColumnName("lapses");
            entity.Property(e => e.Left).HasColumnName("left");
            entity.Property(e => e.Mod).HasColumnName("mod");
            entity.Property(e => e.Nid).HasColumnName("nid");
            entity.Property(e => e.Odid).HasColumnName("odid");
            entity.Property(e => e.Odue).HasColumnName("odue");
            entity.Property(e => e.Ord).HasColumnName("ord");
            entity.Property(e => e.Queue).HasColumnName("queue");
            entity.Property(e => e.Reps).HasColumnName("reps");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Usn).HasColumnName("usn");
        });

        modelBuilder.Entity<Col>(entity =>
        {
            entity.ToTable("col");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Conf).HasColumnName("conf");
            entity.Property(e => e.Crt).HasColumnName("crt");
            entity.Property(e => e.Dconf).HasColumnName("dconf");
            entity.Property(e => e.Decks).HasColumnName("decks");
            entity.Property(e => e.Dty).HasColumnName("dty");
            entity.Property(e => e.Ls).HasColumnName("ls");
            entity.Property(e => e.Mod).HasColumnName("mod");
            entity.Property(e => e.Models).HasColumnName("models");
            entity.Property(e => e.Scm).HasColumnName("scm");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Usn).HasColumnName("usn");
            entity.Property(e => e.Ver).HasColumnName("ver");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasKey(e => e.Key);

            entity.ToTable("config");

            entity.Property(e => e.Key).HasColumnName("KEY");
            entity.Property(e => e.MtimeSecs).HasColumnName("mtime_secs");
            entity.Property(e => e.Usn).HasColumnName("usn");
            entity.Property(e => e.Val).HasColumnName("val");
        });

        modelBuilder.Entity<Deck>(entity =>
        {
            entity.ToTable("decks");

            entity.HasIndex(e => e.Name, "idx_decks_name").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Common).HasColumnName("common");
            entity.Property(e => e.Kind).HasColumnName("kind");
            entity.Property(e => e.MtimeSecs).HasColumnName("mtime_secs");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Usn).HasColumnName("usn");
        });

        modelBuilder.Entity<DeckConfig>(entity =>
        {
            entity.ToTable("deck_config");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Config).HasColumnName("config");
            entity.Property(e => e.MtimeSecs).HasColumnName("mtime_secs");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Usn).HasColumnName("usn");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => new { e.Ntid, e.Ord });

            entity.ToTable("fields");

            entity.HasIndex(e => new { e.Name, e.Ntid }, "idx_fields_name_ntid").IsUnique();

            entity.Property(e => e.Ntid).HasColumnName("ntid");
            entity.Property(e => e.Ord).HasColumnName("ord");
            entity.Property(e => e.Config).HasColumnName("config");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Grafe>(entity =>
        {
            entity.HasKey(e => new { e.Oid, e.Type });

            entity.ToTable("graves");

            entity.HasIndex(e => e.Usn, "idx_graves_pending");

            entity.Property(e => e.Oid).HasColumnName("oid");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Usn).HasColumnName("usn");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("notes");

            entity.HasIndex(e => e.Mid, "idx_notes_mid");

            entity.HasIndex(e => e.Csum, "ix_notes_csum");

            entity.HasIndex(e => e.Usn, "ix_notes_usn");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Csum).HasColumnName("csum");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Flags).HasColumnName("flags");
            entity.Property(e => e.Flds).HasColumnName("flds");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Mid).HasColumnName("mid");
            entity.Property(e => e.Mod).HasColumnName("mod");
            entity.Property(e => e.Sfld).HasColumnName("sfld");
            entity.Property(e => e.Tags).HasColumnName("tags");
            entity.Property(e => e.Usn).HasColumnName("usn");
        });

        modelBuilder.Entity<Notetype>(entity =>
        {
            entity.ToTable("notetypes");

            entity.HasIndex(e => e.Name, "idx_notetypes_name").IsUnique();

            entity.HasIndex(e => e.Usn, "idx_notetypes_usn");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Config).HasColumnName("config");
            entity.Property(e => e.MtimeSecs).HasColumnName("mtime_secs");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Usn).HasColumnName("usn");
        });

        modelBuilder.Entity<Revlog>(entity =>
        {
            entity.ToTable("revlog");

            entity.HasIndex(e => e.Cid, "ix_revlog_cid");

            entity.HasIndex(e => e.Usn, "ix_revlog_usn");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Ease).HasColumnName("ease");
            entity.Property(e => e.Factor).HasColumnName("factor");
            entity.Property(e => e.Ivl).HasColumnName("ivl");
            entity.Property(e => e.LastIvl).HasColumnName("lastIvl");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Usn).HasColumnName("usn");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Tag1);

            entity.ToTable("tags");

            entity.Property(e => e.Tag1).HasColumnName("tag");
            entity.Property(e => e.Collapsed)
                .HasColumnType("boolean")
                .HasColumnName("collapsed");
            entity.Property(e => e.Config).HasColumnName("config");
            entity.Property(e => e.Usn).HasColumnName("usn");
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => new { e.Ntid, e.Ord });

            entity.ToTable("templates");

            entity.HasIndex(e => new { e.Name, e.Ntid }, "idx_templates_name_ntid").IsUnique();

            entity.HasIndex(e => e.Usn, "idx_templates_usn");

            entity.Property(e => e.Ntid).HasColumnName("ntid");
            entity.Property(e => e.Ord).HasColumnName("ord");
            entity.Property(e => e.Config).HasColumnName("config");
            entity.Property(e => e.MtimeSecs).HasColumnName("mtime_secs");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Usn).HasColumnName("usn");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
