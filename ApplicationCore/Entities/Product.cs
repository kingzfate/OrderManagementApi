using System.Text.Json.Serialization;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// Products specified in the order
    /// </summary>
    public class Product : BaseEntity<int>
    {
        /// <summary>
        /// The product's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The order to which this product belongs
        /// </summary>
        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}