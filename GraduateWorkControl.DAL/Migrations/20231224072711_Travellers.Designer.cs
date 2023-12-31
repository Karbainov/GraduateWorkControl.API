﻿// <auto-generated />
using System;
using GraduateWorkControl.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraduateWorkControl.DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231224072711_Travellers")]
    partial class Travellers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.ApplicationDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationState")
                        .HasColumnType("int");

                    b.Property<string>("CoveringLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("WorkTheme")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.CommentDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TaskId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.FacultyDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Facultys");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.MaterialDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CommentsId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TasksId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentsId");

                    b.HasIndex("TasksId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.Movies.MovieRating", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("UserId", "MediaId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.Movies.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.Movies.UserWatchList", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "MediaId");

                    b.ToTable("UserWatchLists");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.StudentDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelited")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.SubjectDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.TaskDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Deadline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.TeacherDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.Travel.Traveller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Travellers");
                });

            modelBuilder.Entity("SubjectDtoTeacherDto", b =>
                {
                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("SubjectsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("SubjectDtoTeacherDto");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.ApplicationDto", b =>
                {
                    b.HasOne("GraduateWorkControl.DAL.Dtos.StudentDto", "Student")
                        .WithMany("Application")
                        .HasForeignKey("StudentId");

                    b.HasOne("GraduateWorkControl.DAL.Dtos.TeacherDto", "Teacher")
                        .WithMany("Applications")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.CommentDto", b =>
                {
                    b.HasOne("GraduateWorkControl.DAL.Dtos.StudentDto", "Student")
                        .WithMany("Comments")
                        .HasForeignKey("StudentId");

                    b.HasOne("GraduateWorkControl.DAL.Dtos.TaskDto", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskId");

                    b.HasOne("GraduateWorkControl.DAL.Dtos.TeacherDto", "Teacher")
                        .WithMany("Comments")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Student");

                    b.Navigation("Task");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.MaterialDto", b =>
                {
                    b.HasOne("GraduateWorkControl.DAL.Dtos.CommentDto", "Comments")
                        .WithMany("Materials")
                        .HasForeignKey("CommentsId");

                    b.HasOne("GraduateWorkControl.DAL.Dtos.TaskDto", "Tasks")
                        .WithMany("Materials")
                        .HasForeignKey("TasksId");

                    b.Navigation("Comments");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.Movies.MovieRating", b =>
                {
                    b.HasOne("GraduateWorkControl.DAL.Dtos.Movies.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.Movies.UserWatchList", b =>
                {
                    b.HasOne("GraduateWorkControl.DAL.Dtos.Movies.User", "User")
                        .WithMany("WatchList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.StudentDto", b =>
                {
                    b.HasOne("GraduateWorkControl.DAL.Dtos.TeacherDto", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.TaskDto", b =>
                {
                    b.HasOne("GraduateWorkControl.DAL.Dtos.StudentDto", "Student")
                        .WithMany("Tasks")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.TeacherDto", b =>
                {
                    b.HasOne("GraduateWorkControl.DAL.Dtos.FacultyDto", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("SubjectDtoTeacherDto", b =>
                {
                    b.HasOne("GraduateWorkControl.DAL.Dtos.SubjectDto", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraduateWorkControl.DAL.Dtos.TeacherDto", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.CommentDto", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.Movies.User", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("WatchList");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.StudentDto", b =>
                {
                    b.Navigation("Application");

                    b.Navigation("Comments");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.TaskDto", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Materials");
                });

            modelBuilder.Entity("GraduateWorkControl.DAL.Dtos.TeacherDto", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Comments");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
