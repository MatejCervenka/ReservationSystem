using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "char(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservations",
                column: "ServiceId");
            
            migrationBuilder.Sql(@"GO
                SET IDENTITY_INSERT [dbo].[Services] ON 
                GO
                INSERT [dbo].[Services] ([Id], [Name]) VALUES (1, N'Střih vlasů
                ')
                GO
                INSERT [dbo].[Services] ([Id], [Name]) VALUES (2, N'Barvení vlasů
                ')
                GO
                INSERT [dbo].[Services] ([Id], [Name]) VALUES (3, N'Melír')
                GO
                INSERT [dbo].[Services] ([Id], [Name]) VALUES (4, N'Trvalá')
                GO
                INSERT [dbo].[Services] ([Id], [Name]) VALUES (5, N'Foukaná')
                GO
                INSERT [dbo].[Services] ([Id], [Name]) VALUES (6, N'Úprava vousů
                ')
                GO
                INSERT [dbo].[Services] ([Id], [Name]) VALUES (7, N'Společenský účes
                ')
                GO
                INSERT [dbo].[Services] ([Id], [Name]) VALUES (8, N'Regenerace vlasů
                ')
                GO
                SET IDENTITY_INSERT [dbo].[Services] OFF
                GO
                SET IDENTITY_INSERT [dbo].[Reservations] ON 
                GO
                INSERT [dbo].[Reservations] ([Id], [ServiceId], [Name], [Surname], [Phone], [Email], [CreatedAt]) VALUES (1, 1, N'Jan', N'Novák', N'+420123456789', N'jan.novak@example.com', CAST(N'2024-01-15T08:30:00.0000000' AS DateTime2))
                GO
                INSERT [dbo].[Reservations] ([Id], [ServiceId], [Name], [Surname], [Phone], [Email], [CreatedAt]) VALUES (2, 3, N'Petra', N'Svobodová', N'+420987654321', N'petra.svobodova@example.com', CAST(N'2024-02-20T09:45:00.0000000' AS DateTime2))
                GO
                INSERT [dbo].[Reservations] ([Id], [ServiceId], [Name], [Surname], [Phone], [Email], [CreatedAt]) VALUES (5, 2, N'Martin', N'Dvořák', N'+420234567890', N'martin.dvorak@example.com', CAST(N'2024-03-10T11:00:00.0000000' AS DateTime2))
                GO
                INSERT [dbo].[Reservations] ([Id], [ServiceId], [Name], [Surname], [Phone], [Email], [CreatedAt]) VALUES (6, 4, N'Lucie', N'Procházková', N'+420876543210', N'lucie.prochazkova@example.com', CAST(N'2024-04-05T14:15:00.0000000' AS DateTime2))
                GO
                INSERT [dbo].[Reservations] ([Id], [ServiceId], [Name], [Surname], [Phone], [Email], [CreatedAt]) VALUES (7, 5, N'Anna', N'Veselá', N'+420765432109', N'anna.vesela@example.com', CAST(N'2024-06-18T16:30:00.0000000' AS DateTime2))
                GO
                INSERT [dbo].[Reservations] ([Id], [ServiceId], [Name], [Surname], [Phone], [Email], [CreatedAt]) VALUES (8, 6, N'Pavel', N'Černý', N'+420345678901', N'pavel.cerny@example.com', CAST(N'2024-05-12T10:20:00.0000000' AS DateTime2))
                GO
                INSERT [dbo].[Reservations] ([Id], [ServiceId], [Name], [Surname], [Phone], [Email], [CreatedAt]) VALUES (9, 7, N'Eva', N'Horáková', N'+420654321098', N'eva.horakova@example.com', CAST(N'2024-08-30T17:50:00.0000000' AS DateTime2))
                GO
                INSERT [dbo].[Reservations] ([Id], [ServiceId], [Name], [Surname], [Phone], [Email], [CreatedAt]) VALUES (10, 8, N'Karel', N'Kříž', N'+420456789012', N'karel.kriz@example.com', CAST(N'2024-07-22T13:40:00.0000000' AS DateTime2))
                GO
                SET IDENTITY_INSERT [dbo].[Reservations] OFF
                GO
                SET IDENTITY_INSERT [dbo].[Logins] ON 
                GO
                INSERT [dbo].[Logins] ([Id], [Username], [Password], [CreatedAt]) VALUES (1, N'Matej', N'12345', CAST(N'2024-05-23T00:00:00.0000000' AS DateTime2))
                GO
                SET IDENTITY_INSERT [dbo].[Logins] OFF
                GO
                SET IDENTITY_INSERT [dbo].[Pricings] ON 
                GO
                INSERT [dbo].[Pricings] ([Id], [Title], [Description], [SaleAmount], [Amount], [Currency]) VALUES (1, N'Střih vlasů', N'Základní střih vlasů pro muže i ženy', CAST(0.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), N'CZK  ')
                GO
                INSERT [dbo].[Pricings] ([Id], [Title], [Description], [SaleAmount], [Amount], [Currency]) VALUES (2, N'Barvení vlasů
                ', N'Kompletní barvení vlasů s konzultací
                ', CAST(0.10 AS Decimal(18, 2)), CAST(800.00 AS Decimal(18, 2)), N'CZK  ')
                GO
                INSERT [dbo].[Pricings] ([Id], [Title], [Description], [SaleAmount], [Amount], [Currency]) VALUES (3, N'Melír', N'Aplikace melíru pro zvýraznění účesu
                ', CAST(0.15 AS Decimal(18, 2)), CAST(600.00 AS Decimal(18, 2)), N'CZK  ')
                GO
                INSERT [dbo].[Pricings] ([Id], [Title], [Description], [SaleAmount], [Amount], [Currency]) VALUES (6, N'Trvalá', N'Chemická trvalá pro trvalý efekt vln
                ', CAST(0.05 AS Decimal(18, 2)), CAST(700.00 AS Decimal(18, 2)), N'CZK  ')
                GO
                INSERT [dbo].[Pricings] ([Id], [Title], [Description], [SaleAmount], [Amount], [Currency]) VALUES (7, N'Foukaná', N'Profesionální foukaná a styling vlasů
                ', CAST(0.10 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), N'CZK  ')
                GO
                INSERT [dbo].[Pricings] ([Id], [Title], [Description], [SaleAmount], [Amount], [Currency]) VALUES (9, N'Úprava vousů
                ', N'Tvarování a úprava vousů pro muže
                ', CAST(0.15 AS Decimal(18, 2)), CAST(400.00 AS Decimal(18, 2)), N'CZK  ')
                GO
                INSERT [dbo].[Pricings] ([Id], [Title], [Description], [SaleAmount], [Amount], [Currency]) VALUES (10, N'Společenský účes
                ', N'Účes pro zvláštní příležitosti jako svatby a plesy
                ', CAST(0.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), N'CZK  ')
                GO
                INSERT [dbo].[Pricings] ([Id], [Title], [Description], [SaleAmount], [Amount], [Currency]) VALUES (11, N'Regenerace vlasů
                ', N'Hloubková regenerace a výživa vlasů
                ', CAST(0.05 AS Decimal(18, 2)), CAST(900.00 AS Decimal(18, 2)), N'CZK  ')
                GO
                SET IDENTITY_INSERT [dbo].[Pricings] OFF
                GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
