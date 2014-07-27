namespace Game.Common.GameOverCheckers
{
	using Game.Common.Map;
	using Game.Common.Utils;

	/// <summary>
	/// Default game over checker.
	/// </summary>
	/// <seealso cref="T:Game.Common.GameOverCheckers.IGameOverChecker"/>
	public class DefaultGameOverChecker : IGameOverChecker
	{
		/// <summary>
		/// Query if 'field' is solved.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <returns>
		/// true if solved, false if not.
		/// </returns>
		public bool IsItOver(IField field)
		{
			Validation.ThrowIfNull(field);

			int numberInCurrentCell = 1;

			foreach (var row in field)
			{
				foreach (var col in row)
				{
					if (numberInCurrentCell == col)
					{
						numberInCurrentCell += 1;
					}
					else
					{
						break;
					}
				}
			}

			return numberInCurrentCell > 15;
		}
	}
}