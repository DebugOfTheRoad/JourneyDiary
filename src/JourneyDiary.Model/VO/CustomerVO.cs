using FluentValidation.Attributes;
using JourneyDiary.Model.VO.Validators;

namespace JourneyDiary.Model.VO
{
    [Validator(typeof(CustomerValidator))]
    public class CustomerVO
    {
        public string Phone { get; set; }

        public string Password { get; set; }

        public string Nick { get; set; }

        public int Age { get; set; }
    }
}