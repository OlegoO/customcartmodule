using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NB.CartModule.Data.Migrations
{
    public partial class InitialCartExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(name: "PrescriptionId", table: "CartLineItem", maxLength: 128, nullable: true);
            migrationBuilder.AddColumn<string>(name: "Discriminator", table: "CartLineItem", nullable: false, maxLength: 128, defaultValue: "NBCartLineItemEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("PrescriptionId", "CartLineItem");
            migrationBuilder.DropColumn("Discriminator", "CartLineItem");
        }
    }
}
