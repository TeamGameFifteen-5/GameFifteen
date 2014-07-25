namespace Game.UI
{
	using Game.Common.CustomEvents;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.UI.IOProviders;
	using System;

	public class UIEngine : IDefaultUIEngine
	{
		#region Constants

		private const char HORIZONTAL_LINE = '\u2500';
		private const char VERTICAL_LINE = '\u2502';
		private const char UPPER_LEFT_CORNER = '\u250c';
		private const char UPPER_RIGHT_CORNER = '\u2510';
		private const char LOWER_LEFT_CORNER = '\u2514';
		private const char LOWER_RIGHT_CORNER = '\u2518';
		private const string UP_DOWN_TABLE_FRAME = "-------------------------";

		#endregion Constants

		private IIOProvider _ioProvider;
		private IPlayer _player;

		public UIEngine(IPlayer player, IIOProvider ioProvider)
		{
			this._ioProvider = ioProvider;
			this._player = player;

			this._ioProvider.ApplySettings();
		}

		public IInputProvider InputProvider
		{
			get
			{
				return this._ioProvider;
			}
		}

		public void OnGameStart()
		{
		}

		public void OnGameEnd()
		{
			this._ioProvider.DisplayLine("Congratulations! You won the game in {0} moves.", this._player.Score.ToString());

			this._ioProvider.Display("Please enter your name for the top scoreboard: ");
			string name = this._ioProvider.GetTextInput();
			this._player.Name = name;

			this._ioProvider.DisplayLine("Press a any key to try again . .");
			this._ioProvider.GetKeyInput();
		}

		public void OnGameExit()
		{
			this._ioProvider.DisplayLine("Good bye!");
		}

		public void OnGameMovement()
		{
		}

		public void OnGameShowScore(IIntegerStats scores)
		{
			var playerScores = scores.Load();

			this._ioProvider.DisplayLine("{0}{1}", Environment.NewLine, UP_DOWN_TABLE_FRAME);

			foreach (var playerScore in playerScores)
			{
				this._ioProvider.DisplayLine("{0}: {1}", playerScore.Name, playerScore.Value);
			}

			this._ioProvider.DisplayLine("{0}{1}", UP_DOWN_TABLE_FRAME, Environment.NewLine);
		}

		public void OnGameIllegalMove()
		{
			this._ioProvider.DisplayLine("Illegal move!");
		}

		public void OnGameIllegalCommand()
		{
			this._ioProvider.DisplayLine("Illegal command!");
		}

		public virtual void OnGameCustomEvent(object eventObject)
		{
			if (eventObject is FieldInvalidateEvent)
			{
				var fieldInvalidateEvent = (FieldInvalidateEvent)eventObject;
				var field = fieldInvalidateEvent.EventArgs;

				var upperLine = string.Format("{0}{1}{2}", UPPER_LEFT_CORNER, new string(HORIZONTAL_LINE, 13), UPPER_RIGHT_CORNER);
				var lowerLine = string.Format("{0}{1}{2}", LOWER_LEFT_CORNER, new string(HORIZONTAL_LINE, 13), LOWER_RIGHT_CORNER);

				this._ioProvider.Invalidate();
				this.DisplayHeader();

				this._ioProvider.DisplayLine(upperLine);

				foreach (var row in field)
				{
					this._ioProvider.Display(VERTICAL_LINE.ToString() + " ");

					foreach (var col in row)
					{
						this._ioProvider.Display(col >= 10 ? "{0} " : " {0} ", col == 0 ? " " : col.ToString());
					}

					this._ioProvider.DisplayLine(VERTICAL_LINE.ToString());
				}

				this._ioProvider.DisplayLine(lowerLine);
			}
			else if (eventObject is ShowScoreEvent)
			{
				var showScoreEvent = (ShowScoreEvent)eventObject;
				var inMemoryPlayerScores = showScoreEvent.EventArgs;
				this.OnGameShowScore(inMemoryPlayerScores);
			}
			else
			{
				throw new InvalidOperationException("Unhandled custom event is raised!");
			}
		}

		private void DisplayHeader()
		{
			this._ioProvider.DisplayLine("Welcome to the game “15”.\nPlease try to arrange the numbers sequentially.\nUse 'T' to view the top scoreboard, 'R' to start a new game and 'Escape, Q' to quit the game.\nAnd 'W, A, S, D or Arrows' for movement.\n");
		}
	}
}