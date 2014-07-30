namespace Game.UI
{
    using Game.Common.Map;
    using Game.Common.Players;
    using Game.Common.Stats;
    using Game.Common.Utils;
    using Game.UI.IOProviders;
    using Game.UI.IOProviders.Settings;
    using Game.UI.Renderers;

    /// <summary>
    /// Interface for default user interface engine settings.
    /// </summary>
    /// <seealso cref="IUIEngineSettings"/>
    public class DefaultUIEngineSettings<TIOProvider> : IDefaultUIEngineSettings<TIOProvider, IPlayer, IField, IStatsStorage>
        where TIOProvider : IIOProvider
    {
        #region Fields

        private TIOProvider _iOProvider;
        private IPlayer _player;

        #endregion Fields

        #region Constructors

        public DefaultUIEngineSettings(
            TIOProvider ioProvider,
            IPlayer player,
            IIOProviderSettings ioProviderSettings = null,
            IRenderer<TIOProvider> startRenderer = null,
            IRenderer<TIOProvider> chooseDifficultyRenderer = null,
            IRenderer<TIOProvider, IPlayer> endRenderer = null,
            IRenderer<TIOProvider> exitRenderer = null,
            IRenderer<TIOProvider> illegalMoveRenderer = null,
            IRenderer<TIOProvider> illegalCommandRenderer = null,
            IRenderer<TIOProvider> helpDisplayRenderer = null,
            IRenderer<TIOProvider> invalidInputRenderer = null,
            IRenderer<TIOProvider, IField> fieldRenderer = null,
            IRenderer<TIOProvider, IStatsStorage> scoreRenderer = null)
        {
            Validation.ThrowIfNull(player);

            this.IOProvider = ioProvider;
            this.IOProviderSettings = ioProviderSettings ?? new DefaultIOProviderSettings();
            this.Player = player;
            this.StartRenderer = startRenderer ?? new DefaultStartRenderer<TIOProvider>();
            this.ChooseDifficultyRenderer = chooseDifficultyRenderer ?? new DefaultChooseDifficultyRenderer<TIOProvider>();
            this.EndRenderer = endRenderer ?? new DefaultEndRenderer<TIOProvider>();
            this.ExitRenderer = exitRenderer ?? new DefaultExitRenderer<TIOProvider>();
            this.IllegalMoveRenderer = illegalMoveRenderer ?? new DefaultIllegalMoveRenderer<TIOProvider>();
            this.IllegalCommandRenderer = illegalCommandRenderer ?? new DefaultIllegalCommandRenderer<TIOProvider>();
            this.HelpDisplayRenderer = helpDisplayRenderer ?? new DefaultHelpDisplayRenderer<TIOProvider>();
            this.InvalidInputRenderer = invalidInputRenderer ?? new DefaultInvalidInputRenderer<TIOProvider>();
            this.FieldRenderer = fieldRenderer ?? new DefaultFieldRenderer<TIOProvider>();
            this.ScoreRenderer = scoreRenderer ?? new DefaultScoreRenderer<TIOProvider>();
        }

        #endregion Constructors

        #region Properties

        public TIOProvider IOProvider
        {
            get
            {
                return this._iOProvider;
            }

            private set
            {
                Validation.ThrowIfNull(value);
                this._iOProvider = value;
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

        public IIOProviderSettings IOProviderSettings { get; private set; }

        public IRenderer<TIOProvider> StartRenderer { get; private set; }

        public IRenderer<TIOProvider> ChooseDifficultyRenderer { get; private set; }

        public IRenderer<TIOProvider, IPlayer> EndRenderer { get; private set; }

        public IRenderer<TIOProvider> ExitRenderer { get; private set; }

        public IRenderer<TIOProvider> IllegalMoveRenderer { get; private set; }

        public IRenderer<TIOProvider> IllegalCommandRenderer { get; private set; }

        public IRenderer<TIOProvider> HelpDisplayRenderer { get; private set; }

        public IRenderer<TIOProvider> InvalidInputRenderer { get; private set; }

        public IRenderer<TIOProvider, IField> FieldRenderer { get; private set; }

        public IRenderer<TIOProvider, IStatsStorage> ScoreRenderer { get; private set; }

        #endregion Properties
    }
}