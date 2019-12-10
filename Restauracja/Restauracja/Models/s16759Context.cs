using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restauracja.Models
{
    public partial class s16759Context : DbContext
    {
        public s16759Context()
        {
        }

        public s16759Context(DbContextOptions<s16759Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dodatek> Dodatek { get; set; }
        public virtual DbSet<Dostawa> Dostawa { get; set; }
        public virtual DbSet<Dostawca> Dostawca { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<ListaDodatkow> ListaDodatkow { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Sos> Sos { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16759;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dodatek>(entity =>
            {
                entity.HasKey(e => e.IdDodatek);

                entity.ToTable("DODATEK");

                entity.Property(e => e.IdDodatek)
                    .HasColumnName("idDodatek")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dostawa>(entity =>
            {
                entity.HasKey(e => new { e.IdDostawca, e.IdZamowienie });

                entity.ToTable("DOSTAWA");

                entity.Property(e => e.IdDostawca).HasColumnName("idDostawca");

                entity.Property(e => e.IdZamowienie).HasColumnName("idZamowienie");

                entity.Property(e => e.Czas).HasColumnName("czas");

                entity.Property(e => e.Odleglosc).HasColumnName("odleglosc");

                entity.HasOne(d => d.IdDostawcaNavigation)
                    .WithMany(p => p.Dostawa)
                    .HasForeignKey(d => d.IdDostawca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DOSTAWA_DOSTAWCA");

                entity.HasOne(d => d.IdZamowienieNavigation)
                    .WithMany(p => p.Dostawa)
                    .HasForeignKey(d => d.IdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DOSTAWA_ZAMOWIENIE");
            });

            modelBuilder.Entity<Dostawca>(entity =>
            {
                entity.HasKey(e => e.IdDostawca);

                entity.ToTable("DOSTAWCA");

                entity.Property(e => e.IdDostawca)
                    .HasColumnName("idDostawca")
                    .ValueGeneratedNever();

                entity.Property(e => e.DaneOsobowe)
                    .IsRequired()
                    .HasColumnName("daneOsobowe");

                entity.Property(e => e.Polozenie)
                    .IsRequired()
                    .HasColumnName("polozenie");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient);

                entity.ToTable("KLIENT");

                entity.Property(e => e.IdKlient)
                    .HasColumnName("idKlient")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasColumnName("adres");

                entity.Property(e => e.DaneOsobowe)
                    .IsRequired()
                    .HasColumnName("daneOsobowe");

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasColumnName("telefon")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ListaDodatkow>(entity =>
            {
                entity.HasKey(e => new { e.IdPizza, e.IdDodatek });

                entity.ToTable("LISTA_DODATKOW");

                entity.Property(e => e.IdPizza).HasColumnName("idPizza");

                entity.Property(e => e.IdDodatek).HasColumnName("idDodatek");

                entity.HasOne(d => d.IdDodatekNavigation)
                    .WithMany(p => p.ListaDodatkow)
                    .HasForeignKey(d => d.IdDodatek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LISTA_DODATKOW_DODATEK");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.ListaDodatkow)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LISTA_DODATKOW_PIZZA");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza);

                entity.ToTable("PIZZA");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("idPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.IdPromocja)
                    .HasColumnName("idPromocja")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IdSos).HasColumnName("idSos");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Rozmiar).HasColumnName("rozmiar");

                entity.HasOne(d => d.IdPromocjaNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.IdPromocja)
                    .HasConstraintName("PIZZA_PROMOCJA");

                entity.HasOne(d => d.IdSosNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.IdSos)
                    .HasConstraintName("PIZZA_SOS");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja);

                entity.ToTable("PROMOCJA");

                entity.Property(e => e.IdPromocja)
                    .HasColumnName("idPromocja")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Do)
                    .HasColumnName("do")
                    .HasColumnType("date");

                entity.Property(e => e.Multiplier).HasColumnName("multiplier");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Od)
                    .HasColumnName("od")
                    .HasColumnType("date");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis");
            });

            modelBuilder.Entity<Sos>(entity =>
            {
                entity.HasKey(e => e.IdSos);

                entity.ToTable("SOS");

                entity.Property(e => e.IdSos)
                    .HasColumnName("idSos")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie);

                entity.ToTable("ZAMOWIENIE");

                entity.Property(e => e.IdZamowienie)
                    .HasColumnName("idZamowienie")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenaZamowienia).HasColumnName("cenaZamowienia");

                entity.Property(e => e.Czas).HasColumnName("czas");

                entity.Property(e => e.IdKlient).HasColumnName("idKlient");

                entity.Property(e => e.IdPizza).HasColumnName("idPizza");

                entity.Property(e => e.IdPromocja)
                    .HasColumnName("idPromocja")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Stan)
                    .IsRequired()
                    .HasColumnName("stan")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ZAMOWIENIE_KLIENT");

                entity.HasOne(d => d.IdPizzaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ZAMOWIENIE_PIZZA");

                entity.HasOne(d => d.IdPromocjaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.IdPromocja)
                    .HasConstraintName("ZAMOWIENIE_PROMOCJA");
            });
        }
    }
}
