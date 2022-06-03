using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dhbwin");

            migrationBuilder.CreateTable(
                name: "Achievement",
                schema: "dhbwin",
                columns: table => new
                {
                    AchID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "char(500)", unicode: false, fixedLength: true, maxLength: 500, nullable: true),
                    ExpPoints = table.Column<int>(type: "int", nullable: true),
                    Reward = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Achievement_pk", x => x.AchID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: true),
                    Name = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: true),
                    Plz = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Stadt = table.Column<string>(type: "char(100)", unicode: false, fixedLength: true, maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "char(25)", unicode: false, fixedLength: true, maxLength: 25, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "char(500)", unicode: false, fixedLength: true, maxLength: 500, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AchievedAchievement",
                schema: "dhbwin",
                columns: table => new
                {
                    AAID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UID_fk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AchID_fk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AAID_PK", x => x.AAID);
                    table.ForeignKey(
                        name: "AchievedAchievement_Achievement_AchID_fk",
                        column: x => x.AchID_fk,
                        principalSchema: "dhbwin",
                        principalTable: "Achievement",
                        principalColumn: "AchID");
                    table.ForeignKey(
                        name: "User_AchievedAchievement___fk",
                        column: x => x.UID_fk,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bet",
                schema: "dhbwin",
                columns: table => new
                {
                    BetID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UID_fk2 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    ExpPoints = table.Column<int>(type: "int", nullable: false),
                    Reward = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "char(500)", unicode: false, fixedLength: true, maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Bet_pk", x => x.BetID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "UID_fk2",
                        column: x => x.UID_fk2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                schema: "dhbwin",
                columns: table => new
                {
                    JobID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WorkerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    Reward = table.Column<int>(type: "int", nullable: false),
                    ExpPoints = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Job_pk", x => x.JobID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Job_User_UID_fk",
                        column: x => x.ProviderID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Job_worker_fk",
                        column: x => x.WorkerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                },
                comment: "Create jobs with Betcoins");

            migrationBuilder.CreateTable(
                name: "BetOptions",
                schema: "dhbwin",
                columns: table => new
                {
                    OptionsID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BetID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true),
                    Descpription = table.Column<string>(type: "char(500)", unicode: false, fixedLength: true, maxLength: 500, nullable: true),
                    QuoteValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BetOptions_pk", x => x.OptionsID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "BetOptions_Bet_BetID_fk",
                        column: x => x.BetID,
                        principalSchema: "dhbwin",
                        principalTable: "Bet",
                        principalColumn: "BetID");
                });

            migrationBuilder.CreateTable(
                name: "Placement",
                schema: "dhbwin",
                columns: table => new
                {
                    PlacementID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BetID_fk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UID_fk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OptionID_fk = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Placement_pk", x => new { x.UID_fk, x.PlacementID, x.BetID_fk })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Bet_fk",
                        column: x => x.BetID_fk,
                        principalSchema: "dhbwin",
                        principalTable: "Bet",
                        principalColumn: "BetID");
                    table.ForeignKey(
                        name: "Placement_BetOptions_OptionsID_fk",
                        column: x => x.OptionID_fk,
                        principalSchema: "dhbwin",
                        principalTable: "BetOptions",
                        principalColumn: "OptionsID");
                    table.ForeignKey(
                        name: "User_fk",
                        column: x => x.UID_fk,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "AchievedAchievement_AchID_fk_uindex",
                schema: "dhbwin",
                table: "AchievedAchievement",
                column: "AchID_fk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AchievedAchievement_UID_fk",
                schema: "dhbwin",
                table: "AchievedAchievement",
                column: "UID_fk");

            migrationBuilder.CreateIndex(
                name: "Achievement_AchID_uindex",
                schema: "dhbwin",
                table: "Achievement",
                column: "AchID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Bet_BetID_uindex",
                schema: "dhbwin",
                table: "Bet",
                column: "BetID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UID_fk2",
                schema: "dhbwin",
                table: "Bet",
                column: "UID_fk2");

            migrationBuilder.CreateIndex(
                name: "BetOptions_OptionsID_uindex",
                schema: "dhbwin",
                table: "BetOptions",
                column: "OptionsID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BetOptions_BetID",
                schema: "dhbwin",
                table: "BetOptions",
                column: "BetID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_ProviderID",
                schema: "dhbwin",
                table: "Job",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_WorkerID",
                schema: "dhbwin",
                table: "Job",
                column: "WorkerID");

            migrationBuilder.CreateIndex(
                name: "Job_JobID_uindex",
                schema: "dhbwin",
                table: "Job",
                column: "JobID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Placement_BetID_fk",
                schema: "dhbwin",
                table: "Placement",
                column: "BetID_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Placement_OptionID_fk",
                schema: "dhbwin",
                table: "Placement",
                column: "OptionID_fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchievedAchievement",
                schema: "dhbwin");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Job",
                schema: "dhbwin");

            migrationBuilder.DropTable(
                name: "Placement",
                schema: "dhbwin");

            migrationBuilder.DropTable(
                name: "Achievement",
                schema: "dhbwin");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BetOptions",
                schema: "dhbwin");

            migrationBuilder.DropTable(
                name: "Bet",
                schema: "dhbwin");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
