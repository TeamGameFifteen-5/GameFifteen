using Game.UI.IOProviders;

namespace Game.UI.Renderers
{
	public interface IRenderer
	{
		void Render(IOutputProvider outputProvider);
	}
}