using System.ComponentModel.DataAnnotations;

namespace MVA
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required, StringLength(49)]
        public string Name { get; set; }
    }
}