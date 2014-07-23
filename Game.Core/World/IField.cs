using Game.Common;
using Game.Core.World.Fillers;
using Game.Core.World.Randomizers;

namespace Game.Core.World
{
	public interface IField
	{
		int[,] Area { get; set; }

		int Width { get; }

		int Height { get; }

		Position Position { get; }

		int this[int row, int col] { get; set; }

		void RandomizeField(IFieldRandomizer randomizer = null);

		void Fill(int size, IFieldFiller filler = null);

		bool IsInLimits(int row, int col);
	}
}