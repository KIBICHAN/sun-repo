using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartRent.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CorporationName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OwnerImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "PostStatuses",
                columns: table => new
                {
                    PostStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostStatuses", x => x.PostStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PostTypes",
                columns: table => new
                {
                    PostTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDescription = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTypes", x => x.PostTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<float>(type: "real", nullable: false),
                    NumberOfBedroom = table.Column<int>(type: "int", nullable: false),
                    NumberOfBathroom = table.Column<int>(type: "int", nullable: false),
                    HouseDirection = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    BalconyDirection = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    LegalInformation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ApartmentImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartments_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    PostStatusId = table.Column<int>(type: "int", nullable: false),
                    PostTypeId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_PostStatuses_PostStatusId",
                        column: x => x.PostStatusId,
                        principalTable: "PostStatuses",
                        principalColumn: "PostStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_PostTypes_PostTypeId",
                        column: x => x.PostTypeId,
                        principalTable: "PostTypes",
                        principalColumn: "PostTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "Email", "Name", "OwnerImgUrl", "Phone" },
                values: new object[] { 1, "Lee Sang-hyeok@mail", "이상혁", "https://static.wikia.nocookie.net/lolesports_gamepedia_en/images/7/78/T1logo_profile.png/revision/latest/scale-to-width-down/220?cb=20210402012553", "2022112119" });

            migrationBuilder.InsertData(
                table: "PostStatuses",
                columns: new[] { "PostStatusId", "StatusDescription" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Waiting" },
                    { 3, "Draft" },
                    { 4, "Deactivate" }
                });

            migrationBuilder.InsertData(
                table: "PostTypes",
                columns: new[] { "PostTypeId", "TypeDescription" },
                values: new object[,]
                {
                    { 1, "For rent" },
                    { 2, "For selling" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_BuildingId",
                table: "Apartments",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ApartmentId",
                table: "Posts",
                column: "ApartmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_OwnerId",
                table: "Posts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostStatusId",
                table: "Posts",
                column: "PostStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostTypeId",
                table: "Posts",
                column: "PostTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "PostStatuses");

            migrationBuilder.DropTable(
                name: "PostTypes");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
