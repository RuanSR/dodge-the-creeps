using Godot;
using DodgeTheCreeps.src.Scenes.Modules.Enemy.Mob.Presenter;

namespace DodgeTheCreeps.src.Scenes.Modules.Enemy.Mob.View
{
    public class MobView : RigidBody2D
    {
        private MobPresenter _mobPresenter;

        public override void _Ready()
        {
            _mobPresenter = new MobPresenter(this);

            _mobPresenter.EnableAnimatedSprite();
        }

        public void OnVisibilityNotifier2DScreenExited()
        {
            QueueFree();
        }
    }
}