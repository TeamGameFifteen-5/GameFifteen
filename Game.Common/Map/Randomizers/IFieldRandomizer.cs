namespace Game.Common.Map.Randomizers
{
	using Game.Common.Map.Movement;

	/// <summary>
	/// Interface for field randomizer.
	/// </summary>
	public interface IFieldRandomizer
	{
		/// <summary>
		/// Randomizes the given field.
		/// </summary>
		/// <param name="field">The field.</param>
		void Randomize(IField field);
	}
}