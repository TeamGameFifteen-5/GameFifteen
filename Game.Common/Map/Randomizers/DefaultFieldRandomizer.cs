namespace Game.Common.Map.Randomizers
{
    using System;
	using Game.Common.Map.Movement;
    using Game.Common.Utils;
    
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
        public void Randomize(IField field)
        {
			var movement = new StraightMovement(field);

            for (int i = 0; i < 1000; i++)
            {
                int randomNumber = this._randomGenerator.Next(this._totalElementsInDirection);
                
                Direction direction = (Direction)Enum.Parse(typeof(Direction), randomNumber.ToString());

                if (!movement.Move(direction))
                {
                    i--;
                }
            }
        }
    }
}