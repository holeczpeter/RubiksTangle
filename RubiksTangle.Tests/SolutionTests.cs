using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RubiksTangle.Application.Features;
using RubiksTangle.Core;
using RubiksTangle.Core.Entities;
using System;
using System.Collections.Generic;

namespace RubiksTangle.Tests
{
    public class SolutionTests
    {
        private DbContextOptions<RubikDbContext> dbContextOptions = new DbContextOptionsBuilder<RubikDbContext>()
                                                                                  .UseInMemoryDatabase(databaseName: "RubiksTangleTest")
                                                                                  .Options;
        [SetUp]
        public void Setup()
        {

            SeedDb();
        }

        private void SeedDb()
        {
            using var context = new RubikDbContext(dbContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var cards = new List<Card>()
            {
                new  Card(){  Id = 1, Rotation=0, OrdinalNumber = 1 },
                new  Card(){  Id = 2, Rotation=0, OrdinalNumber = 2 },
                new  Card(){  Id = 3, Rotation=0, OrdinalNumber = 3 },
                new  Card(){  Id = 4, Rotation=0, OrdinalNumber = 4 },
                new  Card(){  Id = 5, Rotation=0, OrdinalNumber = 5 },
                new  Card(){  Id = 6, Rotation=0, OrdinalNumber = 6 },
                new  Card(){  Id = 7, Rotation=0, OrdinalNumber = 7 },
                new  Card(){  Id = 8, Rotation=0, OrdinalNumber = 8 },
                new  Card(){  Id = 9, Rotation=0, OrdinalNumber = 9 },
            };
            var points = new List<Point>()
            {
                new Point(){ CardId= 1, Color = Colors.Yellow, OrdinalNumber = 1,Side =  Sides.A},
                new Point(){ CardId= 1, Color = Colors.Green, OrdinalNumber = 2, Side =  Sides.A },
                new Point(){ CardId= 1, Color = Colors.Red, OrdinalNumber = 1,   Side =  Sides.B },
                new Point(){ CardId= 1, Color = Colors.Green, OrdinalNumber = 2, Side =  Sides.B },
                new Point(){ CardId= 1, Color = Colors.Yellow, OrdinalNumber = 1,Side =  Sides.C },
                new Point(){ CardId= 1, Color = Colors.Blue, OrdinalNumber = 2,  Side =  Sides.C },
                new Point(){ CardId= 1, Color = Colors.Blue, OrdinalNumber = 1,   Side =  Sides.D },
                new Point(){ CardId= 1, Color = Colors.Red, OrdinalNumber = 2,  Side =  Sides.D },

                new Point(){ CardId= 2, Color = Colors.Yellow, OrdinalNumber = 1,Side =  Sides.A},
                new Point(){ CardId= 2, Color = Colors.Blue, OrdinalNumber = 2,  Side =  Sides.A },
                new Point(){ CardId= 2, Color = Colors.Red, OrdinalNumber = 1,   Side =  Sides.B },
                new Point(){ CardId= 2, Color = Colors.Blue, OrdinalNumber = 2,  Side =  Sides.B },
                new Point(){ CardId= 2, Color = Colors.Yellow, OrdinalNumber = 1,Side =  Sides.C },
                new Point(){ CardId= 2, Color = Colors.Green, OrdinalNumber = 2, Side =  Sides.C },
                new Point(){ CardId= 2, Color = Colors.Green, OrdinalNumber = 1, Side =  Sides.D },
                new Point(){ CardId= 2, Color = Colors.Red, OrdinalNumber = 2,   Side =  Sides.D },

                new Point(){ CardId= 3, Color = Colors.Yellow, OrdinalNumber = 1,Side =  Sides.A},
                new Point(){ CardId= 3, Color = Colors.Blue, OrdinalNumber = 2,  Side =  Sides.A },
                new Point(){ CardId= 3, Color = Colors.Green, OrdinalNumber = 1, Side =  Sides.B },
                new Point(){ CardId= 3, Color = Colors.Blue, OrdinalNumber = 2,  Side =  Sides.B },
                new Point(){ CardId= 3, Color = Colors.Yellow, OrdinalNumber = 1,Side =  Sides.C },
                new Point(){ CardId= 3, Color = Colors.Red, OrdinalNumber = 2,   Side =  Sides.C },
                new Point(){ CardId= 3, Color = Colors.Red, OrdinalNumber = 1,   Side =  Sides.D },
                new Point(){ CardId= 3, Color = Colors.Green, OrdinalNumber = 2, Side =  Sides.D },

                new Point(){ CardId= 4, Color = Colors.Red, OrdinalNumber = 1,    Side =  Sides.A },
                new Point(){ CardId= 4, Color = Colors.Green, OrdinalNumber = 2,  Side =  Sides.A },
                new Point(){ CardId= 4, Color = Colors.Yellow, OrdinalNumber = 1, Side =  Sides.B },
                new Point(){ CardId= 4, Color = Colors.Green, OrdinalNumber = 2,  Side =  Sides.B },
                new Point(){ CardId= 4, Color = Colors.Red, OrdinalNumber = 1,    Side =  Sides.C },
                new Point(){ CardId= 4, Color = Colors.Blue, OrdinalNumber = 2,   Side =  Sides.C },
                new Point(){ CardId= 4, Color = Colors.Blue, OrdinalNumber = 1,   Side =  Sides.D },
                new Point(){ CardId= 4, Color = Colors.Yellow, OrdinalNumber = 2, Side =  Sides.D },

                new Point(){ CardId= 5, Color = Colors.Blue, OrdinalNumber = 1,   Side =  Sides.A },
                new Point(){ CardId= 5, Color = Colors.Green, OrdinalNumber = 2,  Side =  Sides.A },
                new Point(){ CardId= 5, Color = Colors.Yellow, OrdinalNumber = 1, Side =  Sides.B },
                new Point(){ CardId= 5, Color = Colors.Green, OrdinalNumber = 2,  Side =  Sides.B },
                new Point(){ CardId= 5, Color = Colors.Blue, OrdinalNumber = 1,   Side =  Sides.C },
                new Point(){ CardId= 5, Color = Colors.Red, OrdinalNumber = 2,    Side =  Sides.C },
                new Point(){ CardId= 5, Color = Colors.Red, OrdinalNumber = 1,    Side =  Sides.D },
                new Point(){ CardId= 5, Color = Colors.Yellow, OrdinalNumber = 2, Side =  Sides.D },


                new Point(){ CardId= 6, Color = Colors.Green, OrdinalNumber = 1,   Side =  Sides.A },
                new Point(){ CardId= 6, Color = Colors.Red, OrdinalNumber = 2,     Side =  Sides.A },
                new Point(){ CardId= 6, Color = Colors.Blue, OrdinalNumber = 1,    Side =  Sides.B },
                new Point(){ CardId= 6, Color = Colors.Red, OrdinalNumber = 2,     Side =  Sides.B },
                new Point(){ CardId= 6, Color = Colors.Green, OrdinalNumber = 1,   Side =  Sides.C },
                new Point(){ CardId= 6, Color = Colors.Yellow, OrdinalNumber = 2,  Side =  Sides.C },
                new Point(){ CardId= 6, Color = Colors.Yellow, OrdinalNumber = 1,  Side =  Sides.D },
                new Point(){ CardId= 6, Color = Colors.Blue, OrdinalNumber = 2,    Side =  Sides.D },

                new Point(){ CardId= 7, Color = Colors.Green, OrdinalNumber = 1,   Side =  Sides.A },
                new Point(){ CardId= 7, Color = Colors.Blue, OrdinalNumber = 2,    Side =  Sides.A },
                new Point(){ CardId= 7, Color = Colors.Red, OrdinalNumber = 1,     Side =  Sides.B },
                new Point(){ CardId= 7, Color = Colors.Blue, OrdinalNumber = 2,    Side =  Sides.B },
                new Point(){ CardId= 7, Color = Colors.Green, OrdinalNumber = 1,   Side =  Sides.C },
                new Point(){ CardId= 7, Color = Colors.Yellow, OrdinalNumber = 2,  Side =  Sides.C },
                new Point(){ CardId= 7, Color = Colors.Yellow, OrdinalNumber = 1,  Side =  Sides.D },
                new Point(){ CardId= 7, Color = Colors.Red, OrdinalNumber = 2,     Side =  Sides.D },

                new Point(){ CardId= 8, Color = Colors.Green, OrdinalNumber = 1, Side =  Sides.A },
                new Point(){ CardId= 8, Color = Colors.Red, OrdinalNumber = 2,   Side =  Sides.A },
                new Point(){ CardId= 8, Color = Colors.Yellow, OrdinalNumber = 1,Side =  Sides.B },
                new Point(){ CardId= 8, Color = Colors.Red, OrdinalNumber = 2,   Side =  Sides.B },
                new Point(){ CardId= 8, Color = Colors.Green, OrdinalNumber = 1, Side =  Sides.C },
                new Point(){ CardId= 8, Color = Colors.Blue, OrdinalNumber = 2,  Side =  Sides.C },
                new Point(){ CardId= 8, Color = Colors.Blue, OrdinalNumber = 1,  Side =  Sides.D },
                new Point(){ CardId= 8, Color = Colors.Yellow, OrdinalNumber = 2,Side =  Sides.D },

                new Point(){ CardId= 9, Color = Colors.Blue, OrdinalNumber = 1,  Side =  Sides.A },
                new Point(){ CardId= 9, Color = Colors.Yellow, OrdinalNumber = 2,Side =  Sides.A },
                new Point(){ CardId= 9, Color = Colors.Green, OrdinalNumber = 1, Side =  Sides.B },
                new Point(){ CardId= 9, Color = Colors.Yellow, OrdinalNumber = 2,Side =  Sides.B },
                new Point(){ CardId= 9, Color = Colors.Blue, OrdinalNumber = 1,  Side =  Sides.C },
                new Point(){ CardId= 9, Color = Colors.Red, OrdinalNumber = 2,   Side =  Sides.C },
                new Point(){ CardId= 9, Color = Colors.Red, OrdinalNumber = 1,   Side =  Sides.D },
                new Point(){ CardId= 9, Color = Colors.Green, OrdinalNumber = 2, Side =  Sides.D },
            };

            context.AddRange(cards);
            context.AddRange(points);
            context.SaveChanges();
        }

        [Test]
        public void SolutitonServiceDIShouldBeArgumentException()
        {
            
            Assert.Throws<ArgumentNullException>(() => new GameSolutionService(null, null));
            
        }
        [Test]
        public void SolutitonServiceWithoutRotateServiceShouldBeArgumentException2()
        {
            using var context = new RubikDbContext(dbContextOptions);
            Assert.Throws<ArgumentNullException>(() => new GameSolutionService(context, null));

        }
        [Test]
        public void SolutitonServiceWithoutDBContextShouldBeArgumentException2()
        {
           
            Assert.Throws<ArgumentNullException>(() => new GameSolutionService(null, new RotationService()));

        }
        [Test]
        public void GetSolutions()
        {
            using var context = new RubikDbContext(dbContextOptions);
            var rotationService = new RotationService();
            var solutionService = new GameSolutionService(context, rotationService);
            var solution = solutionService.Resolve();
            Assert.IsNotNull(solution);
        }
    }
}
