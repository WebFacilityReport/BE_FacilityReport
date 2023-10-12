﻿using System;
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
                    role = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.accountId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    postId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    title = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    image = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.postId);
                    table.ForeignKey(
                        name: "FK__Post__accountId__3C69FB99",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Task", x => x.taskId);
                    table.ForeignKey(
                        name: "FK__Task__creatorId__4316F928",
                        column: x => x.creatorId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK__Task__employeeId__440B1D61",
                        column: x => x.employeeId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    feedBackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false),
                    comment = table.Column<string>(type: "varchar(5000)", unicode: false, maxLength: 5000, nullable: false),
                    numberFeedBack = table.Column<int>(type: "int", nullable: false),
                    reportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.feedBackId);
                    table.ForeignKey(
                        name: "FK__Feedback__accoun__403A8C7D",
                        column: x => x.accountId,
                        principalTable: "Account",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK__Feedback__report__3F466844",
                        column: x => x.reportId,
                        principalTable: "Post",
                        principalColumn: "postId");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    imageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameImage = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    dateImgae = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    postId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.imageId);
                    table.ForeignKey(
                        name: "FK__Image__postId__5070F446",
                        column: x => x.postId,
                        principalTable: "Post",
                        principalColumn: "postId");
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    resourcesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameResource = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    description = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    usedQuantity_ = table.Column<int>(type: "int", nullable: false),
                    totalQuantity_ = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    size = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    created_at = table.Column<DateTime>(type: "date", nullable: false),
                    image = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    taskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resource__557C3399331034E6", x => x.resourcesId);
                    table.ForeignKey(
                        name: "FK__Resources__taskI__46E78A0C",
                        column: x => x.taskId,
                        principalTable: "Task",
                        principalColumn: "taskId");
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
                    reportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    resourcesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.equipmentId);
                    table.ForeignKey(
                        name: "FK__Equipment__repor__49C3F6B7",
                        column: x => x.reportId,
                        principalTable: "Post",
                        principalColumn: "postId");
                    table.ForeignKey(
                        name: "FK__Equipment__resou__4AB81AF0",
                        column: x => x.resourcesId,
                        principalTable: "Resources",
                        principalColumn: "resourcesId");
                });

            migrationBuilder.CreateTable(
                name: "HistoryEquipment",
                columns: table => new
                {
                    historyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    nameHistory = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: false),
                    equipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HistoryE__19BDBDD35836AD21", x => x.historyId);
                    table.ForeignKey(
                        name: "FK__HistoryEq__equip__4D94879B",
                        column: x => x.equipmentId,
                        principalTable: "Equipment",
                        principalColumn: "equipmentId");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Account__AB6E616404176BC4",
                table: "Account",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Account__B43B145F50121052",
                table: "Account",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Account__F3DBC57223143E54",
                table: "Account",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_reportId",
                table: "Equipment",
                column: "reportId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_resourcesId",
                table: "Equipment",
                column: "resourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_accountId",
                table: "Feedback",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_reportId",
                table: "Feedback",
                column: "reportId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEquipment_equipmentId",
                table: "HistoryEquipment",
                column: "equipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_postId",
                table: "Image",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_accountId",
                table: "Post",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_taskId",
                table: "Resources",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_creatorId",
                table: "Task",
                column: "creatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_employeeId",
                table: "Task",
                column: "employeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "HistoryEquipment");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
