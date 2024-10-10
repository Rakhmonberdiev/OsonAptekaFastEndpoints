﻿using FastEndpoints;
using FluentValidation;
using OsonAptekaFastEndpoints.RequestDtos.Students;

namespace OsonAptekaFastEndpoints.Validators
{
    public class StudentUpdateReqValidator : Validator<StudentUpdateReq>
    {
        public StudentUpdateReqValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("To'liq ism kiritishingiz shart")
                .Length(5, 250)
                .WithMessage("Ism eng kamida 5ta eng kopida 250ta belgidan iborat bolish kerak");
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("tugilgan kun kiritish shart");
            RuleFor(x => x.ClassId)
                .NotEmpty();


        }
    }
}
