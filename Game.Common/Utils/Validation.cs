namespace Game.Common.Utils
{
	using System;

	public static class Validation
	{
		public static void ThrowIfNull(object instance, string message = null)
		{
			if (instance == null)
			{
				var exceptionMessage = message ?? string.Format("The value of {0} cannot be null.", instance.GetType().Name);
				throw new ArgumentNullException(exceptionMessage);
			}
		}

		public static void ThrowIfInvalidEnumValue(object enumValue, string message = null)
		{
			if (!Enum.IsDefined(enumValue.GetType(), enumValue))
			{
				var exceptionMessage = message ?? string.Format("The value of {0} is not defined.", enumValue.GetType().Name);
				throw new ArgumentNullException(exceptionMessage);
			}
		}

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