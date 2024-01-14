using DTOLayer.DTOs.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AppUserVR
{
    public class AppUserRegisterValidator: AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
                RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Max character for name is 30!");  
                RuleFor(x=>x.Username).MinimumLength(5).WithMessage("Min character for username is 5!");  
                RuleFor(x=>x.Surname).MaximumLength(30).WithMessage("Max character for surname is 30!");  
                RuleFor(x=>x.Username).NotEmpty().WithMessage("Username can not be empty!");  
                RuleFor(x=>x.Name).NotEmpty().WithMessage("Name can not be empty!");  
                RuleFor(x=>x.Surname).NotEmpty().WithMessage("Surname can not be empty!");  
                RuleFor(x=>x.Email).NotEmpty().WithMessage("Email can not be empty!");  
                RuleFor(x=>x.Email).EmailAddress().WithMessage("Please use a valid email address!");  
                RuleFor(x=>x.Password).NotEmpty().WithMessage("Password can not be empty!");  
                RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Confirm password can not be empty!");  
                RuleFor(x=>x.Password).Equal(y=>y.ConfirmPassword).WithMessage("Passwords are not matching!");  
        }
    }
}
