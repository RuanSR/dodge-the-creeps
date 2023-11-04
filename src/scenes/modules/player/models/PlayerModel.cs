using DodgeTheCreeps.src.Scenes.Modules.Player.Enums;
using Godot;


namespace DodgeTheCreeps.src.Scenes.Modules.Player.Models
{
    public class PlayerModel : Area2D
    {

        public readonly int Speed = 400;
        private readonly AnimatedSprite AnimatedSprite;
        private readonly CollisionShape2D CollisionShape2D;

        public PlayerModel(AnimatedSprite animatedSprite, CollisionShape2D collisionShape2D)
        {
            AnimatedSprite = animatedSprite;
            CollisionShape2D = collisionShape2D;
        }

        public void PlayAnimatedSprite()
        {
            AnimatedSprite.Play();
        }

        public void StopAnimatedSprite()
        {
            AnimatedSprite.Stop();
        }

        public void SetAnimationAnimatedSprite(EAnimType animType)
        {
            AnimatedSprite.Animation = animType.ToString().ToLower();
        }

        public void SetFlipAnimatedSprite(EFlipType flipType, bool flipState)
        {
            if (flipType == EFlipType.FlipH) AnimatedSprite.FlipH = flipState;

            if (flipType == EFlipType.FlipV) AnimatedSprite.FlipV = flipState;

        }


        public void SetDeferredCollisionShape2D(string property, bool value)
        {
            CollisionShape2D.SetDeferred(property, value);
        }
    }

}
