using System;
using DodgeTheCreeps.src.presenter;
using Godot;

namespace DodgeTheCreeps.src.view
{
    public class MobView : RigidBody2D, IMobView
    {
        public AnimatedSprite AnimatedSprite { get; set; }
        public CollisionShape2D CollisionShape2D { get; set; }
        public VisibilityNotifier2D VisibilityNotifier2D { get; set; }

        private MobPresenter _mobPresenter;

        public override void _Ready()
        {
            AnimatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
            CollisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
            VisibilityNotifier2D = GetNode<VisibilityNotifier2D>("VisibilityNotifier2D");

            _mobPresenter = new MobPresenter(this);
            _mobPresenter.EnableAnimatedSprite();
        }

        public void OnVisibilityNotifier2DScreenExited()
        {
            QueueFree();
        }
    }
}