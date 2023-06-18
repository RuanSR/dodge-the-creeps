using Godot;
using DodgeTheCreeps.src.scenes.modules.player.view;
using DodgeTheCreeps.src.scenes.modules.player.models;

namespace DodgeTheCreeps.src.scenes.modules.player.presenter
{
    public class PlayerPresenter
    {
        private Player _payer;

        public PlayerPresenter(Player player)
        {
            _payer = player;
        }


        public void ActionMovimentPressed(float delta)
        {
            var velocity = Vector2.Zero;

            if (Input.IsActionPressed("ui_right"))
            {
                velocity.x += 1;
            }

            if (Input.IsActionPressed("ui_left"))
            {
                velocity.x -= 1;
            }

            if (Input.IsActionPressed("ui_down"))
            {
                velocity.y += 1;
            }

            if (Input.IsActionPressed("ui_up"))
            {
                velocity.y -= 1;
            }

            if (velocity.Length() > 0)
            {
                velocity = velocity.Normalized() * _payer.PlayerModel.Speed;
                _payer.PlayerModel.AnimatedSprite.Play();
            }
            else
            {
                _payer.PlayerModel.AnimatedSprite.Stop();
            }

            _payer.Position += velocity * delta;
            _payer.PlayerModel.Position = new Vector2(
               x: Mathf.Clamp(_payer.Position.x, 0, _payer.ScreenSize.x),
               y: Mathf.Clamp(_payer.Position.y, 0, _payer.ScreenSize.y)
           );

            if (velocity.x != 0)
            {
                _payer.PlayerModel.AnimatedSprite.Animation = "walk";
                _payer.PlayerModel.AnimatedSprite.FlipV = false;
                _payer.PlayerModel.AnimatedSprite.FlipH = velocity.x < 0;
            }
            else if (velocity.y != 0)
            {
                _payer.PlayerModel.AnimatedSprite.Animation = "up";
                _payer.PlayerModel.AnimatedSprite.FlipV = velocity.y > 0;
            }
        }

        public void OnPlayerBodyEntered(PhysicsBody2D body)
        {
            _payer.Hide();
            _payer.EmitSignal(nameof(PlayerModel.Hit));
            _payer.PlayerModel.CollisionShape2D.SetDeferred("disabled", true);
        }

        public void Start(Vector2 pos)
        {
            _payer.Position = pos;
            _payer.Show();
            _payer.PlayerModel.CollisionShape2D.Disabled = false;
        }
    }
}