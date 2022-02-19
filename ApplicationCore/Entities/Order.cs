using ApplicationCore.Models;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// Order with goods, to whom it is sent and where
    /// </summary>
    public class Order : BaseEntity<int>
    {
        /// <summary>
        /// Status of order
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Product list
        /// </summary>
        public virtual IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Order cost
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Postamat and information about it
        /// </summary>
        public virtual Postamat Postamat { get; set; }

        /// <summary>
        /// Phone number of the person to whom the order will be delivered
        /// </summary>
        public string RecipientPhoneNumber { get; set; }

        /// <summary>
        /// Name of the person to whom the order will be delivered 
        /// </summary>
        public string RecipientFullName { get; set; }
    }
}