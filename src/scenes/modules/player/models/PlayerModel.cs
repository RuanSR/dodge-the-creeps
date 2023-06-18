using Godot;


namespace DodgeTheCreeps.src.scenes.modules.player.models
{
    public class PlayerModel : Area2D
    {

        public int Speed = 400;
        [Signal] public delegate void Hit();
        public AnimatedSprite AnimatedSprite { get; set; }
        public CollisionShape2D CollisionShape2D { get; set; }

        public PlayerModel() { }

        public PlayerModel(AnimatedSprite animatedSprite, CollisionShape2D collisionShape2D)
        {
            AnimatedSprite = animatedSprite;
            CollisionShape2D = collisionShape2D;
        }
    }

}
