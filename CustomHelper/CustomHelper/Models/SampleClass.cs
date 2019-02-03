using System;
using System.ComponentModel.DataAnnotations;

namespace CustomHelper.Models
{
    public class SampleClass
    {
        #region Constructor
        public SampleClass():base()
        {
            Email = string.Empty;
            Password = string.Empty;
        }
        #endregion

        #region Public Properties
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }
        public bool IsIn401k { get; set; }
        public bool IsInHealthCare { get; set; }
        #endregion
    }
}