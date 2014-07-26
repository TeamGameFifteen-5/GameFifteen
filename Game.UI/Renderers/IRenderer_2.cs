namespace Game.UI.Renderers
{
	using Game.UI.IOProviders;

	public interface IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		void Render(TOutputProvider outputProvider);
	}
}