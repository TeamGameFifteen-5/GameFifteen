namespace Game.Core.Actions.ActionInvokers
{
    using System;
    using Game.Common;

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
				case DefaultActionTypes.Unmapped:
					this._coreEngine.IllegalMove();
					break;

				case DefaultActionTypes.Up:
				case DefaultActionTypes.Down:
				case DefaultActionTypes.Left:
				case DefaultActionTypes.Right:
					var direction = this.GetMoveDirection(actionType);
					this._coreEngine.Move(direction);
					break;

				case DefaultActionTypes.Exit:
					this._coreEngine.Exit();
					break;

				case DefaultActionTypes.Reset:
					this._coreEngine.RestartGame();
					break;

				case DefaultActionTypes.Scores:
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
				case DefaultActionTypes.Up: return Direction.Up;
				case DefaultActionTypes.Down: return Direction.Down;
				case DefaultActionTypes.Left: return Direction.Left;
				case DefaultActionTypes.Right: return Direction.Right;
				default:
					throw new NotImplementedException();
			}
		}
	}
}