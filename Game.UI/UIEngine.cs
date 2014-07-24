using Game.Common.Map;
using Game.Common.Players;
using Game.UI.IOProviders;
using System;

namespace Game.UI
{
	public class UIEngine : IUIEngine
	{
		private IIOProvider _ioProvider;
		private IPlayer _player;

		public UIEngine(IPlayer player, IIOProvider ioProvider)
		{
			this._ioProvider = ioProvider;
			this._player = player;

			this._ioProvider.Format();
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
			string result = this._player.Score + " moves by " + name;
		}

		public void OnGameExit()
		{
			this._ioProvider.DisplayLine("Good bye!");
		}

		public void OnGameMovement()
		{
			this._ioProvider.Display("Enter a number to move: ");
		}

		public void OnGameIllegalMove()
		{
			this._ioProvider.DisplayLine("Illegal move!");
		}

		public void OnGameIllegalCommand()
		{
			this._ioProvider.DisplayLine("Illegal command!");
		}

		public virtual void OnGameCustomEvent(Object eventObject)
		{
			if (eventObject is IField)
			{
				var field = (IField)eventObject;
				this._ioProvider.Invalidate();
				this.DisplayHeader();

				this._ioProvider.DisplayLine(" -------------");

				foreach (var row in field)
				{
					this._ioProvider.Display("| ");

					foreach (var col in row)
					{
						this._ioProvider.Display(col >= 10 ? "{0} " : " {0} ", col == 0 ? " " : col.ToString());
					}

					this._ioProvider.DisplayLine("|");
				}

				this._ioProvider.DisplayLine(" -------------");
			}
		}

		private void DisplayHeader()
		{
			this._ioProvider.DisplayLine("Welcome to the game “15”.\nPlease try to arrange the numbers sequentially.\nUse 'T' to view the top scoreboard, 'R' to start a new game and 'Escape, Q' to quit the game.\nAnd 'W, A, S, D or Arrows' for movement.\n");
		}
	}
}