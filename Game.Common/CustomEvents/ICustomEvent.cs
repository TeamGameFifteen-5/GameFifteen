namespace Game.Common.CustomEvents
{
	/// <summary>
	/// Interface for custom event.
	/// </summary>
	public interface ICustomEvent
	{
		/// <summary>
		/// Gets the event arguments.
		/// </summary>
		/// <value>
		/// The event arguments.
		/// </value>
		object EventArgs { get; }
	}
}