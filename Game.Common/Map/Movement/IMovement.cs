namespace Game.Common.Map.Movement
{
    /// <summary>
    /// Interface for movement.
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// Moves to the given direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>
        /// true if it succeeds, false if it fails.
        /// </returns>
        bool Move(Direction direction);
    }
}
