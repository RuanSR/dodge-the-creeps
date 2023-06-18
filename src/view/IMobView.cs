using Godot;

namespace DodgeTheCreeps.src.view
{
    public interface IMobView
    {
        AnimatedSprite AnimatedSprite { get; set; }
        CollisionShape2D CollisionShape2D { get; set; }
        VisibilityNotifier2D VisibilityNotifier2D { get; set; }
    }
}