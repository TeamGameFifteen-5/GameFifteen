using System;

namespace Game.Common.CustomEvents
{
	public interface ICustomEvent
	{
		Object EventArgs { get; }
	}
}