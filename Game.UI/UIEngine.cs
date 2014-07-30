namespace Game.UI
{
    using Game.Common;
    using Game.Common.CustomEvents;
    using Game.Common.Map;
    using Game.Common.Players;
    using Game.Common.Stats;
    using Game.Common.Utils;
    using Game.UI.IOProviders;
    using System;

	public class UIEngine<TIOProvider> : IDefaultUIEngine
			where TIOProvider : IIOProvider
	{
		#region Constants

		private const string CONTINUE_ON_KEYPRESS = "Press a any key to try again . .";

		#endregion Constants

        private readonly TIOProvider _ioProvider;
        private IPlayer _player;
		private IDefaultUIEngineSettings<TIOProvider, IPlayer, IField, IStatsStorage> _settings;

		public UIEngine(IDefaultUIEngineSettings<TIOProvider, IPlayer, IField, IStatsStorage> settings)
		{
			this.Settings = settings;
			this._ioProvider = settings.IOProvider;
			this.Player = settings.Player;

			this._ioProvider.ApplySettings(settings.IOProviderSettings);
		}

        public IInputProvider InputProvider
        {
			get
			{
				return this._ioProvider;
			}
		}

        public IDefaultUIEngineSettings<TIOProvider, IPlayer, IField, IStatsStorage> Settings
        {
            get
            {
                return this._settings;
            }
            private set
            {
                Validation.ThrowIfNull(value);
                this._settings = value;
            }
        }

        public IPlayer Player
        {
            get
            {
                return this._player;
            }
            private set
            {
                Validation.ThrowIfNull(value);
                this._player = value;
            }
        }

		public Difficulty Difficulty { get; private set; }

		public virtual void OnGameStart()
		{
			bool hasName = !string.IsNullOrWhiteSpace(this._player.Name);

			if (!hasName)
			{
				bool? isInputValid = null;
				while (!isInputValid.HasValue || !isInputValid.Value)
				{
					this._ioProvider.Invalidate();
					this._settings.StartRenderer.Render(this._ioProvider);
					this._player.Name = this._ioProvider.GetTextInput();

					isInputValid = !string.IsNullOrWhiteSpace(this._player.Name);
				}

				isInputValid = null;
				while (!isInputValid.HasValue || !isInputValid.Value)
				{
					this._ioProvider.Invalidate();
					this._settings.ChooseDifficultyRenderer.Render(this._ioProvider);
					string difficultyIndex = this._ioProvider.GetTextInput();
					byte difficulty;
					isInputValid = byte.TryParse(difficultyIndex, out difficulty);

					if (isInputValid.Value)
					{
						difficulty -= 1;
						isInputValid = Enum.GetNames(typeof(Difficulty)).Length > difficulty;
						if (isInputValid.Value)
						{
							this.Difficulty = (Difficulty)difficulty;
						}
					}
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