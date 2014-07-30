namespace Game.Common.Utils
{
	using System;

	/// <summary>
	/// Represents Validation Utilities.
	/// </summary>
	public static class Validation
	{
		/// <summary>
		/// Throw if null.
		/// </summary>
		/// <exception cref="ArgumentNullException">
		/// Thrown when required argument is null.
		/// </exception>
		/// <param name="instance">The instance.</param>
		/// <param name="message"> (optional) the message.</param>
		public static void ThrowIfNull(object instance, string message = null)
		{
			if (instance == null)
			{
				var exceptionMessage = message ?? string.Format("The value of cannot be null.");
				throw new ArgumentNullException(exceptionMessage);
			}
		}

		/// <summary>
		/// Throw if null or white space.
		/// </summary>
		/// <exception cref="ArgumentException">
		/// Thrown when argument has unsupported or illegal values.
		/// </exception>
		/// <param name="value">The value.</param>
		/// <param name="message"> (optional) the message.</param>
		public static void ThrowIfNullOrWhiteSpace(string value, string message = null)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				var exceptionMessage = message ?? string.Format("The value({0}) cannot be null or whitespace.", value);
				throw new ArgumentException(exceptionMessage);
			}
		}

		/// <summary>
		/// Throw if invalid enum value.
		/// </summary>
		/// <exception cref="ArgumentNullException">
		/// Thrown when argument is not defined in the enum type.
		/// </exception>
		/// <param name="enumValue">The enum value.</param>
		/// <param name="message">  (optional) the message.</param>
		public static void ThrowIfInvalidEnumValue(object enumValue, string message = null)
		{
			Validation.ThrowIfNull(enumValue);

			var enumType = enumValue.GetType();

			if (!enumType.IsEnumDefined(enumValue))
			{
				var exceptionMessage = message ?? string.Format("The value of {0} is not defined.", enumType.Name);
				throw new ArgumentException(exceptionMessage);
			}
		}

		/// <summary>
		/// Throw if out of range.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Thrown the argument is outside the required range.
		/// </exception>
		/// <param name="value">		The value.</param>
		/// <param name="lowerBoundary">The lower boundary.</param>
		/// <param name="upperBoundary">The upper boundary.</param>
		public static void ThrowIfOutOfRange(int value, int lowerBoundary, int upperBoundary)
		{
			const string MESSAGE_TEMPLATE = "The value({0}) cannot be smaller than {1} and bigger than {2}.";
			string exceptionMessage = null;

			bool isSmallerThanLowerBoundary = value < lowerBoundary;
			bool isBiggerThanUpperBoundary = value > upperBoundary;

			if (isSmallerThanLowerBoundary || isBiggerThanUpperBoundary)
			{
                exceptionMessage = string.Format(MESSAGE_TEMPLATE, value, lowerBoundary, upperBoundary);
				throw new ArgumentOutOfRangeException(exceptionMessage);
			}
		}
	}
}