namespace Game.UI
{
	using Game.Common.CustomEvents;
	using Game.Common.Map;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.UI.IOProviders;
	using System;

	public class UIEngine : IDefaultUIEngine
	{
		#region Constants

		private const string CONTINUE_ON_KEYPRESS = "Press a any key to try again . .";

		#endregion Constants

		private IIOProvider _ioProvider;
		private IPlayer _player;
		private IDefaultUIEngineSettings<IPlayer, IField, IStatsStorage> _settings;

		public UIEngine(IDefaultUIEngineSettings<IPlayer, IField, IStatsStorage> settings)
		{
			this._settings = settings;
			this._ioProvider = settings.IOProvider;
			this._player = settings.Player;

			this._ioProvider.ApplySettings(settings.IOProviderSettings);
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
				this._settings.StartRenderer.Render(this._ioProvider);
				while (string.IsNullOrEmpty(this._player.Name))
				{
					this._player.Name = this._ioProvider.GetTextInput();
				}
			}
		}

		public virtual void OnGameEnd()
		{
			this._settings.EndRenderer.Render(this._ioProvider, this._player);
			this._ioProvider.DisplayLine(CONTINUE_ON_KEYPRESS);
			this._ioProvider.GetKeyInput();
		}

		public virtual void OnGameExit()
		{
			this._settings.ExitRenderer.Render(this._ioProvider);
		}

		public virtual void OnGameMovement()
		{
		}

		public virtual void OnGameIllegalMove()
		{
			this._settings.IllegalMoveRenderer.Render(this._ioProvider);
		}

		public virtual void OnGameIllegalCommand()
		{
			this._settings.IllegalCommandRenderer.Render(this._ioProvider);
		}

		public virtual void OnGameCustomEvent(object eventObject)
		{
			if (eventObject is FieldInvalidateEvent)
			{
				var fieldInvalidateEvent = (FieldInvalidateEvent)eventObject;
				var field = fieldInvalidateEvent.EventArgs;
				this._ioProvider.Invalidate();
				this._settings.HelpDisplayRenderer.Render(this._ioProvider);
				this._settings.FieldRenderer.Render(this._ioProvider, field);
			}
			else if (eventObject is ShowScoreEvent)
			{
				var showScoreEvent = (ShowScoreEvent)eventObject;
				var inMemoryPlayerScores = showScoreEvent.EventArgs;
				this._settings.ScoreRenderer.Render(this._ioProvider, inMemoryPlayerScores);
			}
			else
			{
				throw new InvalidOperationException("Unhandled custom event is raised!");
			}
		}
	}
}