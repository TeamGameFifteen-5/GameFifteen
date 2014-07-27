namespace Game.Core.Actions.ActionReceiver
{
	using Game.Common;
	using System;

	public class DefaultActionReceiver : IActionReceiver
	{
		private IDefaultGameEngine _gameEngine;

		public DefaultActionReceiver(IDefaultGameEngine gameEngine)
		{
			this._gameEngine = gameEngine;
		}

		public void Execute(ActionType actionType)
		{
			this._gameEngine.FieldInvalidate();

			switch (actionType.Name)
			{
				case DefaultActionTypes.Up:
				case DefaultActionTypes.Down:
				case DefaultActionTypes.Left:
				case DefaultActionTypes.Right:
					var direction = this.GetMoveDirection(actionType);

					if (this._gameEngine.Move(direction))
					{
						this._gameEngine.FieldInvalidate();
					}
					else
					{
						this._gameEngine.IllegalMove();
					}

					this._gameEngine.Player.Score++;
					break;

				case DefaultActionTypes.Exit:
					this._gameEngine.Exit();
					break;

				case DefaultActionTypes.Reset:
					this._gameEngine.StartGame();
					break;

				case DefaultActionTypes.Scores:
					this._gameEngine.ShowScore();
					break;

				case DefaultActionTypes.Unmapped:
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
					throw new ArgumentException("Invalid action type name. The Action type should be Up, Down, Left or Right.", "actionType.Name");
			}
		}
	}
}