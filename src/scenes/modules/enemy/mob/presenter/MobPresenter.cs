using DodgeTheCreeps.src.scenes.modules.enemy.mob.view;

namespace DodgeTheCreeps.src.scenes.modules.enemy.mob.presenter
{
    public class MobPresenter
    {
        private MobView _view;

        public MobPresenter(MobView view)
        {
            _view = view;
        }

        public void EnableAnimatedSprite()
        {
            _view.MobModel.EnableAnimatedSprite();
        }
    }
}