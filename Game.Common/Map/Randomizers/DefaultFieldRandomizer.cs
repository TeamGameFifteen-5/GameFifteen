namespace Game.Common.Map.Randomizers
{
	using Game.Common.Map.Movement;
	using Game.Common.Utils;
	using System;

	/// <summary>
	/// Default field randomizer.
	/// </summary>
	/// <seealso cref="Game.Common.Map.Randomizers.IFieldRandomizer"/>
	public class DefaultFieldRandomizer : IFieldRandomizer
	{
		#region Constants

		/// <summary>
		/// The easy randomize cycles.
		/// </summary>
		private const int EASY_RANDOMIZE_CYCLES = 20;

		/// <summary>
		/// The normal randomize cycles.
		/// </summary>
		private const int NORMAL_RANDOMIZE_CYCLES = 100;

		/// <summary>
		/// The hard randomize cycles.
		/// </summary>
		private const int HARD_RANDOMIZE_CYCLES = 1000;

		#endregion Constants

        /// <summary>
        /// The random generator.
        /// </summary>
        private readonly IRandomGenerator _randomGenerator;

        /// <summary>
        /// The total elements in direction.
        /// </summary>
        private readonly int _totalElementsInDirection;

		/// <summary>
		/// Initializes a new instance of the DefaultFieldRandomizer class.
		/// </summary>
		/// <param name="randomGenerator">The random generator.</param>
		public DefaultFieldRandomizer(IRandomGenerator randomGenerator)
		{
			Validation.ThrowIfNull(randomGenerator);

			this._randomGenerator = randomGenerator;
			this._totalElementsInDirection = Enum.GetNames(typeof(Direction)).Length;
		}

		/// <summary>
		/// Randomizes the given field.
		/// </summary>
		/// <param name="field">	 The field.</param>
		/// <param name="difficulty">The difficulty.</param>
		public void Randomize(IField field, Difficulty difficulty)
		{
			Validation.ThrowIfNull(field);
			Validation.ThrowIfInvalidEnumValue(difficulty);

			var movement = new StraightMovement(field);
			int randomizeCycles = this.GetRandomizeCycles(difficulty);

			for (int cycleIndex = 0; cycleIndex < randomizeCycles; cycleIndex++)
			{
				int randomNumber = this._randomGenerator.Next(this._totalElementsInDirection);

				Direction direction = (Direction)Enum.Parse(typeof(Direction), randomNumber.ToString());

				if (!movement.Move(direction))
				{
					cycleIndex--;
				}
			}
		}

		/// <summary>
		/// Gets randomize cycles.
		/// </summary>
		/// <param name="difficulty">The difficulty.</param>
		/// <returns>
		/// The randomize cycles.
		/// </returns>
		private int GetRandomizeCycles(Difficulty difficulty)
		{
			int randomizeCycles = 0;

			switch (difficulty)
			{
				case Difficulty.Easy:
					randomizeCycles = EASY_RANDOMIZE_CYCLES;
					break;

				case Difficulty.Normal:
					randomizeCycles = NORMAL_RANDOMIZE_CYCLES;
					break;

				case Difficulty.Hard:
					randomizeCycles = HARD_RANDOMIZE_CYCLES;
					break;
			}

			return randomizeCycles;
		}
	}
}