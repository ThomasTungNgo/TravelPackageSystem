using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TPS.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ASCII = table.Column<string>(maxLength: 255, nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Country = table.Column<string>(maxLength: 255, nullable: false),
                    Code = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelPackages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false, defaultValueSql: "1"),
                    RRP = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityAttractions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityAttractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityAttractions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelPackageCities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TravelPackageId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    NumberOfDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPackageCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelPackageCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelPackageCities_TravelPackages_TravelPackageId",
                        column: x => x.TravelPackageId,
                        principalTable: "TravelPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TravelProviderId = table.Column<int>(nullable: false),
                    Forename = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    PersonType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_TravelProviders_TravelProviderId",
                        column: x => x.TravelProviderId,
                        principalTable: "TravelProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelPackageCityAttractions",
                columns: table => new
                {
                    TravelPackageCityId = table.Column<int>(nullable: false),
                    CityAttractionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPackageCityAttractions", x => new { x.CityAttractionId, x.TravelPackageCityId });
                    table.ForeignKey(
                        name: "FK_TravelPackageCityAttractions_CityAttractions_CityAttractionId",
                        column: x => x.CityAttractionId,
                        principalTable: "CityAttractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelPackageCityAttractions_TravelPackageCities_TravelPackageCityId",
                        column: x => x.TravelPackageCityId,
                        principalTable: "TravelPackageCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DiscountPercentage = table.Column<int>(nullable: false),
                    Expires = table.Column<DateTime>(nullable: false, defaultValueSql: "DATEADD(month, 3, GETDATE())"),
                    Valid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vouchers_People_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTravelPackages",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    TravelPackageId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    SalePrice = table.Column<decimal>(nullable: false),
                    Feedback = table.Column<string>(nullable: true),
                    VoucherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTravelPackages", x => new { x.CustomerId, x.TravelPackageId });
                    table.ForeignKey(
                        name: "FK_CustomerTravelPackages_People_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTravelPackages_TravelPackages_TravelPackageId",
                        column: x => x.TravelPackageId,
                        principalTable: "TravelPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTravelPackages_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerTravelPackageId = table.Column<int>(nullable: false),
                    CustomerTravelPackageCustomerId = table.Column<int>(nullable: false),
                    CustomerTravelPackageTravelPackageId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentType = table.Column<string>(nullable: false),
                    TransactionHashcode = table.Column<string>(nullable: true),
                    RecordOfCharge = table.Column<string>(nullable: true),
                    PayPalPayment_RecordOfCharge = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_CustomerTravelPackages_CustomerTravelPackageCustomerId_CustomerTravelPackageTravelPackageId",
                        columns: x => new { x.CustomerTravelPackageCustomerId, x.CustomerTravelPackageTravelPackageId },
                        principalTable: "CustomerTravelPackages",
                        principalColumns: new[] { "CustomerId", "TravelPackageId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityAttractions_CityId",
                table: "CityAttractions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTravelPackages_TravelPackageId",
                table: "CustomerTravelPackages",
                column: "TravelPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTravelPackages_VoucherId",
                table: "CustomerTravelPackages",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerTravelPackageCustomerId_CustomerTravelPackageTravelPackageId",
                table: "Payments",
                columns: new[] { "CustomerTravelPackageCustomerId", "CustomerTravelPackageTravelPackageId" });

            migrationBuilder.CreateIndex(
                name: "IX_People_TravelProviderId",
                table: "People",
                column: "TravelProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackageCities_CityId",
                table: "TravelPackageCities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackageCities_TravelPackageId",
                table: "TravelPackageCities",
                column: "TravelPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackageCityAttractions_TravelPackageCityId",
                table: "TravelPackageCityAttractions",
                column: "TravelPackageCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_CustomerId",
                table: "Vouchers",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TravelPackageCityAttractions");

            migrationBuilder.DropTable(
                name: "CustomerTravelPackages");

            migrationBuilder.DropTable(
                name: "CityAttractions");

            migrationBuilder.DropTable(
                name: "TravelPackageCities");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "TravelPackages");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "TravelProviders");
        }
    }
}
