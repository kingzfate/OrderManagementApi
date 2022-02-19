namespace ApplicationCore.Models
{
    /// <summary>
    /// Order statuses
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Order registered 
        /// </summary>
        Registered = 1,

        /// <summary>
        /// Order received in stock
        /// </summary>
        AcceptedInStock = 2,

        /// <summary>
        /// Order issued to courier 
        /// </summary>
        IssuedToCourier = 3,

        /// <summary>
        /// Order delivered to post office 
        /// </summary>
        DeliveredToPostamat = 4,

        /// <summary>
        /// Order has been delivered to the recipient 
        /// </summary>
        DeliveredToRecipient = 5,

        /// <summary>
        /// Order cancelled
        /// </summary>
        Canceled = 6
    }
}