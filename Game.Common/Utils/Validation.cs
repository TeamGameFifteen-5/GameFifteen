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
				var exceptionMessage = message ?? string.Format("The value of {0} cannot be null.", instance.GetType().Name);
				throw new ArgumentNullException(exceptionMessage);
			}
		}

		/// <summary>
		/// Throw if null or white space.
		/// </summary>
		/// <exception cref="ArgumentException">
		/// Thrown when argument has unsupported or illegal values.
		/// </exception>
		/// <param name="instance">The instance.</param>
		/// <param name="message"> (optional) the message.</param>
		public static void ThrowIfNullOrWhiteSpace(string instance, string message = null)
		{
			if (string.IsNullOrWhiteSpace(instance))
			{
				var exceptionMessage = message ?? "The value cannot be null or whitespace.";
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
			if (!Enum.IsDefined(enumValue.GetType(), enumValue))
			{
				var exceptionMessage = message ?? string.Format("The value of {0} is not defined.", enumValue.GetType().Name);
				throw new ArgumentNullException(exceptionMessage);
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
			const string messageTemplate = "The value({0}) cannot be smaller than {1} and bigger than {2}.";
			string exceptionMessage = null;

			bool isSmallerThanLowerBoundary = value < lowerBoundary;
			bool isBiggerThanUpperBoundary = value > upperBoundary;

			if (isSmallerThanLowerBoundary || isBiggerThanUpperBoundary)
			{
				exceptionMessage = string.Format(messageTemplate, value, lowerBoundary, upperBoundary);
				throw new ArgumentOutOfRangeException(exceptionMessage);
			}
		}
	}
}