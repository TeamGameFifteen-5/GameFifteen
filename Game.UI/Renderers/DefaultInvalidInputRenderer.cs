namespace Game.UI.Renderers
{
	using Game.UI.IOProviders;

	public class DefaultInvalidInputRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		public void Render(TOutputProvider outputProvider)
		{
			outputProvider.DisplayLine("The provided input is not valid in this context!");
		}
	}
}