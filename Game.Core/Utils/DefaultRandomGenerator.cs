using System;

namespace Game.Core.Utils
{
	/// <summary>
	/// Represents default random numbers generator in a singleton implementation.
	/// Implements Singleton Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Core.Utils.IRandomGenerator"/>
	public sealed class DefaultRandomGenerator : IRandomGenerator
	{
		private static readonly DefaultRandomGenerator _instance = new DefaultRandomGenerator();

		private Random _random = new Random();

		private DefaultRandomGenerator()
		{
		}

		public static DefaultRandomGenerator Instance
		{
			get
			{
				return _instance;
			}
		}

		public int Next()
		{
			return this._random.Next();
		}

		public int Next(int maxValue)
		{
			return this._random.Next(maxValue);
		}

		public int Next(int minValue, int maxValue)
		{
			return this._random.Next(minValue, maxValue);
		}

		public double NextDouble()
		{
			return this._random.NextDouble();
		}
	}
}