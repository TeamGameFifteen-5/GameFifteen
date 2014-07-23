using Game.Common;
namespace Game.Core.Movement
{
	public interface IMovement
	{
		bool Move(Direction direction);
	}
}