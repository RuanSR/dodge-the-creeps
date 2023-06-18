using Godot;
using DodgeTheCreeps.src.scenes.modules.player.models;

namespace DodgeTheCreeps.src.scenes.modules.player.view
{
    public interface IPlayer
    {
        Vector2 ScreenSize { get; set; }
        PlayerModel PlayerModel { get; set; }
    }
}