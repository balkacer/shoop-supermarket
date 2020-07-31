using Newtonsoft.Json;

namespace shoopsupermarket.Models
{
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class PaymentIntentCreateRequest
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
}