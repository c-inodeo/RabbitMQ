using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RabbitMQApplication.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateChatDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "ChatMessages",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "ChatMessages");
        }
    }
}
