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
	public class DefaultUIEngineSettings : IDefaultUIEngineSettings<IPlayer, IField, IStatsStorage>
	{
		#region Constructors

		public DefaultUIEngineSettings(
			IIOProvider ioProvider,
			IPlayer player,
			IIOProviderSettings ioProviderSettings = null,
			IRenderer startRenderer = null,
			IRenderer<IPlayer> endRenderer = null,
			IRenderer exitRenderer = null,
			IRenderer illegalMoveRenderer = null,
			IRenderer illegalCommandRenderer = null,
			IRenderer helpDisplayRenderer = null,
			IRenderer<IField> fieldRenderer = null,
			IRenderer<IStatsStorage> scoreRenderer = null)
		{
			Validation.ThrowIfNull(ioProvider);
			Validation.ThrowIfNull(player);

			this.IOProvider = ioProvider;
			this.IOProviderSettings = ioProviderSettings ?? new DefaultIOProviderSettings();
			this.Player = player;
			this.StartRenderer = startRenderer ?? new DefaultStartRenderer();
			this.EndRenderer = endRenderer ?? new DefaultEndRenderer();
			this.ExitRenderer = exitRenderer ?? new DefaultExitRenderer();
			this.IllegalMoveRenderer = illegalMoveRenderer ?? new DefaultIllegalMoveRenderer();
			this.IllegalCommandRenderer = illegalCommandRenderer ?? new DefaultIllegalCommandRenderer();
			this.HelpDisplayRenderer = helpDisplayRenderer ?? new DefaultHelpDisplayRenderer();
			this.FieldRenderer = fieldRenderer ?? new DefaultFieldRenderer();
			this.ScoreRenderer = scoreRenderer ?? new DefaultScoreRenderer();
		}

		#endregion Constructors

		#region Properties

		public IIOProvider IOProvider { get; private set; }

		public IIOProviderSettings IOProviderSettings { get; private set; }

		public IPlayer Player { get; private set; }

		public IRenderer StartRenderer { get; private set; }

		public IRenderer<IPlayer> EndRenderer { get; private set; }

		public IRenderer ExitRenderer { get; private set; }

		public IRenderer IllegalMoveRenderer { get; private set; }

		public IRenderer IllegalCommandRenderer { get; private set; }

		public IRenderer HelpDisplayRenderer { get; private set; }

		public IRenderer<IField> FieldRenderer { get; private set; }

		public IRenderer<IStatsStorage> ScoreRenderer { get; private set; }

		#endregion Properties
	}
}