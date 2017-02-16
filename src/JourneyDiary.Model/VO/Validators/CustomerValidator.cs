using FluentValidation;

namespace JourneyDiary.Model.VO.Validators
{
    public class CustomerValidator:AbstractValidator<CustomerVO>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.Phone).NotEmpty().WithMessage("用户名不能为空");
            RuleFor(p => p.Password).NotEmpty().WithMessage("密码不能为空");
        }
    }
}