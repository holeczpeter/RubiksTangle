using RubiksTangle.Application.Models;
using RubiksTangle.Core.Entities;

namespace RubiksTangle.Application.Features
{

    public class RotationService : IRotationService
    {
        public PointModel Rotate(RotationModel rotation)
        {
            if (rotation.CurrentRotationState == rotation.NextRotationState)
            {
                return rotation.PointModel;
            }
            rotation = new RotationModel()
            {
                CurrentRotationState = rotation.CurrentRotationState + 1,
                NextRotationState = rotation.NextRotationState,
                PointModel = new PointModel()
                {
                    Color = rotation.PointModel.Color,
                    Order = SetOrderOne(rotation.PointModel.Side, rotation.PointModel.Order),
                    Side = SetSideOne(rotation.PointModel.Side)
                }
            };
            return Rotate(rotation);
        }

        /// <summary>
        /// Beállítja a forgatás szerint az új oldal értékét
        /// </summary>
        /// <param name="currenSide"></param>
        /// <param name="rotate"></param>
        /// <returns></returns>
        Sides SetSideOne(Sides currenSide)
        {
            var side = (currenSide) switch
            {
                var x when
                    x == (Sides.A) => Sides.B,
                var x when
                    x == (Sides.B) => Sides.C,
                var x when
                    x == (Sides.C) => Sides.D,
                var x when
                    x == (Sides.D) => Sides.A,
                _ => currenSide,
            };
            return side;
        }

        /// <summary>
        /// Beállítja a forgatás szerint a pont új pozícióját
        /// </summary>
        /// <param name="currenSide"></param>
        /// <param name="rotation"></param>
        /// <param name="currentOrder"></param>
        /// <returns></returns>
        ///            Pozíció 
        ///            csere     1       2    
        ///                  |---------------|
        ///               1  |               | 1
        ///                  |               |
        ///               2  |               | 2
        ///                  |               |
        ///                  |---------------| 
        ///                      1      2    Pozíció 
        ///                                   csere
        ///                      
        int SetOrderOne(Sides currenSide, int currentOrder)
        {
            var side = (currenSide, currentOrder) switch
            {
                var x when
                    x == (Sides.A, 1) ||
                    x == (Sides.C, 1) => 2,
                var x when
                    x == (Sides.A, 2) ||
                    x == (Sides.C, 2) => 1,
                var x when
                    x == (Sides.B, 1) ||
                    x == (Sides.B, 2) ||
                    x == (Sides.D, 1) ||
                    x == (Sides.D, 2) => currentOrder,
                _ => currentOrder,
            };
            return side;
        }
    }
}
   
