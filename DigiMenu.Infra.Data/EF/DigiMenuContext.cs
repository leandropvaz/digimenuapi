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

    public virtual DbSet<comanda_credito> comanda_credito { get; set; }

    public virtual DbSet<conta> conta { get; set; }

    public virtual DbSet<estabelecimento> estabelecimento { get; set; }

    public virtual DbSet<mesa> mesa { get; set; }

    public virtual DbSet<pedido_itens> pedido_itens { get; set; }

    public virtual DbSet<pedidos> pedidos { get; set; }

    public virtual DbSet<produtos> produtos { get; set; }

    public virtual DbSet<status> status { get; set; }

    public virtual DbSet<tipoProduto> tipoProduto { get; set; }

    public virtual DbSet<usuario> usuario { get; set; }

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

            entity.HasOne(d => d.mesaNavigation).WithMany(p => p.comanda)
                .HasForeignKey(d => d.mesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comanda_mesa");
        });

        modelBuilder.Entity<comanda_credito>(entity =>
        {
            entity.Property(e => e.responsavel)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.comandaNavigation).WithMany(p => p.comanda_credito)
                .HasForeignKey(d => d.comanda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comanda_credito_comanda_credito");
        });

        modelBuilder.Entity<conta>(entity =>
        {
            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.dataFechamento).HasColumnType("datetime");
            entity.Property(e => e.valor).HasColumnType("decimal(10, 2)");
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

            entity.HasOne(d => d.estabelecimentoNavigation).WithMany(p => p.mesa)
                .HasForeignKey(d => d.estabelecimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_mesa_estabelecimento");
        });

        modelBuilder.Entity<pedido_itens>(entity =>
        {
            entity.HasOne(d => d.pedidoNavigation).WithMany(p => p.pedido_itens)
                .HasForeignKey(d => d.pedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_itens_pedidos");

            entity.HasOne(d => d.produtoNavigation).WithMany(p => p.pedido_itens)
                .HasForeignKey(d => d.produto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_itens_produtos");

            entity.HasOne(d => d.statusNavigation).WithMany(p => p.pedido_itens)
                .HasForeignKey(d => d.status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedido_itens_status");
        });

        modelBuilder.Entity<pedidos>(entity =>
        {
            entity.Property(e => e.dataPedidoEntregue).HasColumnType("datetime");
            entity.Property(e => e.dataPedidoFeito)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.observacao).IsUnicode(false);
            entity.Property(e => e.responsavel)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.comandaNavigation).WithMany(p => p.pedidos)
                .HasForeignKey(d => d.comanda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedidos_comanda");

            entity.HasOne(d => d.statusNavigation).WithMany(p => p.pedidos)
                .HasForeignKey(d => d.status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pedidos_itens_status");
        });

        modelBuilder.Entity<produtos>(entity =>
        {
            entity.Property(e => e.descricao)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.nome)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.preco).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.produtos)
                .HasForeignKey(d => d.Tipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_produtos_tipoProduto");

            entity.HasOne(d => d.estabelecimentoNavigation).WithMany(p => p.produtos)
                .HasForeignKey(d => d.estabelecimento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_produtos_estabelecimento");
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

        modelBuilder.Entity<usuario>(entity =>
        {
            entity.Property(e => e.ativo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.cpf)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.dataCadastro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.imagem)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.nome)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.senha)
                .IsUnicode(false)
                .HasDefaultValueSql("('NULL')");
            entity.Property(e => e.telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
