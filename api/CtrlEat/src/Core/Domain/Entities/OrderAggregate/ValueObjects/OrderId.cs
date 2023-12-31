﻿using Domain.Common.Models;

using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.OrderAggregate.ValueObjects;

public sealed class OrderId : ValueObject
{
    public Guid Value { get; private set; }

    [ExcludeFromCodeCoverage]
    private OrderId()
    {
    }

    private OrderId(Guid value)
    {
        Value = value;
    }

    public static OrderId CreateUnique()
    {
        return new OrderId(Guid.NewGuid());
    }

    public static OrderId Create(Guid value)
    {
        return new OrderId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
