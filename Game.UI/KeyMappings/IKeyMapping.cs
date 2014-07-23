using Game.Core.Actions;

namespace Game.UI.KeyMappings
{
	public interface IKeyMapping<TKey>
	{
		ActionType Map(TKey key);
	}
}