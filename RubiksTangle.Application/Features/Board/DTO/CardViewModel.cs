namespace RubiksTangle.Application.Features
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public int Rotation { get; set; }
        public int OrdinalNumber { get; set; }
        public byte[] Picture { get; set; }
    }
}
