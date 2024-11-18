﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.UserHistorial.Validation;

public class CompareDatesAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public CompareDatesAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var currentValue = (DateTime?)value;
        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (property == null)
            throw new ArgumentException("Property with this name not found");

        var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

        if (currentValue != null && comparisonValue != null && currentValue <= comparisonValue)
        {
            return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} debe ser posterior a {_comparisonProperty}");
        }

        return ValidationResult.Success;
    }
}