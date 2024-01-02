using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class Tables_Relation_Established : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ParkingSpotIdFk",
                table: "Tickets",
                column: "ParkingSpotIdFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RateIdFk",
                table: "Tickets",
                column: "RateIdFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ParkingSpotIdFk",
                table: "Rates",
                column: "ParkingSpotIdFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Billings_TicketIdFk",
                table: "Billings",
                column: "TicketIdFk",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Tickets_TicketIdFk",
                table: "Billings",
                column: "TicketIdFk",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_ParkingSpots_ParkingSpotIdFk",
                table: "Rates",
                column: "ParkingSpotIdFk",
                principalTable: "ParkingSpots",
                principalColumn: "ParkingSpotId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ParkingSpots_ParkingSpotIdFk",
                table: "Tickets",
                column: "ParkingSpotIdFk",
                principalTable: "ParkingSpots",
                principalColumn: "ParkingSpotId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Rates_RateIdFk",
                table: "Tickets",
                column: "RateIdFk",
                principalTable: "Rates",
                principalColumn: "RateId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Tickets_TicketIdFk",
                table: "Billings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_ParkingSpots_ParkingSpotIdFk",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ParkingSpots_ParkingSpotIdFk",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Rates_RateIdFk",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ParkingSpotIdFk",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_RateIdFk",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Rates_ParkingSpotIdFk",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Billings_TicketIdFk",
                table: "Billings");
        }
    }
}
