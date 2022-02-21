using Microsoft.EntityFrameworkCore.Migrations;
using RubiksTangle.Core.Entities;

namespace RubiksTangle.Core.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                  table: "Cards",
                  columns: new[] { "Id", "OrdinalNumber","Rotation" },
                  values: new object[,]
                  {

                    { 1, 1 , 0},
                    { 2, 2 , 0},
                    { 3, 3 , 0},
                    { 4, 4 , 0},
                    { 5, 5 , 0},
                    { 6, 6 , 0},
                    { 7, 7 , 0},
                    { 8, 8 , 0},
                    { 9, 9 , 0},

                   });

            migrationBuilder.InsertData(
                  table: "Points",
                  columns: new[] { "Id", "CardId", "OrdinalNumber", "Side", "Color" },
                  values: new object[,]
                  {

                    {  1, 1, 1, (int)Sides.A, (int)Colors.Yellow },
                    {  2, 1, 2, (int)Sides.A, (int)Colors.Green },
                    {  3, 1, 1, (int)Sides.B, (int)Colors.Red },
                    {  4, 1, 2, (int)Sides.B, (int)Colors.Green },
                    {  5, 1, 1, (int)Sides.C, (int)Colors.Yellow },
                    {  6, 1, 2, (int)Sides.C, (int)Colors.Blue },
                    {  7, 1, 1, (int)Sides.D, (int)Colors.Blue },
                    {  8, 1, 2, (int)Sides.D, (int)Colors.Red },

                    {  9, 2, 1, (int)Sides.A, (int)Colors.Yellow },
                    { 10, 2, 2, (int)Sides.A, (int)Colors.Blue },
                    { 11, 2, 1, (int)Sides.B, (int)Colors.Red },
                    { 12, 2, 2, (int)Sides.B, (int)Colors.Blue },
                    { 13, 2, 1, (int)Sides.C, (int)Colors.Yellow },
                    { 14, 2, 2, (int)Sides.C, (int)Colors.Green },
                    { 15, 2, 1, (int)Sides.D, (int)Colors.Green },
                    { 16, 2, 2, (int)Sides.D, (int)Colors.Red },

                    { 17, 3, 1, (int)Sides.A, (int)Colors.Yellow },
                    { 18, 3, 2, (int)Sides.A, (int)Colors.Blue },
                    { 19, 3, 1, (int)Sides.B, (int)Colors.Green },
                    { 20, 3, 2, (int)Sides.B, (int)Colors.Blue },
                    { 21, 3, 1, (int)Sides.C, (int)Colors.Yellow },
                    { 22, 3, 2, (int)Sides.C, (int)Colors.Red },
                    { 23, 3, 1, (int)Sides.D, (int)Colors.Red },
                    { 24, 3, 2, (int)Sides.D, (int)Colors.Green },

                    { 25, 4, 1, (int)Sides.A, (int)Colors.Red },
                    { 26, 4, 2, (int)Sides.A, (int)Colors.Green },
                    { 27, 4, 1, (int)Sides.B, (int)Colors.Yellow },
                    { 28, 4, 2, (int)Sides.B, (int)Colors.Green },
                    { 29, 4, 1, (int)Sides.C, (int)Colors.Red },
                    { 30, 4, 2, (int)Sides.C, (int)Colors.Blue },
                    { 31, 4, 1, (int)Sides.D, (int)Colors.Blue },
                    { 32, 4, 2, (int)Sides.D, (int)Colors.Yellow },

                    { 33, 5, 1, (int)Sides.A, (int)Colors.Blue },
                    { 34, 5, 2, (int)Sides.A, (int)Colors.Green },
                    { 35, 5, 1, (int)Sides.B, (int)Colors.Yellow },
                    { 36, 5, 2, (int)Sides.B, (int)Colors.Green },
                    { 37, 5, 1, (int)Sides.C, (int)Colors.Blue },
                    { 38, 5, 2, (int)Sides.C, (int)Colors.Red },
                    { 39, 5, 1, (int)Sides.D, (int)Colors.Red },
                    { 40, 5, 2, (int)Sides.D, (int)Colors.Yellow },

                    { 41, 6, 1, (int)Sides.A, (int)Colors.Green },
                    { 42, 6, 2, (int)Sides.A, (int)Colors.Red },
                    { 43, 6, 1, (int)Sides.B, (int)Colors.Blue },
                    { 44, 6, 2, (int)Sides.B, (int)Colors.Red },
                    { 45, 6, 1, (int)Sides.C, (int)Colors.Green },
                    { 46, 6, 2, (int)Sides.C, (int)Colors.Yellow },
                    { 47, 6, 1, (int)Sides.D, (int)Colors.Yellow },
                    { 48, 6, 2, (int)Sides.D, (int)Colors.Blue },

                    { 49, 7, 1, (int)Sides.A, (int)Colors.Green },
                    { 50, 7, 2, (int)Sides.A, (int)Colors.Blue },
                    { 51, 7, 1, (int)Sides.B, (int)Colors.Red },
                    { 52, 7, 2, (int)Sides.B, (int)Colors.Blue },
                    { 53, 7, 1, (int)Sides.C, (int)Colors.Green },
                    { 54, 7, 2, (int)Sides.C, (int)Colors.Yellow },
                    { 55, 7, 1, (int)Sides.D, (int)Colors.Yellow },
                    { 56, 7, 2, (int)Sides.D, (int)Colors.Red },

                    { 57, 8, 1, (int)Sides.A, (int)Colors.Green },
                    { 58, 8, 2, (int)Sides.A, (int)Colors.Red },
                    { 59, 8, 1, (int)Sides.B, (int)Colors.Yellow },
                    { 60, 8, 2, (int)Sides.B, (int)Colors.Red },
                    { 61, 8, 1, (int)Sides.C, (int)Colors.Green },
                    { 62, 8, 2, (int)Sides.C, (int)Colors.Blue },
                    { 63, 8, 1, (int)Sides.D, (int)Colors.Blue },
                    { 64 ,8, 2, (int)Sides.D, (int)Colors.Yellow },

                    { 65, 9, 1, (int)Sides.A, (int)Colors.Blue },
                    { 66, 9, 2, (int)Sides.A, (int)Colors.Yellow },
                    { 67, 9, 1, (int)Sides.B, (int)Colors.Green },
                    { 68, 9, 2, (int)Sides.B, (int)Colors.Yellow },
                    { 69, 9, 1, (int)Sides.C, (int)Colors.Blue },
                    { 70, 9, 2, (int)Sides.C, (int)Colors.Red },
                    { 71, 9, 1, (int)Sides.D, (int)Colors.Red },
                    { 72, 9, 2, (int)Sides.D, (int)Colors.Green }
                 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete Positions");
            migrationBuilder.Sql("Delete Cards");
        }
    }
}
