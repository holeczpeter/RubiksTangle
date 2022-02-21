using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Linq;

namespace RubiksTangle.Core.Migrations
{
    public partial class seed_update_pictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cards");
            var pics = Directory.GetFiles(path);
            foreach (var (picture, index) in pics.Select((picture, i) => (picture, i)))
            {
                var pic = File.ReadAllBytes(picture);
                migrationBuilder.UpdateData(
                   table: "Cards",
                   keyColumn: "Id",
                   keyValue: index + 1,
                   column: "Picture",
                   value: pic);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update Cards set Pictre = NULL");
        }
    }
}
