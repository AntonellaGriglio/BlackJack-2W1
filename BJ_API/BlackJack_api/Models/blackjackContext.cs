using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlackJack_api.Models
{
    public partial class blackjackContext : DbContext
    {
        public blackjackContext(DbContextOptions<blackjackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cartajugadum> Cartajugada { get; set; } = null!;
        public virtual DbSet<Cartum> Carta { get; set; } = null!;
        public virtual DbSet<Jugadum> Jugada { get; set; } = null!;
        public virtual DbSet<Partidum> Partida { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cartajugadum>(entity =>
            {
                entity.HasKey(e => e.IdCartaJugada)
                    .HasName("PRIMARY");

                entity.ToTable("cartajugada");

                entity.HasIndex(e => e.IdCarta, "fk_carta_idx");

                entity.HasIndex(e => e.IdPartida, "fk_partida_idx");

                entity.Property(e => e.IdCartaJugada).HasColumnName("idCartaJugada");

                entity.Property(e => e.IdCarta).HasColumnName("idCarta");

                entity.Property(e => e.IdPartida).HasColumnName("idPartida");

                entity.Property(e => e.Jugador)
                    .HasMaxLength(45)
                    .HasColumnName("jugador");

                entity.HasOne(d => d.IdCartaNavigation)
                    .WithMany(p => p.Cartajugada)
                    .HasForeignKey(d => d.IdCarta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_carta");

                entity.HasOne(d => d.IdPartidaNavigation)
                    .WithMany(p => p.Cartajugada)
                    .HasForeignKey(d => d.IdPartida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_partida");
            });

            modelBuilder.Entity<Cartum>(entity =>
            {
                entity.HasKey(e => e.IdCarta)
                    .HasName("PRIMARY");

                entity.ToTable("carta");

                entity.Property(e => e.IdCarta).HasColumnName("idCarta");

                entity.Property(e => e.Carta)
                    .HasMaxLength(3)
                    .HasColumnName("carta");

                entity.Property(e => e.IsAs).HasColumnName("isAs");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<Jugadum>(entity =>
            {
                entity.HasKey(e => e.IdJugada)
                    .HasName("PRIMARY");

                entity.ToTable("jugada");

                entity.HasIndex(e => e.IdUsuario, "fk_usuario_idx");

                entity.Property(e => e.IdJugada).HasColumnName("idJugada");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Jugada)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario");
            });

            modelBuilder.Entity<Partidum>(entity =>
            {
                entity.HasKey(e => e.IdPartida)
                    .HasName("PRIMARY");

                entity.ToTable("partida");

                entity.HasIndex(e => e.IdJugada, "fk_jugada_idx");

                entity.Property(e => e.IdPartida).HasColumnName("idPartida");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdJugada).HasColumnName("idJugada");

                entity.Property(e => e.PuntosCrupier)
                    .HasMaxLength(45)
                    .HasColumnName("puntosCrupier");

                entity.Property(e => e.PuntosJugador).HasColumnName("puntosJugador");

                entity.Property(e => e.Resultado)
                    .HasMaxLength(45)
                    .HasColumnName("resultado");

                entity.HasOne(d => d.IdJugadaNavigation)
                    .WithMany(p => p.Partida)
                    .HasForeignKey(d => d.IdJugada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jugada");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(45)
                    .HasColumnName("usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
