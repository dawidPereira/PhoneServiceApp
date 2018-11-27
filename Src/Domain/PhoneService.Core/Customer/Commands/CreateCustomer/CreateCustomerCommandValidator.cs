using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;



namespace PhoneService.Core
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
           
            RuleFor(x => x.Email).MaximumLength(15);
            
        }
    }
}
