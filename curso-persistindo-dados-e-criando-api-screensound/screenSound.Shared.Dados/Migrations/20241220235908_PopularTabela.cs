﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Pitty", "Ótima dubladora", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Restart", "Banda Colorida", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });
            migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }, new object[] { "Aerosmith", "Boa banda", "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Artistas");
        }
    }
}
