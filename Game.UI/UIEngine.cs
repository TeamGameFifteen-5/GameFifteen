namespace Game.UI
{
	using Game.Common.CustomEvents;
	using Game.Common.Players;
	using Game.UI.IOProviders;
	using Game.UI.Renderers;
	using System;

	public class UIEngine : IDefaultUIEngine
	{
		#region Constants

		private const string ContinueOnKeyPress = "Press a any key to try again . .";

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

		public virtual void OnGameStart()
		{
			if (string.IsNullOrEmpty(this._player.Name))
			{
				this._ioProvider.Invalidate();
				new DefaultStartRenderer().Render(this._ioProvider);
				while (string.IsNullOrEmpty(this._player.Name))
				{
					this._player.Name = this._ioProvider.GetTextInput();
				}
			}
		}

		public virtual void OnGameEnd()
		{
			new DefaultEndRenderer().Render(this._ioProvider, this._player);
			this._ioProvider.DisplayLine(ContinueOnKeyPress);
			this._ioProvider.GetKeyInput();
		}

		public virtual void OnGameExit()
		{
			new DefaultExitRenderer().Render(this._ioProvider);
		}

		public virtual void OnGameMovement()
		{
		}

		public virtual void OnGameIllegalMove()
		{
			new DefaultIllegalMoveRenderer().Render(this._ioProvider);
		}

		public virtual void OnGameIllegalCommand()
		{
			new DefaultIllegalCommandRenderer().Render(this._ioProvider);
		}

		public virtual void OnGameCustomEvent(object eventObject)
		{
			if (eventObject is FieldInvalidateEvent)
			{
				var fieldInvalidateEvent = (FieldInvalidateEvent)eventObject;
				var field = fieldInvalidateEvent.EventArgs;
				this._ioProvider.Invalidate();
				new DefaultHelpDisplayRenderer().Render(this._ioProvider);
				new DefaultFieldRenderer().Render(this._ioProvider, field);
			}
			else if (eventObject is ShowScoreEvent)
			{
				var showScoreEvent = (ShowScoreEvent)eventObject;
				var inMemoryPlayerScores = showScoreEvent.EventArgs;
				new DefaultScoreRenderer().Render(this._ioProvider, inMemoryPlayerScores);
			}
			else
			{
				throw new InvalidOperationException("Unhandled custom event is raised!");
			}
		}
	}
}