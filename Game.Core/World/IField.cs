using Game.Common;

namespace Game.Core.World
{
	public interface IField
	{
		int[,] Area { get; }

		int this[int row, int col] { get; set; }

		int Width { get; }

		int Height { get; }

		Position Position { get; }

		void RandomizeField(IFieldRandomizer randomizer = null);

		bool IsInLimits(int row, int col);
	}
}