namespace Game.Windows.Forms
{
	using Game.Common;
	using Game.Common.Map;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.Core;
	using Game.UI;
	using Game.UI.Windows.Forms.IOProviders;
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

		public void Execute(Action action)
		{
			this.Invoke(action);
		}

		public string GetTextInput()
		{
			string text = "Please provide the required input:";
			string caption = "Message";
			Form prompt = new Form();
			prompt.Width = 500;
			prompt.Height = 150;
			prompt.Text = caption;
			prompt.StartPosition = FormStartPosition.CenterScreen;
			Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 400 };
			TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
			Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
			confirmation.Click += (sender, e) => { prompt.Close(); };
			prompt.Controls.Add(textBox);
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(textLabel);
			prompt.AcceptButton = confirmation;
			prompt.ShowDialog();
			return textBox.Text;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			var consoleIOProvider = new WindowsFormsIOProvider(this);
			var player = new Player();
			var field = new Field();

			var gameUI = new UIEngine(player, consoleIOProvider);
			var gameEngineSettings = new GameEngineSettings<IDefaultUIEngine, IIntegerStats>(Difficulty.Easy, gameUI, field, player, InMemoryScores.Instance);
			var gameEngine = new GameEngine(gameEngineSettings);
			this._gameEngine = gameEngine;

			Task.Run(() => gameEngine.Start());
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e)
		{
			this.LastKey = e.KeyCode;
		}

		private void MainForm_Paint(object sender, PaintEventArgs e)
		{
			if (this._gameEngine != null)
			{
				Task.Run(() => this._gameEngine.FieldInvalidate());
			}
		}
	}
}