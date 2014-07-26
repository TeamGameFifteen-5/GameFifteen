namespace Game.UI.Renderers
{
	public class DefaultInvalidInputRenderer : IRenderer
	{
		public void Render(IOProviders.IOutputProvider outputProvider)
		{
			outputProvider.DisplayLine("The provided input is not valid in this context!");
		}
	}
}