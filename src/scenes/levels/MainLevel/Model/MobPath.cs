using Godot;

namespace DodgeTheCreeps.src.scenes.levels.MainLevel.Model
{
    public class MobPath : Path2D
    {
        public PathFollow2D MobSpawnLocation { get; private set; }

        public override void _Ready()
        {
            MobSpawnLocation = GetNode<PathFollow2D>("MobSpawnLocation");
        }
    }
}