namespace Game.Core.Actions.ActionReceiver
{
    using System;
    using Game.Common;

	public class DefaultActionReceiver : IActionReceiver
	{
		private IDefaultGameEngine _gameEngine;

		public DefaultActionReceiver(IDefaultGameEngine gameEngine)
		{
			this._gameEngine = gameEngine;
		}

		public void Execute(ActionType actionType)
		{
			switch (actionType.Name)
			{
				case DefaultActionTypes.Unmapped:
					this._gameEngine.IllegalMove();
					break;

				case DefaultActionTypes.Up:
				case DefaultActionTypes.Down:
				case DefaultActionTypes.Left:
				case DefaultActionTypes.Right:
					var direction = this.GetMoveDirection(actionType);
					this._gameEngine.Move(direction);
					break;

				case DefaultActionTypes.Exit:
					this._gameEngine.Exit();
					break;

				case DefaultActionTypes.Reset:
					this._gameEngine.RestartGame();
					break;

				case DefaultActionTypes.Scores:
					this._gameEngine.ShowScore();
					break;

				default:
					this._gameEngine.IllegalCommand();
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