namespace Game.Common.Map.Randomizers
{
	using Game.Common.Map.Movement;
	using Game.Common.Utils;
	using System;

	public class DefaultFieldRandomizer : IFieldRandomizer
	{
		private IRandomGenerator _randomGenerator;
		private int _totalElementsInDirection;

		public DefaultFieldRandomizer(IRandomGenerator randomGenerator)
		{
			this._randomGenerator = randomGenerator;
			this._totalElementsInDirection = Enum.GetNames(typeof(Direction)).Length;
		}

		/// <summary>
		/// Randomizes the given field.
		/// </summary>
		/// <param name="field">The field.</param>
		public void Randomize(IField field, Difficulty difficulty)
		{
			var movement = new StraightMovement(field);
			int randomizeCycles;

			switch (difficulty)
			{
				case Difficulty.Easy:
					randomizeCycles = 10;
					break;

				case Difficulty.Normal:
					randomizeCycles = 100;
					break;

				case Difficulty.Hard:
					randomizeCycles = 1000;
					break;

				default:
					throw new NotImplementedException();
			}

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
	}
}