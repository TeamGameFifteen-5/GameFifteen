namespace Game.Core.Stats
{
	internal interface IStatsStorage<TStats>
	{
		TStats Load();

		void Save(TStats stats);
	}
}