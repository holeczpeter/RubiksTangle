using NUnit.Framework;
using RubiksTangle.Application.Features;
using RubiksTangle.Application.Models;
using RubiksTangle.Core;
using RubiksTangle.Core.Entities;

namespace RubiksTangle.Tests
{
    public class RotationTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void RotateAndShuoldBeChangeSide()
        {
            var rotateService = new RotationService();
            var currentPoint = new PointModel() { Color = Colors.Yellow, Order = 1, Side = Sides.A };
            var rotatedPoint = rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 1, PointModel = currentPoint });
            var rotated90 = rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 1, PointModel = currentPoint });
            var rotated180 = rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 2, PointModel = currentPoint });
            var rotated270 = rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 3, PointModel = currentPoint });

            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(currentPoint.Side, rotatedPoint.Side);
                Assert.AreNotEqual(currentPoint.Side, rotated90.Side);
                Assert.AreNotEqual(currentPoint.Side, rotated180.Side);
                Assert.AreNotEqual(currentPoint.Side, rotated270.Side);
            });
        }

        [Test]
        public void Rotate360AndShuoldBeSetEqualsSide()
        {
            var rotateService = new RotationService();
            var currentPoint = new PointModel() { Color = Colors.Yellow, Order = 1, Side = Sides.A };
            var rotatedPoint = rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 4, PointModel = currentPoint });
            var rotatedPointTwice = rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 8, PointModel = currentPoint });
            Assert.Multiple(() =>
            {
                Assert.AreEqual(currentPoint.Side, rotatedPoint.Side);
                Assert.AreEqual(rotatedPointTwice.Side, rotatedPoint.Side);
                Assert.AreEqual(currentPoint.Side, rotatedPointTwice.Side);
            });
        }

        [Test]
        public void RotateAllAndColorAndSideAndOrdinalNumberAreEquals()
        {
            var rotateService = new RotationService();
            var currentPoint = new PointModel() { Color = Colors.Yellow, Order = 1, Side = Sides.A };
            var rotatedZero = rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 0, PointModel = currentPoint });
            var rotated90 =   rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 1, PointModel = currentPoint });
            var rotated180 =  rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 2, PointModel = currentPoint });
            var rotated270 =  rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 3, PointModel = currentPoint });
  
            Assert.Multiple(() =>
            {
                Assert.AreEqual(currentPoint, rotatedZero);

                Assert.AreEqual(Colors.Yellow, rotated90.Color);
                Assert.AreEqual(Sides.B, rotated90.Side);
                Assert.AreEqual(2, rotated90.Order);

                Assert.AreEqual(Colors.Yellow, rotated180.Color);
                Assert.AreEqual(Sides.C, rotated180.Side);
                Assert.AreEqual(2, rotated180.Order);

                Assert.AreEqual(Colors.Yellow, rotated270.Color);
                Assert.AreEqual(Sides.D, rotated270.Side);
                Assert.AreEqual(1, rotated270.Order);
            });
        }

        [Test]
        public void RotateMoreThan360AndShouldBeResultEquals()
        {
            var rotateService = new RotationService();
            var currentPoint = new PointModel() { Color = Colors.Yellow, Order = 1, Side = Sides.A };
            var rotatedMoreThanFour = rotateService.Rotate(new RotationModel() { CurrentRotationState = 3, NextRotationState = 5, PointModel = currentPoint });
            var rotated90 = rotateService.Rotate(new RotationModel() { CurrentRotationState = 0, NextRotationState = 2, PointModel = currentPoint });
            Assert.Multiple(() =>
            {
                Assert.AreEqual(rotated90.Color, rotatedMoreThanFour.Color);
                Assert.AreEqual(rotated90.Side, rotatedMoreThanFour.Side);
                Assert.AreEqual(rotated90.Order, rotatedMoreThanFour.Order);
            });
        }
    }
}