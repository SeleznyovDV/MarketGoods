﻿namespace MarketGoodsDDD.Domain.ValueObjects
{
    using System.Text.RegularExpressions;

    public partial record PhoneNumber
	{
		private const int DefaultLength = 9;
		private const string Pattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
		private PhoneNumber(string value) => Value = value;

		public string Value { get; init; }

		public static PhoneNumber? Create(string value)
		{
			if (string.IsNullOrEmpty(value)
				|| !PhoneNumberRegex().IsMatch(value)
				|| value.Length != DefaultLength)
			{
				return null;
			}

			return new PhoneNumber(value);
		}

		[GeneratedRegex(Pattern)]
		private static partial Regex PhoneNumberRegex();
	}
}

