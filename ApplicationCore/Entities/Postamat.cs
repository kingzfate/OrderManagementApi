namespace ApplicationCore.Entities
{
    /// <summary>
    /// Postamat, the place where the order will be delivered 
    /// </summary>
    public class Postamat : BaseEntity<int>
    {
        /// <summary>
        /// Postamat number in the format хххх-ххх 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Postamat location address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Postamat work status
        /// </summary>
        public bool Status { get; set; }
    }
}