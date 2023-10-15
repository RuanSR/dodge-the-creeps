using Godot;
using DodgeTheCreeps.src.scenes.modules.enemy.mob.model;
using DodgeTheCreeps.src.scenes.modules.enemy.mob.view;

namespace DodgeTheCreeps.src.scenes.modules.enemy.mob.presenter
{
    public class MobPresenter
    {
        private readonly MobView _view;
        private readonly MobModel _mobModel;

        public MobPresenter(MobView view)
        {
            _view = view;

            _mobModel = new MobModel(
                _view.GetNode<AnimatedSprite>("AnimatedSprite"),
                _view.GetNode<CollisionShape2D>("CollisionShape2D"),
                _view.GetNode<VisibilityNotifier2D>("VisibilityNotifier2D"));
        }

        public void EnableAnimatedSprite()
        {
            _mobModel.EnableAnimatedSprite();
        }
    }
}