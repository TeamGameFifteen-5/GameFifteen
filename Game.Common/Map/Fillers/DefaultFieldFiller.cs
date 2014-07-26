namespace Game.Common.Map.Fillers
{
	public class DefaultFieldFiller : IFieldFiller
	{
		public void Fill(IField field, int size)
		{
			var area = new int[size, size];
			var currentNumber = 1;

			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					area[row, col] = currentNumber++;
				}
			}

			int lastXY = size - 1;
			area[lastXY, lastXY] = 0;

			field.Area = area;

			var lastPosition = size - 1;
			field.Position = new Position(lastPosition, lastPosition);
		}
	}
}