using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace wujiErp.ModelMigragions.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Addr = table.Column<string>(type: "text", nullable: true),
                    WhereFrom = table.Column<string>(type: "text", nullable: true),
                    WechatCode = table.Column<string>(type: "text", nullable: true),
                    Love = table.Column<string>(type: "text", nullable: true),
                    LastOrderTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Norm = table.Column<string>(type: "text", nullable: true),
                    Delivery = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CostPrice = table.Column<double>(type: "double precision", nullable: false),
                    LastPrice = table.Column<double>(type: "double precision", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProduceId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CostPrice = table.Column<double>(type: "double precision", nullable: false),
                    Num = table.Column<double>(type: "double precision", nullable: false),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    OtherAddr = table.Column<string>(type: "text", nullable: true),
                    OrderCode = table.Column<string>(type: "text", nullable: true),
                    IsAftersale = table.Column<bool>(type: "boolean", nullable: false),
                    AftersalePrice = table.Column<double>(type: "double precision", nullable: false),
                    OrderFrom = table.Column<string>(type: "text", nullable: true),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Produce_ProduceId",
                        column: x => x.ProduceId,
                        principalTable: "Produce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Addr", "CreatedTime", "DeletedTime", "IsDeleted", "LastOrderTime", "Love", "Name", "Phone", "UpdatedTime", "WechatCode", "WhereFrom" },
                values: new object[] { 1, "江苏省苏州市姑苏区东汇路187号 2-103", new DateTime(2023, 6, 21, 2, 25, 51, 697, DateTimeKind.Utc).AddTicks(5966), null, false, new DateTime(2023, 6, 21, 2, 25, 51, 697, DateTimeKind.Utc).AddTicks(5972), "水果", "张文静", "13952401683", null, "violame", "微信" });

            migrationBuilder.InsertData(
                table: "Produce",
                columns: new[] { "Id", "CostPrice", "CreatedTime", "DeletedTime", "Delivery", "IsDeleted", "LastPrice", "Name", "Norm", "Price", "Remark", "Source", "UpdatedTime" },
                values: new object[] { 1, 15.0, new DateTime(2023, 6, 21, 2, 25, 51, 705, DateTimeKind.Utc).AddTicks(222), null, "德邦物流", false, 50.0, "昭通丑苹果", "5斤大果", 50.0, "又甜又脆很好吃", "云南昭通", null });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "AftersalePrice", "CostPrice", "CreatedTime", "CustomerId", "DeletedTime", "IsAftersale", "IsDeleted", "Num", "OrderCode", "OrderFrom", "OrderStatus", "OtherAddr", "Price", "ProduceId", "Remark", "TotalPrice", "UpdatedTime" },
                values: new object[] { 1, 0.0, 15.0, new DateTime(2023, 6, 21, 2, 25, 51, 704, DateTimeKind.Utc).AddTicks(7505), 1, null, false, false, 1.0, "SF15645648951516554", "微信", 1, "", 50.0, 1, "好评", 50.0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProduceId",
                table: "Order",
                column: "ProduceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Produce");
        }
    }
}
