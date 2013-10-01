namespace XonixGame.GameObjectsBase
{
    internal interface IEnemy : IInteractive
    {
        bool CanWalkOnLand { get; }
        bool CanWalkOnWater { get; }
    }
}