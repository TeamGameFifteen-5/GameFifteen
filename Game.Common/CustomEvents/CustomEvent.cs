namespace Game.Common.CustomEvents
{
	public abstract class CustomEvent<TEventArgs> : ICustomEvent
	{
		public CustomEvent(TEventArgs eventArgs)
		{
			this.EventArgs = eventArgs;
		}

		public TEventArgs EventArgs { get; private set; }

		object ICustomEvent.EventArgs
		{
			get
			{
				return EventArgs;
			}
		}
	}
}