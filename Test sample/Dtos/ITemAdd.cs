namespace Test_sample.Controller;

public class ITemAdd
{
    public class AddItemDto
    {
        public int ItemId { get; set; }
        public int Amount { get; set; }
    }

    public class BackpackDto
    {
        public int CharacterId { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
    }
}