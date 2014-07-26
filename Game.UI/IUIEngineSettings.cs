﻿namespace Game.UI
{
	using Game.Common.Players;
	using Game.UI.IOProviders;
	using Game.UI.IOProviders.Settings;

	/// <summary>
	/// Interface for iui engine settings.
	/// </summary>
	public interface IUIEngineSettings
	{
		/// <summary>
		/// Gets the i/o provider.
		/// </summary>
		/// <value>
		/// The i/o provider.
		/// </value>
		IIOProvider IOProvider { get; }

		/// <summary>
		/// Gets the i/o provider settings.
		/// </summary>
		/// <value>
		/// The i/o provider settings.
		/// </value>
		IIOProviderSettings IOProviderSettings { get; }

		/// <summary>
		/// Gets the player.
		/// </summary>
		/// <value>
		/// The player.
		/// </value>
		IPlayer Player { get; }
	}
}