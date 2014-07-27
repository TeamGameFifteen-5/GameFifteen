namespace Game.UI.Windows.Forms.IOProviders
{
	using Game.UI.IOProviders;
	using System.Drawing;

	/// <summary>
	/// Interface for windows forms output provider.
	/// </summary>
	/// <seealso cref="IOutputProvider"/>
	public interface IWindowsFormsOutputProvider : IOutputProvider
	{
		/// <summary>
		/// Draw image.
		/// </summary>
		/// <param name="image">The image.</param>
		void DrawImage(Image image);
	}
}