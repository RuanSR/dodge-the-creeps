using Godot;

namespace DodgeTheCreeps.src.scenes.modules.enemy.mob.model
{
    public class MobModel
    {
        public AnimatedSprite AnimatedSprite { get; private set; }
        public CollisionShape2D CollisionShape2D { get; private set; }
        public VisibilityNotifier2D VisibilityNotifier2D { get; private set; }
        private string[] _mobTypes;

        public MobModel() { }

        public MobModel(AnimatedSprite animatedSprite, CollisionShape2D collisionShape2D, VisibilityNotifier2D visibilityNotifier2D)
        {
            AnimatedSprite = animatedSprite;
            CollisionShape2D = collisionShape2D;
            VisibilityNotifier2D = visibilityNotifier2D;
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