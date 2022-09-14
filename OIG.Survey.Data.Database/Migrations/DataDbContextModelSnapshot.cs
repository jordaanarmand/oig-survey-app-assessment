﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OIG.Survey.Data.Database;

#nullable disable

namespace OIG.Survey.Data.Database.Migrations
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.Answers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Answer")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("QuestionnaireId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuestionsId")
                        .HasColumnType("bigint");

                    b.Property<long>("RespondentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireId");

                    b.HasIndex("QuestionsId");

                    b.HasIndex("RespondentId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.Questionnaire", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("QuestionnaireStatusId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireStatusId");

                    b.ToTable("Questionnaire");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.QuestionnaireStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("QuestionnaireStatus");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Concept"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Scheduled"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Active"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Finished"
                        });
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.QuestionOption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Option")
                        .HasColumnType("text");

                    b.Property<long?>("QuestionsId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuestionsId");

                    b.ToTable("QuestionOption");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.Questions", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Question")
                        .HasColumnType("text");

                    b.Property<List<long>>("QuestionOptionId")
                        .HasColumnType("bigint[]");

                    b.Property<long>("QuestionTypeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("QuestionnaireId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuestionTypeId");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.QuestionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("QuestionType");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.Respondent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid?>("DeviceId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Respondent");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.Answers", b =>
                {
                    b.HasOne("OIG.Survey.Data.Database.Entities.Questionnaire", "Questionnaire")
                        .WithMany()
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OIG.Survey.Data.Database.Entities.Questions", "Questions")
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OIG.Survey.Data.Database.Entities.Respondent", "Respondent")
                        .WithMany()
                        .HasForeignKey("RespondentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Questionnaire");

                    b.Navigation("Questions");

                    b.Navigation("Respondent");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.Questionnaire", b =>
                {
                    b.HasOne("OIG.Survey.Data.Database.Entities.QuestionnaireStatus", "QuestionnaireStatus")
                        .WithMany()
                        .HasForeignKey("QuestionnaireStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionnaireStatus");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.QuestionOption", b =>
                {
                    b.HasOne("OIG.Survey.Data.Database.Entities.Questions", null)
                        .WithMany("QuestionOption")
                        .HasForeignKey("QuestionsId");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.Questions", b =>
                {
                    b.HasOne("OIG.Survey.Data.Database.Entities.QuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OIG.Survey.Data.Database.Entities.Questionnaire", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuestionnaireId");

                    b.Navigation("QuestionType");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.Questionnaire", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("OIG.Survey.Data.Database.Entities.Questions", b =>
                {
                    b.Navigation("QuestionOption");
                });
#pragma warning restore 612, 618
        }
    }
}
