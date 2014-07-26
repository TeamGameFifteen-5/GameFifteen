namespace Game.UI.Renderers
{
	using Game.UI.IOProviders;

	public interface IRenderer<TOutputProvider, TArgs>
		where TOutputProvider : IOutputProvider
	{
		void Render(TOutputProvider outputProvider, TArgs args);
	}
}