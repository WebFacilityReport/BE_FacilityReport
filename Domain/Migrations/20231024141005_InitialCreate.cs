using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    password = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    email = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    phone = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    address = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    birthday = table.Column<DateTime>(type: "date", nullable: false),
                    role = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.accountId);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    jobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    nameTask = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: false),
                    description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    title = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    deadline = table.Column<DateTime>(type: "date", nullable: false),
                    creatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.jobId);
                    table.ForeignKey(
                        name: "FK__Job__creatorId__3F466844",
                        column: x => x.creatorId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK__Job__employeeId__403A8C7D",
                        column: x => x.employeeId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    resourcesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameResource = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    usedQuantity = table.Column<int>(type: "int", nullable: false),
                    totalQuantity = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    size = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: false),
                    image = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    jobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resource__557C3399398C1175", x => x.resourcesId);
                    table.UniqueConstraint("AK_Resources_jobId", x => x.jobId);
                    table.ForeignKey(
                        name: "FK__Resources__jobId__4316F928",
                        column: x => x.jobId,
                        principalTable: "Job",
                        principalColumn: "jobId");
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    equipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    location = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: false),
                    imageEquip = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    resourcesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.equipmentId);
                    table.ForeignKey(
                        name: "FK__Equipment__resou__45F365D3",
                        column: x => x.resourcesId,
                        principalTable: "Resources",
                        principalColumn: "resourcesId");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    feedBackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    comment = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    numberFeedBack = table.Column<int>(type: "int", nullable: false),
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    equipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.feedBackId);
                    table.ForeignKey(
                        name: "FK__Feedback__accoun__5070F446",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK__Feedback__equipm__5165187F",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "equipmentId");
                });

            migrationBuilder.CreateTable(
                name: "HistoryEquipment",
                columns: table => new
                {
                    historyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    nameHistory = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    equipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    jobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HistoryE__19BDBDD3A787AABA", x => x.historyId);
                    table.UniqueConstraint("AK_HistoryEquipment_jobId", x => x.jobId);
                    table.ForeignKey(
                        name: "FK__HistoryEq__equip__48CFD27E",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "equipmentId");
                    table.ForeignKey(
                        name: "FK__HistoryEq__jobId__49C3F6B7",
                        column: x => x.jobId,
                        principalTable: "Job",
                        principalColumn: "jobId");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    imageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameImage = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    dateImgae = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    feedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.imageId);
                    table.ForeignKey(
                        name: "FK_Image_Feedback_feedbackId",
                        column: x => x.feedbackId,
                        principalTable: "Feedback",
                        principalColumn: "feedBackId");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Account__AB6E616438192AAC",
                table: "Account",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Account__B43B145FCFB2D8F0",
                table: "Account",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Account__F3DBC572E6EDA6FA",
                table: "Account",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_resourcesId",
                table: "Equipment",
                column: "resourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_accountId",
                table: "Feedback",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_equipmentId",
                table: "Feedback",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEquipment_equipmentId",
                table: "HistoryEquipment",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEquipment_jobId",
                table: "HistoryEquipment",
                column: "jobId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_feedbackId",
                table: "Image",
                column: "feedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_creatorId",
                table: "Job",
                column: "creatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_employeeId",
                table: "Job",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_jobId",
                table: "Resources",
                column: "jobId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryEquipment");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
