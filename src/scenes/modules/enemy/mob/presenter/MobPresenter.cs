using Godot;
using DodgeTheCreeps.src.Scenes.Modules.Enemy.Mob.Model;
using DodgeTheCreeps.src.Scenes.Modules.Enemy.Mob.View;

namespace DodgeTheCreeps.src.Scenes.Modules.Enemy.Mob.Presenter
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

            _mobModel.ConnectSignals(_view);
        }

        public void EnableAnimatedSprite()
        {
            _mobModel.EnableAnimatedSprite();
        }
    }
}