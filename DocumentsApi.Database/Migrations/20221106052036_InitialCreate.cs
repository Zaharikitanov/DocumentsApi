using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentsApi.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "DocumentName", "FileName", "FileSize", "Version" },
                values: new object[,]
                {
                    { new Guid("19dd725d-d032-413b-bd04-ca89e5c8394b"), "document_instructions", "document_instructions.docx", 2097152L, 1 },
                    { new Guid("42069b65-489e-4aea-bc8d-320acad1c17b"), "advanced_javascript_practices", "advanced_javascript_practices.pdf", 12097152L, 1 },
                    { new Guid("8770e755-ea68-4995-8553-a0b49e4f46ba"), "C# 8.0 and .NET Core 3.0", "C# 8.0 and .NET Core 3.0.docx", 22097152L, 1 },
                    { new Guid("feac3b11-5269-4678-b656-d4fda7c6a889"), "C# in Depth", "C# in Depth.pdf", 32097152L, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
