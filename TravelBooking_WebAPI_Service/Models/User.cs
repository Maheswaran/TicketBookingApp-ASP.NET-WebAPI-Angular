using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketBooking_WebAPI_Service.Models
{
    //[Table("Users")]
    //public class User
    //{
    //    [Key]
    //    public long userId { get; set; }

    //    public string Password { get; set; }

    //    public string Rating { get; set; }

    //    public string EmailId { get; set; }

    //    public string MobileNo { get; set; }

    //}

    [Table("Users")]
    public class User
    {
        [Key]
        [Required]
        public long UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Text)]
        public string Rating { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailId { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        [DataType(DataType.Text)]
        public string MobileNo { get; set; }
    }
}