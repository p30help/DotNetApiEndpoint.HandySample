using HandySample.ApiModels.MoedlValidations;
using System.ComponentModel.DataAnnotations;

namespace HandySample.ApiModels.Requests
{
    public class CreateCustomerRequest
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        public string? FullName { get; set; }

        [PhoneMask("999-999-9999", ErrorMessage = "{0} value does not match the mask {1}.")]
        public string? Phone { get; set; }

        [Range(20, 70, ErrorMessage = "Customer Age should be in 20 to 70 range.")]
        public int Age { get; set; }

        [NationalCodeValidation]
        public string? NationalCode { get; set; }

        [RequiredIf($"{nameof(Age)}>60", ErrorMessage = "Because customer is old please enter pension code")]
        public string? PensionCode { get; set; }

        [AddressValidation]
        public AddressRequest? Address { get; set; }

        [StringLength(10, ErrorMessage = "Company Name should be less than or equal to ten characters.")]
        public string CompanyName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [ValidJoinDate(ErrorMessage = "Join Date can not be greater than current date")]
        public DateTime JoinDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [ValidLastDeliveryDate(ErrorMessage = "Last Delivery Date can not be less than Join Date")]
        public DateTime LastDeliveryDate { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string? PersonalEmail { get; set; }

        [EmailAddress]
        public string? CompanyEmail { get; set; }

        [EnumDataType(typeof(EnumCustomerType))]
        public EnumCustomerType CustomerType { get; set; }

        [Url]
        public string? Website { get; set; }

    }
}