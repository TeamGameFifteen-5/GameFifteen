namespace Game.UI.Renderers
{
	public class DefaultExitRenderer : IRenderer
	{
		public void Render(IOProviders.IOutputProvider outputProvider)
		{
			outputProvider.DisplayLine("Good bye!");
		}
	}
}