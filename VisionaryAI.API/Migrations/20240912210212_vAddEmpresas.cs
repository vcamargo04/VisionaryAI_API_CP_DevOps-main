using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisionaryAI.API.Migrations
{
    /// <inheritdoc />
    public partial class vAddEmpresas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cnpj = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    e_mail = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_empresas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_empresas");
        }
    }
}
