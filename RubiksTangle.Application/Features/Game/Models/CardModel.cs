namespace RubiksTangle.Application.Models
{
    public class CardModel
    {
        public int CardId { get; set; }
        public int Rotation { get; set; }
        public PointModel[] Points { get; set; }
    }
}
