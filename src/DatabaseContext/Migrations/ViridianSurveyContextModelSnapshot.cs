﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using ViridianCode.ViridianSurvey.DatabaseContext;

namespace ViridianCode.ViridianSurvey.DatabaseContext.Migrations
{
    [DbContext(typeof(ViridianSurveyContext))]
    partial class ViridianSurveyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ViridianCode.ViridianSurvey.DataModel.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Mandatory");

                    b.Property<int>("Order");

                    b.Property<int?>("ParentQuestionId");

                    b.Property<string>("QuestionText");

                    b.Property<string>("Relevance");

                    b.Property<int>("Scale");

                    b.Property<int?>("SurveyId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ParentQuestionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ViridianCode.ViridianSurvey.DataModel.Respondent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Respondents");
                });

            modelBuilder.Entity("ViridianCode.ViridianSurvey.DataModel.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowBackwardNavigation");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("EndMessage");

                    b.Property<bool>("ShowGroupDescription");

                    b.Property<bool>("ShowGroupName");

                    b.Property<bool>("ShowProgressBar");

                    b.Property<bool>("ShowWelcomeScreen");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("WelcomeMessage");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("ViridianCode.ViridianSurvey.DataModel.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("ViridianCode.ViridianSurvey.DataModel.Question", b =>
                {
                    b.HasOne("ViridianCode.ViridianSurvey.DataModel.UserAccount", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ViridianCode.ViridianSurvey.DataModel.Question", "ParentQuestion")
                        .WithMany()
                        .HasForeignKey("ParentQuestionId");

                    b.HasOne("ViridianCode.ViridianSurvey.DataModel.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("ViridianCode.ViridianSurvey.DataModel.Respondent", b =>
                {
                    b.HasOne("ViridianCode.ViridianSurvey.DataModel.UserAccount", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });

            modelBuilder.Entity("ViridianCode.ViridianSurvey.DataModel.Survey", b =>
                {
                    b.HasOne("ViridianCode.ViridianSurvey.DataModel.UserAccount", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
