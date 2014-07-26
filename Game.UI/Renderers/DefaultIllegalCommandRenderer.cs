namespace Game.UI.Renderers
{
	using Game.UI.IOProviders;

	public class DefaultIllegalCommandRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		public void Render(TOutputProvider outputProvider)
		{
			outputProvider.DisplayLine("Illegal command!");
		}
	}
}