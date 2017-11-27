using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Casino.AdminPortal.Web.Models
{
    public class UserViewModels : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
        }

        #endregion



        public int PlayerId { get; set; }

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use alphabets and space only please")]
        [Required]
        public string Name { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "Contact Number Must of 10 Digits and Must be Numeric")]
        [Required]
        public string ContactNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string EmailId { get; set; }

        [Required]
        public System.DateTime DateOfBirth { get; set; }

        public decimal AccountBalance { get; set; }

        public byte[] IdentityProof { get; set; }
        public int BlockedAmount { get; set; }
        public decimal rechargeAmount;

    }
}
