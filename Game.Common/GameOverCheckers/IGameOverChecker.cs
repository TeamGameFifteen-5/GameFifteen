namespace Game.Common.GameOverCheckers
{
    using Game.Common.Map;

	/// <summary>
	/// Interface for game over checker.
	/// </summary>
	public interface IGameOverChecker
	{
		/// <summary>
		/// Query if 'field' is iterator over.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <returns>
		/// true if iterator over, false if not.
		/// </returns>
		bool IsItOver(IField field);
	}
}