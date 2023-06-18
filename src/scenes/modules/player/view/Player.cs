using Godot;
using DodgeTheCreeps.src.scenes.modules.player.presenter;
using DodgeTheCreeps.src.scenes.modules.player.models;

namespace DodgeTheCreeps.src.scenes.modules.player.view
{
    public class Player : Area2D, IPlayer
    {
        public PlayerModel PlayerModel { get; set; }
        public Vector2 ScreenSize { get; set; }
        private PlayerPresenter _playerPresenter;

        public override void _Ready()
        {
            PlayerModel = new PlayerModel(GetNode<AnimatedSprite>("AnimatedSprite"), GetNode<CollisionShape2D>("CollisionShape2D"));
            _playerPresenter = new PlayerPresenter(this);
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