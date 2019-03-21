using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zeww.Migrations
{
    public partial class emailVisible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 15, nullable: false),
                    UserName = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ConnectionStatus = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    DailyDoNotDisturbFrom = table.Column<int>(nullable: true),
                    DailyDoNotDisturbTo = table.Column<int>(nullable: true),
                    Customstatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkspaceName = table.Column<string>(nullable: false),
                    CreatorID = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    WorkspaceProjectName = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    DailyDoNotDisturbFrom = table.Column<int>(nullable: true),
                    DailyDoNotDisturbTo = table.Column<int>(nullable: true),
                    IsEmailVisible = table.Column<bool>(nullable: false),
                    WorkspaceImageId = table.Column<string>(nullable: true),
                    WorkspaceImageName = table.Column<string>(nullable: true),
                    CanInviteUsersToWorkspace = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkspaceId = table.Column<int>(nullable: false),
                    CreatorID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    skip = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkspaces",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    WorkspaceId = table.Column<int>(nullable: false),
                    TimeToWhichNotificationsAreMuted = table.Column<DateTime>(nullable: false),
                    UserRoleInWorkspace = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkspaces", x => new { x.WorkspaceId, x.UserId });
                    table.UniqueConstraint("AK_UserWorkspaces_UserId_WorkspaceId", x => new { x.UserId, x.WorkspaceId });
                    table.ForeignKey(
                        name: "FK_UserWorkspaces_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkspaces_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Source = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ChatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SenderID = table.Column<int>(nullable: false),
                    ChatId = table.Column<int>(nullable: false),
                    MessageContent = table.Column<string>(nullable: true),
                    isPinned = table.Column<bool>(nullable: false),
                    dateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChats",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ChatId = table.Column<int>(nullable: false),
                    IsStarred = table.Column<bool>(nullable: false),
                    IsMuted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => new { x.ChatId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserChats_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_WorkspaceId",
                table: "Chats",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ChatId",
                table: "Files",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_UserId",
                table: "UserChats",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.DropTable(
                name: "UserWorkspaces");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Workspaces");
        }
    }
}
