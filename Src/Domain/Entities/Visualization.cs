using FinRust.Domain.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinRust.Domain.Entities
{
    public class Visualization
    {
        public int VisualizationId { get; set; }
        public string Name { get; set; }

        public int CustomerId { get; set; }

        [NotMapped]
        public ICollection<CalculationDate> Dates { get; set; }
        public Customer Customer { get; set; }
    }
}
