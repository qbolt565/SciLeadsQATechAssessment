using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Tests.UI.Models
{
    /// <summary>
    /// Represent an entry in the Weather table
    /// </summary>
    public class WeatherItem
    {
        public DateTime Date { get; set; }
        public int TempCelcius { get; set; }
        public int TempFahrenheit { get; set; }
        public required string Summary { get; set; }
    }
}
