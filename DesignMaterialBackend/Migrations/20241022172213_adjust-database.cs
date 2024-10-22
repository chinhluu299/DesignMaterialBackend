using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignMaterialBackend.Migrations
{
    /// <inheritdoc />
    public partial class adjustdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 0, 22, 12, 585, DateTimeKind.Local).AddTicks(5659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 15, 23, 23, 58, 294, DateTimeKind.Local).AddTicks(6236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 23, 0, 22, 12, 585, DateTimeKind.Local).AddTicks(6102),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 15, 23, 23, 58, 294, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "CurrencyUnits",
                keyColumn: "Id",
                keyValue: new Guid("4b3d1bda-7a32-406a-868f-2c07f27607b4"),
                column: "CreateAt",
                value: new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "ExchangeRates",
                keyColumn: "Id",
                keyValue: new Guid("fd5ed73b-81a3-4a2b-ba9f-73a2a491b1d6"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1394), new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("1297b179-a53b-4744-b972-2d89052a8579"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1441), new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1442) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("19713c48-f765-4767-a740-97016453f68b"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1444), new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1444) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("3d08304c-8fea-4889-9112-12e432aecf8d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1446), new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1447) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("5b541003-b171-4c4b-b2a7-bc91b71fd81f"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1442), new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1443) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("7669e3da-034c-496f-bfb6-bd4f4d18146e"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1445), new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1446) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: new Guid("b457ef8e-3371-4b59-8f46-a1ddfe18b10f"),
                column: "CreateAt",
                value: new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: new Guid("d7296a15-fa42-4f7b-b70f-066fae86a83b"),
                column: "CreateAt",
                value: new DateTime(2024, 10, 23, 0, 22, 12, 586, DateTimeKind.Local).AddTicks(1415));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 15, 23, 23, 58, 294, DateTimeKind.Local).AddTicks(6236),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 23, 0, 22, 12, 585, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 15, 23, 23, 58, 294, DateTimeKind.Local).AddTicks(6681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 23, 0, 22, 12, 585, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "CurrencyUnits",
                keyColumn: "Id",
                keyValue: new Guid("4b3d1bda-7a32-406a-868f-2c07f27607b4"),
                column: "CreateAt",
                value: new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "ExchangeRates",
                keyColumn: "Id",
                keyValue: new Guid("fd5ed73b-81a3-4a2b-ba9f-73a2a491b1d6"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1655), new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1655) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("1297b179-a53b-4744-b972-2d89052a8579"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1712), new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1713) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("19713c48-f765-4767-a740-97016453f68b"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1714), new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1715) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("3d08304c-8fea-4889-9112-12e432aecf8d"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1717), new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1718) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("5b541003-b171-4c4b-b2a7-bc91b71fd81f"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1713), new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1714) });

            migrationBuilder.UpdateData(
                table: "MaterialTypes",
                keyColumn: "Id",
                keyValue: new Guid("7669e3da-034c-496f-bfb6-bd4f4d18146e"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1716), new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1716) });

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: new Guid("b457ef8e-3371-4b59-8f46-a1ddfe18b10f"),
                column: "CreateAt",
                value: new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: new Guid("d7296a15-fa42-4f7b-b70f-066fae86a83b"),
                column: "CreateAt",
                value: new DateTime(2024, 10, 15, 23, 23, 58, 295, DateTimeKind.Local).AddTicks(1681));
        }
    }
}
