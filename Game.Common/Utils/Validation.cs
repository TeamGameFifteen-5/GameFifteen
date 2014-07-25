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
	}
}