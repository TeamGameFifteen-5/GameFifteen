using Game.UI.IOProviders;

namespace Game.UI.Renderers
{
	public interface IRenderer<TArgs>
	{
		void Render(IOutputProvider outputProvider, TArgs args);
	}
}