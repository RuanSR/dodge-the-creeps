using DodgeTheCreeps.src.model;
using DodgeTheCreeps.src.view;
using Godot;

namespace DodgeTheCreeps.src.presenter
{
    public class MobPresenter
    {
        private Mob _mobModel;
        private IMobView _view;

        public MobPresenter(IMobView view)
        {
            _view = view;
            _mobModel = new Mob(_view.AnimatedSprite);
        }

        public void EnableAnimatedSprite()
        {
            _mobModel.EnableAnimatedSprite();
        }
    }
}