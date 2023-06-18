using DodgeTheCreeps.src.scenes.modules.enemy.mob.model;
using DodgeTheCreeps.src.scenes.modules.enemy.mob.view;

namespace DodgeTheCreeps.src.scenes.modules.enemy.mob.presenter
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