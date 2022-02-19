namespace OrderManagementApi.Models
{
    /// <summary>
    /// Model for creating an order
    /// </summary>
    public class CreateOrderApiModel
    {
        /// <summary>
        /// Order list
        /// </summary>
        public string[] Products { get; set; }

        /// <summary>
        /// Order cost
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Postamat number 
        /// </summary>
        public string Postamat { get; set; }

        /// <summary>
        /// The phone number of the person receiving the order 
        /// </summary>
        public string RecipientPhoneNumber { get; set; }

        /// <summary>
        /// The name of the person who is ordering 
        /// </summary>
        public string RecipientFullName { get; set; }
    }
}