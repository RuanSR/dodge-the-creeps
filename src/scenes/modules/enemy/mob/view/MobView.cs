using Godot;
using DodgeTheCreeps.src.scenes.modules.enemy.mob.presenter;

namespace DodgeTheCreeps.src.scenes.modules.enemy.mob.view
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