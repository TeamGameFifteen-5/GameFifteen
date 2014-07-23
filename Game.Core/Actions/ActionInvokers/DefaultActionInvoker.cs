using Game.Common;
using System;

namespace Game.Core.Actions.ActionInvokers
{
	public class DefaultActionInvoker : IActionInvoker
	{
		private ICoreEngine _coreEngine;

		public DefaultActionInvoker(ICoreEngine coreEngine)
		{
			this._coreEngine = coreEngine;
		}

		public void Invoke(ActionType actionType)
		{
			switch (actionType)
			{
				case ActionType.Unmapped:
					this._coreEngine.IllegalMove();
					break;

				case ActionType.Up:
				case ActionType.Down:
				case ActionType.Left:
				case ActionType.Right:
					var direction = this.GetMoveDirection(actionType);
					this._coreEngine.Move(direction);
					break;

				case ActionType.Exit:
					this._coreEngine.Exit();
					break;

				case ActionType.Reset:
					this._coreEngine.RestartGame();
					break;

				case ActionType.Scores:
					this._coreEngine.ShowScore();
					break;

				default:
					this._coreEngine.IllegalCommand();
					break;
			}
		}

		private Direction GetMoveDirection(ActionType actionType)
		{
			switch (actionType)
			{
				case ActionType.Up: return Direction.Up;
				case ActionType.Down: return Direction.Down;
				case ActionType.Left: return Direction.Left;
				case ActionType.Right: return Direction.Right;
				default:
					throw new NotImplementedException();
			}
		}
	}
}