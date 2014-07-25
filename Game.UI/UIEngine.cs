﻿namespace Game.UI
{
    using System;
    using Game.Common.CustomEvents;
    using Game.Common.Players;
    using Game.UI.IOProviders;

	public class UIEngine : IUIEngine
	{
		#region Constants

		private const char Horizontal = '\u2500';
		private const char Vertical = '\u2502';
		private const char UpperLeftCorner = '\u250c';
		private const char UpperRightCorner = '\u2510';
		private const char LowerLeftCorner = '\u2514';
		private const char LowerRightCorner = '\u2518';

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
			string result = this._player.Score + " moves by " + name;
		}

		public void OnGameExit()
		{
			this._ioProvider.DisplayLine("Good bye!");
		}

		public void OnGameMovement()
		{
			this._ioProvider.DisplayLine("Press a button to move . . .");
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
			if (eventObject is FieldInvalidateEvent)
			{
				var fieldInvalidateEvent = (FieldInvalidateEvent)eventObject;
				var field = fieldInvalidateEvent.EventArgs;

				var upperLine = string.Format("{0}{1}{2}", UpperLeftCorner, new string(Horizontal, 13), UpperRightCorner);
				var lowerLine = string.Format("{0}{1}{2}", LowerLeftCorner, new string(Horizontal, 13), LowerRightCorner);

				this._ioProvider.Invalidate();
				this.DisplayHeader();

				this._ioProvider.DisplayLine(upperLine);

				foreach (var row in field)
				{
					this._ioProvider.Display(Vertical.ToString() + " ");

					foreach (var col in row)
					{
						this._ioProvider.Display(col >= 10 ? "{0} " : " {0} ", col == 0 ? " " : col.ToString());
					}

					this._ioProvider.DisplayLine(Vertical.ToString());
				}

				this._ioProvider.DisplayLine(lowerLine);
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