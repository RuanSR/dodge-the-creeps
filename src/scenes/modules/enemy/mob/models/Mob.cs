using Godot;

namespace DodgeTheCreeps.src.scenes.modules.enemy.mob.model
{
    public class Mob
    {
        public AnimatedSprite AnimatedSprite { get; private set; }
        private string[] _mobTypes;

        public Mob() { }

        public Mob(AnimatedSprite animatedSprite)
        {
            AnimatedSprite = animatedSprite;
            _mobTypes = AnimatedSprite.Frames.GetAnimationNames();
            SetRandomMobTypes();
        }

        public void EnableAnimatedSprite() => AnimatedSprite.Playing = true;
        public void DisableAnimatedSprite() => AnimatedSprite.Playing = false;

        private void SetRandomMobTypes()
        {
            AnimatedSprite.Animation = _mobTypes[GD.Randi() % _mobTypes.Length];
        }

    }
}