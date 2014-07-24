using Game.Common;
using Game.Common.Map.Fillers;
using Game.Common.Map.Randomizers;
using System.Collections.Generic;

namespace Game.Common.Map
{
	/// <summary>
	/// Interface for field.
	/// </summary>
	public interface IField : IEnumerable<IEnumerable<int>>
	{
		/// <summary>
		/// Gets or sets the area.
		/// </summary>
		/// <value>
		/// The area.
		/// </value>
		int[,] Area { get; set; }

		/// <summary>
		/// Gets the width.
		/// </summary>
		/// <value>
		/// The width.
		/// </value>
		int Width { get; }

		/// <summary>
		/// Gets the height.
		/// </summary>
		/// <value>
		/// The height.
		/// </value>
		int Height { get; }

		/// <summary>
		/// Gets the position.
		/// </summary>
		/// <value>
		/// The position.
		/// </value>
		Position Position { get; }

		/// <summary>
		/// Indexer to get or set items within this collection using array index syntax.
		/// </summary>
		/// <param name="row">The row.</param>
		/// <param name="col">The col.</param>
		/// <returns>
		/// The indexed item.
		/// </returns>
		int this[int row, int col] { get; set; }

		/// <summary>
		/// Randomize the field.
		/// </summary>
		/// <param name="randomizer">(optional) the randomizer.</param>
		void RandomizeField(IFieldRandomizer randomizer = null);

		/// <summary>
		/// Fills the field with the specified filler and size.
		/// </summary>
		/// <param name="size">  The size.</param>
		/// <param name="filler">(optional) the filler.</param>
		void Fill(int size, IFieldFiller filler = null);

		/// <summary>
		/// Check if 'row' and 'col' is in field limits.
		/// </summary>
		/// <param name="row">The row.</param>
		/// <param name="col">The col.</param>
		/// <returns>
		/// true if in limits, false if not.
		/// </returns>
		bool IsInLimits(int row, int col);
	}
}