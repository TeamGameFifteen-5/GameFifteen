namespace Game.Common.GameOverCheckers
{
    using Game.Common.Map;

	/// <summary>
	/// Interface for solved checker.
	/// </summary>
	public interface IGameOverChecker
	{
		/// <summary>
		/// Query if 'field' is solved.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <returns>
		/// true if solved, false if not.
		/// </returns>
		bool IsItOver(IField field);
	}
}