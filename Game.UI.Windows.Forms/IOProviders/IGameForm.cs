using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game.UI.Windows.Forms.IOProviders
{
	public interface IGameForm
	{
		Keys? LastKey { get; set; }

		Graphics CreateGraphics();

		void Execute(Action action);
	}
}