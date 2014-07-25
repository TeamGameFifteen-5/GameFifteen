namespace Game.Common.GameOverCheckers
{
	using Game.Common.Map;

	public class DefaultGameOverChecker : IGameOverChecker
	{
		public bool IsItOver(IField field)
		{
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