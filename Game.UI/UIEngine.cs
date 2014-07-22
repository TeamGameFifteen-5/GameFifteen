﻿using Game.Core;
using Game.Core.Players;
using Game.Core.World;
using Game.UI.IOProviders;

namespace Game.UI
{
	public class UIEngine : IUIEngine
	{
		private ICoreEngine _coreEngine;
		private IIOProvider _ioProvider;
		private IPlayer _player;

		public UIEngine(ICoreEngine coreEngine, IPlayer player, IIOProvider ioProvider)
		{
			this._coreEngine = coreEngine;
			this._ioProvider = ioProvider;
			this._player = player;

			this._ioProvider.Format();
			this.BindEvents();
		}

		public void Start()
		{
			this._coreEngine.Start();
		}

		public void OnGameStart()
		{
			this.DisplayHeader();
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

		/// <summary>
		/// Executes the game invalidate action.
		/// TODO: move to separete class Bridge/Strategy Pattern
		/// </summary>
		/// <param name="field">The field.</param>
		public void OnGameInvalidate(IField field)
		{
			this._ioProvider.Invalidate();
			this.DisplayHeader();

			this._ioProvider.DisplayLine(" -------------");
			for (int row = 0; row < 4; row++)
			{
				this._ioProvider.Display("| ");
				for (int col = 0; col < 4; col++)
				{
					if (field[row, col] >= 10)
					{
						this._ioProvider.Display("{0} ", field[row, col].ToString());
					}
					else
					{
						if (field[row, col] == 0)
						{
							this._ioProvider.Display("   ");
						}
						else
						{
							this._ioProvider.Display(" {0} ", field[row, col].ToString());
						}
					}
				}

				this._ioProvider.DisplayLine("|");
			}

			this._ioProvider.DisplayLine(" -------------");
		}

		private void DisplayHeader()
		{
			this._ioProvider.DisplayLine("Welcome to the game “15”.\nPlease try to arrange the numbers sequentially.\nUse 'T' to view the top scoreboard, 'R' to start a new game and 'Escape, Q' to quit the game.\nAnd 'W, A, S, D or Arrows' for movement.\n");
		}

		private void BindEvents()
		{
			this._coreEngine.GameStart += this.OnGameStart;
			this._coreEngine.GameEnd += this.OnGameEnd;
			this._coreEngine.GameExit += this.OnGameExit;
			this._coreEngine.GameMovement += this.OnGameMovement;
			this._coreEngine.GameIllegalMove += this.OnGameIllegalMove;
			this._coreEngine.GameIllegalCommand += this.OnGameIllegalCommand;
			this._coreEngine.GameInvalidate += this.OnGameInvalidate;
		}
	}
}