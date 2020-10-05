﻿// <auto-generated />
using System;
using MatriculaWPF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatriculaWPF.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201005031705_UpdateContext17")]
    partial class UpdateContext17
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MatriculaWPF.Models.AdministracaoHorario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("HoraFim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoraInicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalAulas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AdministracaoHorarios");
                });

            modelBuilder.Entity("MatriculaWPF.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("MatriculaWPF.Models.ConjuntoAluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("ConjuntoAlunos");
                });

            modelBuilder.Entity("MatriculaWPF.Models.Dia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ordenacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dias");
                });

            modelBuilder.Entity("MatriculaWPF.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("MatriculaWPF.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiaId")
                        .HasColumnType("int");

                    b.Property<string>("HorarioFim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorarioInicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MentorDisciplinaId")
                        .HasColumnType("int");

                    b.Property<int?>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiaId");

                    b.HasIndex("MentorDisciplinaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("MatriculaWPF.Models.HistoricoAluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NivelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("NivelId");

                    b.ToTable("HistoricoAlunos");
                });

            modelBuilder.Entity("MatriculaWPF.Models.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mentores");
                });

            modelBuilder.Entity("MatriculaWPF.Models.MentorDisciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("MentorId");

                    b.ToTable("MentorDisciplinas");
                });

            modelBuilder.Entity("MatriculaWPF.Models.Nivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ordenacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Niveis");
                });

            modelBuilder.Entity("MatriculaWPF.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdministracaoHorarioId")
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NivelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdministracaoHorarioId");

                    b.HasIndex("NivelId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("MatriculaWPF.Models.ConjuntoAluno", b =>
                {
                    b.HasOne("MatriculaWPF.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId");

                    b.HasOne("MatriculaWPF.Models.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId");
                });

            modelBuilder.Entity("MatriculaWPF.Models.Grade", b =>
                {
                    b.HasOne("MatriculaWPF.Models.Dia", "Dia")
                        .WithMany()
                        .HasForeignKey("DiaId");

                    b.HasOne("MatriculaWPF.Models.MentorDisciplina", "MentorDisciplina")
                        .WithMany()
                        .HasForeignKey("MentorDisciplinaId");

                    b.HasOne("MatriculaWPF.Models.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId");
                });

            modelBuilder.Entity("MatriculaWPF.Models.HistoricoAluno", b =>
                {
                    b.HasOne("MatriculaWPF.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId");

                    b.HasOne("MatriculaWPF.Models.Nivel", "Nivel")
                        .WithMany()
                        .HasForeignKey("NivelId");
                });

            modelBuilder.Entity("MatriculaWPF.Models.MentorDisciplina", b =>
                {
                    b.HasOne("MatriculaWPF.Models.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId");

                    b.HasOne("MatriculaWPF.Models.Mentor", "Mentor")
                        .WithMany()
                        .HasForeignKey("MentorId");
                });

            modelBuilder.Entity("MatriculaWPF.Models.Turma", b =>
                {
                    b.HasOne("MatriculaWPF.Models.AdministracaoHorario", "AdministracaoHorario")
                        .WithMany()
                        .HasForeignKey("AdministracaoHorarioId");

                    b.HasOne("MatriculaWPF.Models.Nivel", "Nivel")
                        .WithMany()
                        .HasForeignKey("NivelId");
                });
#pragma warning restore 612, 618
        }
    }
}
