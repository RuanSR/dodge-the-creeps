using Godot;
using DodgeTheCreeps.src.scenes.modules.player.presenter;

namespace DodgeTheCreeps.src.scenes.modules.player.view
{
    public class PlayerView : Area2D
    {
        [Signal]
        public delegate void Hit();

        public Vector2 ScreenSize { get; set; }
        private PlayerPresenter _playerPresenter;

        public override void _Ready()
        {
            _playerPresenter = new PlayerPresenter(this);
            Connect("body_entered", this, nameof(OnPlayerBodyEntered));
        }

        public override void _Process(float delta)
        {
            _playerPresenter.ActionMovimentPressed(delta);
        }

        public void OnPlayerBodyEntered(PhysicsBody2D body)
        {
            _playerPresenter.OnPlayerBodyEntered(body);
        }

        public void Start(Vector2 pos)
        {
            _playerPresenter.Start(pos);
        }
    }
}