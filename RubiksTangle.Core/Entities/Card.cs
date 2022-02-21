using System.Collections.Generic;

namespace RubiksTangle.Core.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }    
        public int OrdinalNumber { get; set; }
        public int Rotation { get; set; }
        public virtual ICollection<Point> Points { get; } =  new HashSet<Point>();
    }
}
