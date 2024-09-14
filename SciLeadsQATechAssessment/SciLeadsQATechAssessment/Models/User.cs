using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Models
{
    /// <summary>
    /// Model that represents a user.
    /// </summary>
    public class User
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
