namespace Game.Common.Map.Fillers
{
    using Game.Common.Utils;

	/// <summary>
	/// Default field filler.
	/// </summary>
	/// <seealso cref="Game.Common.Map.Fillers.IFieldFiller"/>
	public class DefaultFieldFiller : IFieldFiller
	{
		/// <summary>
		/// Fills the field with the specified filler.
		/// </summary>
		/// <param name="field">The field.</param>
		public void Fill(IField field)
		{
			Validation.ThrowIfNull(field);

			int size = field.Size;
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