namespace Game.Common.Map.Randomizers
{
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