namespace OrderManagementApi.Models
{
    /// <summary>
    /// Model for updating an order
    /// </summary>
    public class UpdateOrderApiModel
    {
        /// <summary>
        /// Order identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order list
        /// </summary>
        public string[] Products { get; set; }

        /// <summary>
        /// Order cost
        /// </summary>
        public decimal Amount { get; set; }

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