namespace Game.Core.SolvedCheckers
{
    using Game.Common.Map;

	/// <summary>
	/// Interface for solved checker.
	/// </summary>
	public interface ISolvedChecker
	{
		/// <summary>
		/// Query if 'field' is solved.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <returns>
		/// true if solved, false if not.
		/// </returns>
		bool IsSolved(IField field);
	}
}