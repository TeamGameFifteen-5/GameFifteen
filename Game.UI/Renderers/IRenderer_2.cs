using Game.UI.IOProviders;

namespace Game.UI.Renderers
{
	public interface IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		void Render(TOutputProvider outputProvider);
	}
}