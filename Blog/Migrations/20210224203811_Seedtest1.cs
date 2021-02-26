using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class Seedtest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainComments");

            migrationBuilder.DropTable(
                name: "SubComments");

            migrationBuilder.CreateTable(
                name: "SeedPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedPosts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SeedPosts",
                columns: new[] { "Id", "Body", "Category", "Created", "Description", "Image", "Tags", "Title" },
                values: new object[] { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "Photography", new DateTime(2021, 2, 24, 20, 38, 11, 403, DateTimeKind.Local).AddTicks(3960), "Styles of photography", "jean-gerber-4GpD1oP-C8U-unsplash.jpg", "photography, camera", "Innovative photography in 2021" });

            migrationBuilder.InsertData(
                table: "SeedPosts",
                columns: new[] { "Id", "Body", "Category", "Created", "Description", "Image", "Tags", "Title" },
                values: new object[] { 2, "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Programing", new DateTime(2021, 2, 24, 20, 38, 11, 403, DateTimeKind.Local).AddTicks(5450), "pic of me working", "glenn-carstens-peters-npxXWgQ33ZQ-unsplash.jpg", "coding, laptop, work", "Working in the tech industry" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeedPosts");

            migrationBuilder.CreateTable(
                name: "MainComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MainCommentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    PostModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainComments_Posts_PostModelId",
                        column: x => x.PostModelId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubComments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_PostModelId",
                table: "MainComments",
                column: "PostModelId");
        }
    }
}
