namespace Game.UI.Windows.Forms.IOProviders
{
	using Game.UI.IOProviders;
	using System.Drawing;

	public interface IWindowsFormsOutputProvider : IOutputProvider
	{
		void DrawImage(Image image);
	}
}