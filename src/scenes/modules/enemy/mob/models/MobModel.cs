using Godot;

namespace DodgeTheCreeps.src.scenes.modules.enemy.mob.model
{
    public class MobModel
    {
        private readonly AnimatedSprite _animatedSprite;
        private readonly CollisionShape2D _collisionShape2D;
        private readonly VisibilityNotifier2D _visibilityNotifier2D;
        private readonly string[] _mobTypes;

        public MobModel() { }

        public MobModel(AnimatedSprite animatedSprite, CollisionShape2D collisionShape2D, VisibilityNotifier2D visibilityNotifier2D)
        {
            _animatedSprite = animatedSprite;
            _collisionShape2D = collisionShape2D;
            _visibilityNotifier2D = visibilityNotifier2D;
            _mobTypes = _animatedSprite.Frames.GetAnimationNames();
            SetRandomMobTypes();
        }

        public void EnableAnimatedSprite() => _animatedSprite.Playing = true;
        public void DisableAnimatedSprite() => _animatedSprite.Playing = false;

        private void SetRandomMobTypes()
        {
            _animatedSprite.Animation = _mobTypes[GD.Randi() % _mobTypes.Length];
        }

    }
}