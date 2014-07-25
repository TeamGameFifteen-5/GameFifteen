namespace Game.Common.CustomEvents
{
    using System;

	public interface ICustomEvent
	{
		Object EventArgs { get; }
	}
}