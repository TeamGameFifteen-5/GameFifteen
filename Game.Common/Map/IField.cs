﻿namespace Game.Common.Map
{
	using Game.Common.Map.Fillers;
	using Game.Common.Map.Randomizers;
	using System.Collections.Generic;

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
		/// Gets the size.
		/// </summary>
		/// <value>
		/// The size.
		/// </value>
		int Size { get; }

		/// <summary>
		/// Gets the start position.
		/// </summary>
		/// <value>
		/// The start position.
		/// </value>
		Position StartPosition { get; }

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
		void RandomizeField(Difficulty difficulty, IFieldRandomizer randomizer = null);

		/// <summary>
		/// Fills the field with the specified filler and size.
		/// </summary>
		/// <param name="filler">(optional) the filler.</param>
		void Fill(IFieldFiller filler = null);

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