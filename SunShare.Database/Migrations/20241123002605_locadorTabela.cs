using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunShare.Database.Migrations
{
    /// <inheritdoc />
    public partial class locadorTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_contratos_ss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    LocadorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LocatarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Duration = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AmountOfEnergy = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    TermsAndConditions = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_contratos_ss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_locadores_ss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    PowerCompany = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    AverageProduction = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AvailableEnergy = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_locadores_ss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_locatarios_ss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    PowerCompany = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    AverageUsage = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_locatarios_ss", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_contratos_ss");

            migrationBuilder.DropTable(
                name: "tb_locadores_ss");

            migrationBuilder.DropTable(
                name: "tb_locatarios_ss");
        }
    }
}
