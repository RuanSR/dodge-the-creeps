using Godot;
using DodgeTheCreeps.src.scenes.modules.enemy.mob.presenter;
using DodgeTheCreeps.src.scenes.modules.enemy.mob.model;

namespace DodgeTheCreeps.src.scenes.modules.enemy.mob.view
{
    public class MobView : RigidBody2D
    {
        public MobModel MobModel { get; set; }
        private MobPresenter _mobPresenter;

        public override void _Ready()
        {
            MobModel = new MobModel(
                GetNode<AnimatedSprite>("AnimatedSprite"),
                GetNode<CollisionShape2D>("CollisionShape2D"),
                GetNode<VisibilityNotifier2D>("VisibilityNotifier2D"));

            _mobPresenter = new MobPresenter(this);

            _mobPresenter.EnableAnimatedSprite();
        }

        public void OnVisibilityNotifier2DScreenExited()
        {
            QueueFree();
        }
    }
}