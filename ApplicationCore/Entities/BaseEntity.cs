using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// Basic settings for table elements
    /// </summary>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// Self-generating identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; protected set; }
    }
}