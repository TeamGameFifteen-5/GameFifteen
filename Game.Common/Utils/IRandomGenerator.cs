namespace Game.Common.Utils
{
	/// <summary>
	/// Interface for random generator.
	/// </summary>
	public interface IRandomGenerator
	{
		/// <summary>
		/// Gets the next random integer.
		/// </summary>
		/// <returns>
		/// random integer number
		/// </returns>
		int Next();

		/// <summary>
		/// Gets the next random integer.
		/// </summary>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>
		/// random integer number
		/// </returns>
		int Next(int maxValue);

		/// <summary>
		/// Gets the next random integer.
		/// </summary>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>
		/// random integer number
		/// </returns>
		int Next(int minValue, int maxValue);

		/// <summary>
		/// Gets the next random double.
		/// </summary>
		/// <returns>
		/// random double number
		/// </returns>
		double NextDouble();
	}
}