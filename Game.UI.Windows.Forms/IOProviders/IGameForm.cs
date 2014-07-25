namespace Game.UI.Windows.Forms.IOProviders
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

	public interface IGameForm
	{
		Keys? LastKey { get; set; }

		string GetTextInput();

		Graphics CreateGraphics();

		void Execute(Action action);
	}
}