﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_spMedicalGroup_webApi.Domains;

#nullable disable

namespace senai_spMedicalGroup_webApi.Contexts
{
    public partial class spMedicalGroupContext : DbContext
    {
        public spMedicalGroupContext()
        {
        }

        public spMedicalGroupContext(DbContextOptions<spMedicalGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<EspecialidadeMedico> EspecialidadeMedicos { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0R6MFG3\\SQLEXPRESS; initial catalog=SP_MEDICAL_GROUP; user Id=sa; pwd=Luca*123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__cliente__885457EECC957E26");

                entity.ToTable("cliente");

                entity.HasIndex(e => e.DataNascCliente, "UQ__cliente__1DE4C386DEE1983B")
                    .IsUnique();

                entity.HasIndex(e => e.RgCliente, "UQ__cliente__40318655B413EC0A")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario, "UQ__cliente__645723A7F29FDB12")
                    .IsUnique();

                entity.HasIndex(e => e.CpfCliente, "UQ__cliente__9DA3A5B9BFA95705")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.CpfCliente)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("cpfCliente");

                entity.Property(e => e.DataNascCliente)
                    .HasColumnType("date")
                    .HasColumnName("dataNascCliente");

                entity.Property(e => e.EnderecoCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("enderecoCliente");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeCliente)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("nomeCliente");

                entity.Property(e => e.RgCliente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("rgCliente");

                entity.Property(e => e.TelefoneCliente)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefoneCliente");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cliente__idUsuar__2F10007B");
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__clinica__C73A6055CB45AE5F");

                entity.ToTable("clinica");

                entity.HasIndex(e => e.Cnpj, "UQ__clinica__35BD3E4858A5B7E1")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__clinica__9BF93A30E1C2AA91")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.EnderecoClinica)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("enderecoClinica");

                entity.Property(e => e.HorarioFim).HasColumnName("horarioFim");

                entity.Property(e => e.HorarioInicio).HasColumnName("horarioInicio");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__consulta__CA9C61F561E8642A");

                entity.ToTable("consulta");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("date")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.DescricaoConsulta)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("descricaoConsulta");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consulta__idClie__412EB0B6");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consulta__idMedi__4222D4EF");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__consulta__idSitu__4316F928");
            });

            modelBuilder.Entity<EspecialidadeMedico>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidadeMedico)
                    .HasName("PK__especial__2FAA3FD8AFDE978C");

                entity.ToTable("especialidadeMedico");

                entity.HasIndex(e => e.NomeEspecialidade, "UQ__especial__EF876A54497DEEEE")
                    .IsUnique();

                entity.Property(e => e.IdEspecialidadeMedico).HasColumnName("idEspecialidadeMedico");

                entity.Property(e => e.NomeEspecialidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeEspecialidade");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__medico__4E03DEBAB65E1206");

                entity.ToTable("medico");

                entity.HasIndex(e => e.CrmMedico, "UQ__medico__1B2AA8B4C48285C1")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario, "UQ__medico__645723A75BBD6D9F")
                    .IsUnique();

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.CrmMedico)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("crmMedico");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdEspecialidadeMedico).HasColumnName("idEspecialidadeMedico");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("nomeMedico");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idClinic__3C69FB99");

                entity.HasOne(d => d.IdEspecialidadeMedicoNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidadeMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idEspeci__3B75D760");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Medico)
                    .HasForeignKey<Medico>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__medico__idUsuari__3A81B327");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__situacao__12AFD1971F7669E8");

                entity.ToTable("situacao");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.TipoSituacao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipoSituacao");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF97D71CEE");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.TipoUsuario1, "UQ__tipoUsua__A9585C058FD135F6")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TipoUsuario1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6EFEE3745");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E6164BCD0A72F")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__idTipoU__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
