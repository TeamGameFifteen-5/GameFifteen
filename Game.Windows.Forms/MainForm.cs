using Game.Common.Map;
using Game.Common.Players;
using Game.Core;
using Game.UI;
using Game.UI.Windows.Forms.IOProviders;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Windows.Forms
{
	public partial class MainForm : Form, IGameForm
	{
		private CoreEngine _gameEngine;

		public MainForm()
		{
			InitializeComponent();
		}

		public Keys? LastKey { get; set; }

		public void Execute(Action action)
		{
			this.Invoke(action);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			var consoleIOProvider = new WindowsFormsIOProvider(this);
			var player = new Player();
			var field = new Field();

			var gameUI = new UIEngine(player, consoleIOProvider);
			var gameEngine = new CoreEngine(gameUI, field, player);
			this._gameEngine = gameEngine;

			Task.Run(() => gameEngine.Start());
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e)
		{
			this.LastKey = e.KeyCode;
		}

		private void MainForm_Paint(object sender, PaintEventArgs e)
		{
			if (_gameEngine != null)
			{
				Task.Run(() => _gameEngine.Invalidate());
			}
		}
	}
}