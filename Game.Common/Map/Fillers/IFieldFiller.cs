namespace Game.Common.Map.Fillers
{
	/// <summary>
	/// Interface for field filler.
	/// </summary>
	public interface IFieldFiller
	{
		/// <summary>
		/// Fills the field with the specified filler and size.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <param name="size"> The size.</param>
		void Fill(IField field, int size);
	}
}