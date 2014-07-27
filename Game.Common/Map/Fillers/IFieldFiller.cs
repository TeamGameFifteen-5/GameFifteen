namespace Game.Common.Map.Fillers
{
	/// <summary>
	/// Interface for field filler.
	/// </summary>
	public interface IFieldFiller
	{
		/// <summary>
		/// Fills the field with the specified filler.
		/// </summary>
		/// <param name="field">The field.</param>
		void Fill(IField field);
	}
}