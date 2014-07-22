using System;

namespace Game.Core.Utils
{
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