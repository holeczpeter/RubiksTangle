using RubiksTangle.Core;
using RubiksTangle.Core.Entities;
using System.Collections.Generic;

namespace RubiksTangle.Application.Models
{
    public class PointModel
    {
        public Colors Color { get; set; }
        public int Order { get; set; }
        public Sides Side { get; set; }
    }
    public class PointModelEqualityComparer : IEqualityComparer<PointModel>
    {
        bool IEqualityComparer<PointModel>.Equals(PointModel lpm, PointModel rpm)
        {
            return
                lpm.Color == rpm.Color &&
                lpm.Order == rpm.Order;
        }

        int IEqualityComparer<PointModel>.GetHashCode(PointModel item)
        {
            return
                item.Color.GetHashCode() +
                item.Order.GetHashCode();
        }
    }
}
