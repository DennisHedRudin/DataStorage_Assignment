using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CustomerContact_CustomerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CustomerContact_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_users_UserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_users_Roles_RolesId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerContact",
                table: "CustomerContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CustomerId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "CustomerContact",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "CustomerContacts");

            migrationBuilder.RenameIndex(
                name: "IX_users_RolesId",
                table: "Users",
                newName: "IX_Users_RolesId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerContactId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerContacts",
                table: "CustomerContacts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerContactId",
                table: "Customer",
                column: "CustomerContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_CustomerContacts_CustomerContactId",
                table: "Customer",
                column: "CustomerContactId",
                principalTable: "CustomerContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customer_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_CustomerContacts_CustomerContactId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customer_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerContacts",
                table: "CustomerContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomerContactId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerContactId",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "CustomerContacts",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "CustomerContact");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RolesId",
                table: "users",
                newName: "IX_users_RolesId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerContact",
                table: "CustomerContact",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CustomerId",
                table: "Contacts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CustomerContact_CustomerId",
                table: "Contacts",
                column: "CustomerId",
                principalTable: "CustomerContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_CustomerContact_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "CustomerContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_Roles_RolesId",
                table: "users",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
