using RubiksTangle.Application.Models;

namespace RubiksTangle.Application.Features
{
    public interface IRotationService
    {
        /// <summary>
        /// Egy pont forgatása
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns></returns>
        PointModel Rotate(RotationModel rotation);
    }
}