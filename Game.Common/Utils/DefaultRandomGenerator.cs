namespace Game.Common.Utils
{
	using System;

	/// <summary>
	/// Represents default random numbers generator in a singleton implementation.
	/// Implements Singleton Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Common.Utils.IRandomGenerator"/>
	public sealed class DefaultRandomGenerator : IRandomGenerator
	{
		/// <summary>
		/// The instance.
		/// </summary>
		private static readonly DefaultRandomGenerator _Instance = new DefaultRandomGenerator();

        /// <summary>
        /// The random.
        /// </summary>
        private readonly Random _random = new Random();

		/// <summary>
		/// Prevents a default instance of the DefaultRandomGenerator class from being created.
		/// </summary>
		private DefaultRandomGenerator()
		{
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static DefaultRandomGenerator Instance
		{
			get
			{
				return _Instance;
			}
		}

		/// <summary>
		/// Gets the next random integer.
		/// </summary>
		/// <returns>
		/// random integer number.
		/// </returns>
		public int Next()
		{
			return this._random.Next();
		}

		/// <summary>
		/// Gets the next random integer.
		/// </summary>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>
		/// random integer number.
		/// </returns>
		public int Next(int maxValue)
		{
			return this._random.Next(maxValue);
		}

		/// <summary>
		/// Gets the next random integer.
		/// </summary>
		/// <param name="minValue">The minimum value.</param>
		/// <param name="maxValue">The maximum value.</param>
		/// <returns>
		/// random integer number.
		/// </returns>
		public int Next(int minValue, int maxValue)
		{
			return this._random.Next(minValue, maxValue);
		}

		/// <summary>
		/// Gets the next random double.
		/// </summary>
		/// <returns>
		/// random double number.
		/// </returns>
		public double NextDouble()
		{
			return this._random.NextDouble();
		}
	}
}