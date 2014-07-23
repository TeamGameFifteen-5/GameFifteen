using Game.UI.IOProviders;

namespace Game.UI.Renderers
{
	/// <summary>
	/// Interface for renderer.
	/// </summary>
	public interface IRenderer
	{
		/// <summary>
		/// Formats the given i/o provider.
		/// </summary>
		/// <param name="ioProvider">The i/o provider.</param>
		void Format(IIOProvider ioProvider);
	}
}