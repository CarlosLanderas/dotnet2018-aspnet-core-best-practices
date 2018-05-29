using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2018.Api.Features.AddSpeaker
{
    public class AddSpeakerValidator: AbstractValidator<AddSpeakerModel>
    {
        public AddSpeakerValidator()
        {            
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.Description).MinimumLength(10);
        }
    }
}
