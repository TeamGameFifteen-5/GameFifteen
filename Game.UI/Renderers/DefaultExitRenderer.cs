namespace Game.UI.Renderers
{
	using Game.UI.IOProviders;

	public class DefaultExitRenderer<TOutputProvider> : IRenderer<TOutputProvider>
		where TOutputProvider : IOutputProvider
	{
		public void Render(TOutputProvider outputProvider)
		{
			outputProvider.DisplayLine("Good bye!");
		}
	}
}