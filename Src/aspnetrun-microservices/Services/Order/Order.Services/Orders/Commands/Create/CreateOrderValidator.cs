using System;
using FluentValidation;

namespace Order.Services.Orders.Commands.Create
{
    public class CreateOrderValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.UserName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .MaximumLength(150).WithMessage("{PropertyName} حداکثر ۱۵۰ کاراکتر باید باشد.")
                .WithName("نام کاربری")
                ;


            RuleFor(c => c.TotalPrice).Must(isValid).WithMessage("{PropertyName}  نمیتواند منفی باشد.")
                .WithMessage("میلغ");

            RuleFor(c => c.FirstName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .MaximumLength(150).WithMessage("{PropertyName} حداکثر ۱۵۰ کاراکتر باید باشد.")
                .WithName("نام")
                ;


            RuleFor(c => c.LastName).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .MaximumLength(150).WithMessage("{PropertyName} حداکثر ۱۵۰ کاراکتر باید باشد.")
                .WithName("نام خانوادگی")
                ;


            RuleFor(c => c.EmailAddress).NotEmpty().WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .NotNull().WithMessage("{PropertyName} نمی تواند خالی باشد.")
                .MaximumLength(150).WithMessage("{PropertyName} حداکثر ۱۵۰ کاراکتر باید باشد.")
                .WithName("ایمیل")
                ;

        }

  

        private static bool isValid(decimal totalPrice)
        {
            if (totalPrice<0)
            {
                return false;
            }

            return true;
        }
    }
}

