namespace RubiksTangle.Core.Entities
{
    public class Point 
    {
        public int Id { get; set; }
        public virtual int CardId { get; set; }
        public virtual Card Card { get; set; }
        public int OrdinalNumber { get; set; }
        public Colors Color { get; set; }
        public Sides Side { get; set; }
    }
}
