﻿using Game.Common.Players;
using System;

namespace Game.Common.Stats
{
	public class PlayerStats : IStatsStorage<IPlayer>
	{
		public IPlayer Load()
		{
			return new Player();
		}

		public void Save(IPlayer stats)
		{
			throw new NotImplementedException();
		}
	}
}