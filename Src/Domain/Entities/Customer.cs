using System.Collections.Generic;

namespace FinRust.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            Visualizations = new HashSet<Visualization>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }

        public ICollection<Visualization> Visualizations { get; private set; }
    }
}
