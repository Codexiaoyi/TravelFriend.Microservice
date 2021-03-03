using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelFriend.UserService.Api.Migrations
{
    public partial class init_user_service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(30) CHARACTER SET utf8mb4", maxLength: 30, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address_Street = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: true),
                    Address_City = table.Column<string>(type: "varchar(10) CHARACTER SET utf8mb4", maxLength: 10, nullable: true),
                    Address_Province = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Avatar = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Birthday_Year = table.Column<int>(type: "int", nullable: true),
                    Birthday_Month = table.Column<int>(type: "int", nullable: true),
                    Birthday_Day = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(30) CHARACTER SET utf8mb4", maxLength: 30, nullable: true),
                    Avatar = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreateTime = table.Column<long>(type: "bigint", nullable: false),
                    CreatePerson = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Introduction = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "team_member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TeamId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsLeader = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_member", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personal");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "team_member");
        }
    }
}
