﻿// <auto-generated />
using LokwaInnovation.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LokwaInnovation.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20201021193813_addedToken13336")]
    partial class addedToken13336
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LokwaInnovation.Models.Access_Tokens", b =>
                {
                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<string>("DateModified")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.HasKey("User_id");

                    b.ToTable("Access_Tokens");
                });

            modelBuilder.Entity("LokwaInnovation.Models.Client_account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Phone_number")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Token_balance")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Client_account");
                });

            modelBuilder.Entity("LokwaInnovation.Models.Contacts", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Full_name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Roles")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Time")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ID");

                    b.ToTable("AnonymousMessages");
                });

            modelBuilder.Entity("LokwaInnovation.Models.Conversation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("chatID")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ID");

                    b.ToTable("Conversation");
                });

            modelBuilder.Entity("LokwaInnovation.Models.Log_in", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Full_name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("varchar(13) CHARACTER SET utf8mb4")
                        .HasMaxLength(13);

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.HasKey("User_ID");

                    b.ToTable("Log_in");
                });

            modelBuilder.Entity("LokwaInnovation.Models.Messages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("chatID")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("LokwaInnovation.Models.MpesaTransactions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Amount")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MpesaReceiptNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TransactionDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("MpesaTransactions");
                });

            modelBuilder.Entity("LokwaInnovation.Models.Mpesa_Status", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<float>("Ammount")
                        .HasColumnType("float");

                    b.Property<string>("CheckoutRequestID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Payment_status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ResultDesc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TransactionDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Transaction_status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("User_id")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("strResultCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("transactionCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Mpesa_Status");
                });

            modelBuilder.Entity("LokwaInnovation.Models.Students", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Full_name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Subject")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LokwaInnovation.Models.Token_price", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DateModified")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("Token_pricelist")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Token_price");
                });

            modelBuilder.Entity("LokwaInnovation.Models.Visits_counter", b =>
                {
                    b.Property<int>("Visit_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Visit_id");

                    b.ToTable("Visits_counter");
                });

            modelBuilder.Entity("Lubes.Models.PDF_Documents", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Book_url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cover_url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Date_modified")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Document_description")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<string>("Document_name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("PDF_Documents");
                });

            modelBuilder.Entity("Lubes.Models.PDF_Refference", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Doc_id")
                        .HasColumnType("int");

                    b.Property<string>("Refference_url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Pdf_refference");
                });
#pragma warning restore 612, 618
        }
    }
}
