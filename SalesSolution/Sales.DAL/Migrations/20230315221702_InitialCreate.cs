using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sales.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElementTypes",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementTypes", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.UId);
                    table.ForeignKey(
                        name: "FK_Windows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubElements",
                columns: table => new
                {
                    UId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Element = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ElementTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WindowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubElements", x => x.UId);
                    table.ForeignKey(
                        name: "FK_SubElements_ElementTypes_ElementTypeId",
                        column: x => x.ElementTypeId,
                        principalTable: "ElementTypes",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubElements_Windows_WindowId",
                        column: x => x.WindowId,
                        principalTable: "Windows",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ElementTypes",
                columns: new[] { "UId", "Name" },
                values: new object[,]
                {
                    { new Guid("6d2c8ccb-731b-4ab8-8ec8-089c25917522"), "Doors" },
                    { new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), "Window" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "UId", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("4b103f67-130e-4e20-b4d4-7023871bc52a"), "California Hotel AJK", "CA" },
                    { new Guid("b3ca33e7-c319-40fd-a681-7e479364a352"), "New York Building 1", "NY" }
                });

            migrationBuilder.InsertData(
                table: "Windows",
                columns: new[] { "UId", "Name", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("1b110392-9652-44b3-81c5-ff2f8689e873"), "C Zone 5", new Guid("b3ca33e7-c319-40fd-a681-7e479364a352"), 2 },
                    { new Guid("a06e1626-10e7-472b-9373-0d673868c699"), "OHF", new Guid("4b103f67-130e-4e20-b4d4-7023871bc52a"), 10 },
                    { new Guid("a6831805-0892-4b76-878a-32d586d49aad"), "A51", new Guid("b3ca33e7-c319-40fd-a681-7e479364a352"), 4 },
                    { new Guid("d1f084c1-0c59-4ee3-8674-af2ece39c7bd"), "GLB", new Guid("4b103f67-130e-4e20-b4d4-7023871bc52a"), 3 }
                });

            migrationBuilder.InsertData(
                table: "SubElements",
                columns: new[] { "UId", "Element", "ElementTypeId", "Height", "Quantity", "Width", "WindowId" },
                values: new object[,]
                {
                    { new Guid("15c6e0a1-048f-4766-a622-d16caa14dbf7"), 1, new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), 2000, 1, 1500, new Guid("1b110392-9652-44b3-81c5-ff2f8689e873") },
                    { new Guid("b3ae868a-fb83-40d9-8b04-50b8207357b1"), 3, new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), 1850, 1, 700, new Guid("a6831805-0892-4b76-878a-32d586d49aad") },
                    { new Guid("b76d17b2-73c6-4071-99ca-40c7fde6c988"), 1, new Guid("6d2c8ccb-731b-4ab8-8ec8-089c25917522"), 1850, 1, 1200, new Guid("a6831805-0892-4b76-878a-32d586d49aad") },
                    { new Guid("de86fd8d-c953-48bb-bef5-b8b7f90bf6c1"), 1, new Guid("6d2c8ccb-731b-4ab8-8ec8-089c25917522"), 2200, 1, 1400, new Guid("d1f084c1-0c59-4ee3-8674-af2ece39c7bd") },
                    { new Guid("f534c91e-c0df-4e80-acf7-0a3907669dbb"), 1, new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), 2000, 2, 1500, new Guid("a06e1626-10e7-472b-9373-0d673868c699") },
                    { new Guid("f86e0c8e-52ea-4dc5-abd0-7394fef50f97"), 2, new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), 1850, 1, 800, new Guid("a6831805-0892-4b76-878a-32d586d49aad") },
                    { new Guid("fa6066d3-7ac5-4a47-95ac-d5757f83893a"), 2, new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"), 2200, 1, 600, new Guid("d1f084c1-0c59-4ee3-8674-af2ece39c7bd") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubElements_ElementTypeId",
                table: "SubElements",
                column: "ElementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubElements_WindowId",
                table: "SubElements",
                column: "WindowId");

            migrationBuilder.CreateIndex(
                name: "IX_Windows_OrderId",
                table: "Windows",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubElements");

            migrationBuilder.DropTable(
                name: "ElementTypes");

            migrationBuilder.DropTable(
                name: "Windows");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
