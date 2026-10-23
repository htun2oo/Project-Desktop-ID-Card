namespace IDCard.Desktop.Models
{
    public class CardDesignModel
    {
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        public string DesignName { get; set; } = string.Empty;
        public string OwnerUsername { get; set; } = string.Empty; // ဖန်တီးသူ၏ Username
        public string CardDataJson { get; set; } = string.Empty;
    }
}
