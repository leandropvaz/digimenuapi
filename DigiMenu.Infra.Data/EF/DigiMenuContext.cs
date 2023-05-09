using System;
using System.Collections.Generic;
using DigiMenu.Infra.Data.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Infra.Data.EF;

public partial class DigiMenuContext : DbContext
{
    public DigiMenuContext()
    {
    }

    public DigiMenuContext(DbContextOptions<DigiMenuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<comanda> comanda { get; set; }

    public virtual DbSet<comanda_itens> comanda_itens { get; set; }

    public virtual DbSet<estabelecimento> estabelecimento { get; set; }

    public virtual DbSet<mesa> mesa { get; set; }

    public virtual DbSet<mesa_estabelecimento> mesa_estabelecimento { get; set; }

    public virtual DbSet<pedidos> pedidos { get; set; }

    public virtual DbSet<pedidos_itens> pedidos_itens { get; set; }

    public virtual DbSet<produtos> produtos { get; set; }

    public virtual DbSet<produtos_estabelecimento> produtos_estabelecimento { get; set; }

    public virtual DbSet<status> status { get; set; }

    public virtual DbSet<tipoProduto> tipoProduto { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=coretech.database.windows.net;Database=digimenu;User ID=coretech;Password=Babi2505;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<comanda>(entity =>
        {
            entity.Property(e => e.anfitriao)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.dataAbertura)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.dataEncerramento).HasColumnType("datetime");
        });

        modelBuilder.Entity<comanda_itens>(entity =>
        {
            entity.HasOne(d => d.comandaNavigation).WithMany(p => p.comanda_itens)
                .HasForeignKey(d => d.comanda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comanda_itens_comanda");
        });

        modelBuilder.Entity<estabelecimento>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__estabele__3213E83FCCBBABE0");

            entity.Property(e => e.cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.endereco)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.estado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.telefone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<mesa>(entity =>
        {
            entity.Property(e => e.numero)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<mesa_estabelecimento>(entity =>
        {
            entity.HasOne(d => d.estabelecimentoNavigation).WithMany(p => p.mesa_estabelecimento)
                .HasForeignKey(d => d.estabelecimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mesa_estabelecimento_estabelecimento");

            entity.HasOne(d => d.mesaNavigation).WithMany(p => p.mesa_estabelecimento)
                .HasForeignKey(d => d.mesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mesa_estabelecimento_mesa");

            entity.HasOne(d => d.statusNavigation).WithMany(p => p.mesa_estabelecimento)
                .HasForeignKey(d => d.status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mesa_estabelecimento_status");
        });

        modelBuilder.Entity<pedidos>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.dataPedido).HasColumnType("datetime");
            entity.Property(e => e.responsavel)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<pedidos_itens>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Table_1");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.pedidoNavigation).WithMany(p => p.pedidos_itens)
                .HasForeignKey(d => d.pedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_itens_pedidos");
        });

        modelBuilder.Entity<produtos>(entity =>
        {
            entity.Property(e => e.descricao)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.preco).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.produtos)
                .HasForeignKey(d => d.Tipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_produtos_tipoProduto");
        });

        modelBuilder.Entity<produtos_estabelecimento>(entity =>
        {
            entity.HasOne(d => d.estabelecimentoNavigation).WithMany(p => p.produtos_estabelecimento)
                .HasForeignKey(d => d.estabelecimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_produtos_estabelecimento_estabelecimento");

            entity.HasOne(d => d.produtoNavigation).WithMany(p => p.produtos_estabelecimento)
                .HasForeignKey(d => d.produto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_produtos_estabelecimento_produtos");
        });

        modelBuilder.Entity<status>(entity =>
        {
            entity.Property(e => e.descricao)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tipoProduto>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__tipoProd__3213E83FDEFC9EC1");

            entity.Property(e => e.descricao)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
