using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreetFood.DAL.Migrations {
  /// <inheritdoc />
  public partial class UpdateOrderTableProperties3 : Migration {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.AddColumn<decimal>(
            name: "OpenDate",
            table: "Orders",
            type: "datetime2",
            nullable: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropColumn(
                name: "OpenDate",
                table: "Orders");
    }
  }
}
