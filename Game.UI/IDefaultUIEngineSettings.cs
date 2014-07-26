namespace Game.UI
{
	using Game.UI.Renderers;

	/// <summary>
	/// Interface for default user interface engine settings.
	/// </summary>
	/// <typeparam name="TEndArg">  Type of the end argument.</typeparam>
	/// <typeparam name="TFieldArg">Type of the field argument.</typeparam>
	/// <typeparam name="TScoreArg">Type of the score argument.</typeparam>
	/// <seealso cref="IUIEngineSettings"/>
	public interface IDefaultUIEngineSettings<TEndArg, TFieldArg, TScoreArg> : IUIEngineSettings
	{
		/// <summary>
		/// Gets the start renderer.
		/// </summary>
		/// <value>
		/// The start renderer.
		/// </value>
		IRenderer StartRenderer { get; }

		/// <summary>
		/// Gets the choose difficulty.
		/// </summary>
		/// <value>
		/// The choose difficulty.
		/// </value>
		IRenderer ChooseDifficultyRenderer { get; }

		/// <summary>
		/// Gets the end renderer.
		/// </summary>
		/// <value>
		/// The end renderer.
		/// </value>
		IRenderer<TEndArg> EndRenderer { get; }

		/// <summary>
		/// Gets the exit renderer.
		/// </summary>
		/// <value>
		/// The exit renderer.
		/// </value>
		IRenderer ExitRenderer { get; }

		/// <summary>
		/// Gets the illegal move renderer.
		/// </summary>
		/// <value>
		/// The illegal move renderer.
		/// </value>
		IRenderer IllegalMoveRenderer { get; }

		/// <summary>
		/// Gets the illegal command renderer.
		/// </summary>
		/// <value>
		/// The illegal command renderer.
		/// </value>
		IRenderer IllegalCommandRenderer { get; }

		/// <summary>
		/// Gets the help display renderer.
		/// </summary>
		/// <value>
		/// The help display renderer.
		/// </value>
		IRenderer HelpDisplayRenderer { get; }

		/// <summary>
		/// Gets the invalid input renderer.
		/// </summary>
		/// <value>
		/// The invalid input renderer.
		/// </value>
		IRenderer InvalidInputRenderer { get; }

		/// <summary>
		/// Gets the field renderer.
		/// </summary>
		/// <value>
		/// The field renderer.
		/// </value>
		IRenderer<TFieldArg> FieldRenderer { get; }

		/// <summary>
		/// Gets the score renderer.
		/// </summary>
		/// <value>
		/// The score renderer.
		/// </value>
		IRenderer<TScoreArg> ScoreRenderer { get; }
	}
}