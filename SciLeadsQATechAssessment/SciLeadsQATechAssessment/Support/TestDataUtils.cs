using SciLeadsQATechAssessment.Tests.UI.Models;

namespace SciLeadsQATechAssessment.Tests.UI.Support
{
    /// <summary>
    /// Class for generating test data.
    /// </summary>
    public class TestDataUtils
    {
        /// <summary>
        /// Generates a unique email address.
        /// </summary>
        /// <returns>Unique email address.</returns>
        public static string GetTestEmail()
        {
            return $"user{DateTime.Now:yyyyMMddhhmmss}@test.com";
        }

        /// <summary>
        /// Generates random credentials for a user. 
        /// </summary>
        /// <returns></returns>
        public static User GetTestUser()
        {
            return new User() { Email = GetTestEmail(), Password = "P@33word" };
        }
    }
}
