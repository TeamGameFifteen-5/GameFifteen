namespace Game.Windows.Forms
{
	using Game.Common.Map;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.Core;
	using Game.UI;
	using Game.UI.Windows.Forms.IOProviders;
	using Game.UI.Windows.Forms.IOProviders.Settings;
	using Game.UI.Windows.Forms.Renderers;
	using System;
	using System.Threading.Tasks;
	using System.Windows.Forms;

	public partial class MainForm : Form, IGameForm
	{
		private GameEngine _gameEngine;

		public MainForm()
		{
			this.InitializeComponent();
		}

		public Keys? LastKey { get; set; }

		public bool IsShiftPressed { get; set; }

		public void Execute(Action action)
		{
			this.Invoke(action);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			var ioProvider = new WindowsFormsIOProvider(this);
			var player = new Player();
			var field = new Field();

			var gameUISettngs = new DefaultUIEngineSettings<WindowsFormsIOProvider>(
				ioProvider,
				player,
				ioProviderSettings: new WindowsFormsIOProviderSettings(),
				startRenderer: new StartWindowRenderer<WindowsFormsIOProvider>(),
				exitRenderer: new ExitWindowRenderer<WindowsFormsIOProvider>(),
				chooseDifficultyRenderer: new ChooseDifficultyWindowRenderer<WindowsFormsIOProvider>(),
				helpDisplayRenderer: new HelpDisplayWindowRenderer<WindowsFormsIOProvider>(),
				fieldRenderer: new FieldWindowsRenderer<WindowsFormsIOProvider>());

			var gameUI = new UIEngine<WindowsFormsIOProvider>(gameUISettngs);
			var gameEngineSettings = new GameEngineSettings<IDefaultUIEngine, IIntegerStats>(gameUI, field, player, InMemoryScores.Instance);
			var gameEngine = new GameEngine(gameEngineSettings);
			this._gameEngine = gameEngine;

			Task.Run(() => gameEngine.Start());
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e)
		{
			this.LastKey = e.KeyCode;
			this.IsShiftPressed = e.Shift;
		}
	}
}