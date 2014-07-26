using Game.UI.IOProviders;

namespace Game.UI.Renderers
{
	public interface IRenderer<TOutputProvider, TArgs>
		where TOutputProvider : IOutputProvider
	{
		void Render(TOutputProvider outputProvider, TArgs args);
	}
}