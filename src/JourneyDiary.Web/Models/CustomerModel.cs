using FluentValidation.Attributes;
using JourneyDiary.Web.Validators;

namespace JourneyDiary.Web.Models
{
    [Validator(typeof(CustomerValidator))]
    public class CustomerModel
    {
        public string Phone { get; set; }

        public string Password { get; set; }

        public string Nick { get; set; }

        public int Age { get; set; }
    }
}