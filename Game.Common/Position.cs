using Game.Common.Utils;

namespace Game.Common
{
	public class Position : IPosition
	{
		#region Constants

		private const int VALIDATION_LOWER_BOUNDARY = 0;
		private const int VALIDATION_UPPER_BOUNDARY = int.MaxValue;

		#endregion Constants

		public Position(int x, int y)
		{
			Validation.ThrowIfOutOfRange(x, VALIDATION_LOWER_BOUNDARY, VALIDATION_UPPER_BOUNDARY);
			Validation.ThrowIfOutOfRange(y, VALIDATION_LOWER_BOUNDARY, VALIDATION_UPPER_BOUNDARY);

			this.X = x;
			this.Y = y;
		}

		public int X { get; set; }

		public int Y { get; set; }
	}
}