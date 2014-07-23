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
			switch (actionType.Name)
			{
				case "Unmapped":
					this._coreEngine.IllegalMove();
					break;

				case "Up":
				case "Down":
				case "Left":
				case "Right":
					var direction = this.GetMoveDirection(actionType);
					this._coreEngine.Move(direction);
					break;

				case "Exit":
					this._coreEngine.Exit();
					break;

				case "Reset":
					this._coreEngine.RestartGame();
					break;

				case "Scores":
					this._coreEngine.ShowScore();
					break;

				default:
					this._coreEngine.IllegalCommand();
					break;
			}
		}

		private Direction GetMoveDirection(ActionType actionType)
		{
			switch (actionType.Name)
			{
				case "Up": return Direction.Up;
				case "Down": return Direction.Down;
				case "Left": return Direction.Left;
				case "Right": return Direction.Right;
				default:
					throw new NotImplementedException();
			}
		}
	}
}