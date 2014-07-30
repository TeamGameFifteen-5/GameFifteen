namespace Game.Core.Actions.ActionReceiver
{
	using Game.Common;

	public class DefaultActionReceiver : IActionReceiver
	{
        private readonly IDefaultGameEngine _gameEngine;

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
			Direction direction = 0;

			switch (actionType.Name)
			{
				case DefaultActionTypes.Up:
					direction = Direction.Up;
					break;

				case DefaultActionTypes.Down:
					direction = Direction.Down;
					break;

				case DefaultActionTypes.Left:
					direction = Direction.Left;
					break;

				case DefaultActionTypes.Right:
					direction = Direction.Right;
					break;
			}

			return direction;
		}
	}
}