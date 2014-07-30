namespace Game.Common.CustomEvents
{
    using Game.Common.Utils;

	/// <summary>
	/// Represents Custom event.
	/// </summary>
	/// <typeparam name="TEventArgs">Type of the event arguments.</typeparam>
	/// <seealso cref="Game.Common.CustomEvents.ICustomEvent"/>
	public abstract class CustomEvent<TEventArgs> : ICustomEvent
	{
		/// <summary>
		/// Initializes a new instance of the CustomEvent class.
		/// </summary>
		/// <param name="eventArgs">T event information.</param>
		public CustomEvent(TEventArgs eventArgs)
		{
			Validation.ThrowIfNull(eventArgs);

			this.EventArgs = eventArgs;
		}

		/// <summary>
		/// Gets the event arguments.
		/// </summary>
		/// <value>
		/// The event arguments.
		/// </value>
		public TEventArgs EventArgs { get; private set; }

		/// <summary>
		/// Gets the event arguments.
		/// </summary>
		/// <value>
		/// The event arguments.
		/// </value>
		object ICustomEvent.EventArgs
		{
			get
			{
				return this.EventArgs;
			}
		}
	}
}