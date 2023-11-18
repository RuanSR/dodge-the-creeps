using Godot;

namespace DodgeTheCreeps.src.Scenes.Levels.MainLevel.Model
{
    public class MobPathModel : Path2D
    {
        public PathFollow2D MobSpawnLocation { get; private set; }

        public override void _Ready()
        {
            MobSpawnLocation = GetNode<PathFollow2D>("MobSpawnLocation");
        }
    }
}