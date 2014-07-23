using Game.Core.World;

namespace Game.Core.SolvedCheckers
{
	public class DefaultSolveChecker : ISolveChecker
	{
		public bool IsSolved(IField field)
		{
			if (field[3, 3] == 0)
			{
				int numberInCurrentCell = 1;
				for (int row = 0; row < 4; row++)
				{
					for (int col = 0; col < 4; col++)
					{
						if (numberInCurrentCell <= 15)
						{
							if (field[row, col] == numberInCurrentCell)
							{
								numberInCurrentCell++;
							}
							else
							{
								return false;
							}
						}
						else
						{
							return true;
						}
					}
				}
			}

			return false;
		}
	}
}