using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartChef.Auth.Infrastructure
{
    /// <inheritdoc />
    /// <summary>
    /// ApplicationUser  model class
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// The FirstName property
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        /// <summary>
        /// The LastName property
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        /// <summary>
        /// The Title property
        /// </summary>
        [MaxLength(100)]
        public string Title { get; set; }
        /// <summary>
        /// The Location property
        /// </summary>
        [MaxLength(500)]
        public string Facility { get; set; }
        /// <summary>
        /// The CreatedDate property
        /// </summary>
        [Required]
        public string CreatedDate { get; set; }
        /// <summary>
        /// The FirstName property
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }
        /// <summary>
        /// The ModifiedDate property
        /// </summary>
        public string ModifiedDate { get; set; }
        /// <summary>
        /// The ModifiedBy property
        /// </summary>
        [MaxLength(100)]
        public string ModifiedBy { get; set; }
        /// <summary>
        /// The IsActive property
        /// </summary>
        [Required]
        public bool IsActive { get; set; }
        /// <summary>
        /// IschangePasswordRequired Property
        /// </summary>
        [Required]
        public bool IschangePasswordRequired { get; set; }
        /// <summary>
        /// The Token property
        /// </summary>
        public string PasswordResetToken { get; set; }
        /// <summary>
        /// The Token property
        /// </summary>
        public string PasswordExpirationTime { get; set; }
        /// <summary>
        /// Generates the user schema in Db
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}