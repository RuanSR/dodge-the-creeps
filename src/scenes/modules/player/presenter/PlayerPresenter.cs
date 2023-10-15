using Godot;
using DodgeTheCreeps.src.scenes.modules.player.view;
using DodgeTheCreeps.src.scenes.modules.player.models;

namespace DodgeTheCreeps.src.scenes.modules.player.presenter
{
    public class PlayerPresenter
    {
        private readonly PlayerView _payerView;
        private readonly PlayerModel _playerModel;

        public PlayerPresenter(PlayerView player)
        {
            _payerView = player;

            _playerModel = new PlayerModel(
                _payerView.GetNode<AnimatedSprite>("AnimatedSprite"),
                _payerView.GetNode<CollisionShape2D>("CollisionShape2D"));

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
                velocity = velocity.Normalized() * _playerModel.Speed;
                _playerModel.PlayAnimatedSprite();
            }
            else
            {
                _playerModel.StopAnimatedSprite();
            }

            _payerView.Position += velocity * delta;
            _playerModel.Position = new Vector2(
               x: Mathf.Clamp(_payerView.Position.x, 0, _payerView.ScreenSize.x),
               y: Mathf.Clamp(_payerView.Position.y, 0, _payerView.ScreenSize.y)
           );

            if (velocity.x != 0)
            {
                _playerModel.SetAnimationAnimatedSprite(enums.EAnimType.Walk);
                _playerModel.SetFlipAnimatedSprite(enums.EFlipType.FlipV, false);
                _playerModel.SetFlipAnimatedSprite(enums.EFlipType.FlipH, velocity.x < 0);
            }
            else if (velocity.y != 0)
            {
                _playerModel.SetAnimationAnimatedSprite(enums.EAnimType.Up);
                _playerModel.SetFlipAnimatedSprite(enums.EFlipType.FlipV, velocity.y > 0);
            }
        }

        public void OnPlayerBodyEntered(PhysicsBody2D body)
        {
            _payerView.Hide();
            _payerView.EmitSignal("Hit");
            _playerModel.SetDeferredCollisionShape2D("disabled", true);
        }

        public void Start(Vector2 pos)
        {
            _payerView.Position = pos;
            _payerView.Show();
            _playerModel.SetDeferredCollisionShape2D("disabled", false);
        }
    }
}