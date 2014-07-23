using Game.Core.World;

namespace Game.Core.SolvedCheckers
{
	public interface ISolvedChecker
	{
		bool IsSolved(IField field);
	}
}