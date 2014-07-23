using Game.Core.World;

namespace Game.Core.SolvedCheckers
{
	public interface ISolveChecker
	{
		bool IsSolved(IField field);
	}
}