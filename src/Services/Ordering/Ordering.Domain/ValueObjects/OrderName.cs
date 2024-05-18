﻿
namespace Ordering.Domain.ValueObjects
{
    public record OrderName
    {
        private const int DEFAULT_LENGTH = 3;
        public string Value { get; }
        private OrderName(string value) => Value = value;
        public static OrderName Of(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfLessThan(value.Length, DEFAULT_LENGTH);

            return new OrderName(value);
        }
    }
}
