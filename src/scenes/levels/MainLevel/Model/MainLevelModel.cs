using Godot;
using DodgeTheCreeps.src.scenes.modules.hud.view;
using DodgeTheCreeps.src.scenes.modules.player.view;

namespace DodgeTheCreeps.src.scenes.levels.MainLevel.Model
{
    public class MainLevelModel
    {
        public ColorRect ColorRect { get; set; }
        public Timer MobTimer { get; set; }
        public Timer ScoreTimer { get; set; }
        public Timer StartTimer { get; set; }
        public Position2D StartPosition { get; set; }
        public AudioStreamPlayer AudioStreamMusic { get; set; }
        public AudioStreamPlayer AudioStreamDeadAudio { get; set; }
        public int Score = 0;
        public HudView HudView { get; set; }
        public PlayerView PlayerView { get; set; }
        public MobPath MobPath { get; set; }

        public MainLevelModel(
            ColorRect colorRect, Timer mobTimer, Timer scoreTimer,
            Timer startTimer, Position2D startPosition, AudioStreamPlayer audioStreamMusic,
            AudioStreamPlayer audioStreamDeadAudio, HudView hudView, PlayerView playerView, MobPath mobPath)
        {
            ColorRect = colorRect;
            MobTimer = mobTimer;
            ScoreTimer = scoreTimer;
            StartTimer = startTimer;
            StartPosition = startPosition;
            AudioStreamMusic = audioStreamMusic;
            AudioStreamDeadAudio = audioStreamDeadAudio;
            MobPath = mobPath;
            HudView = hudView;
            PlayerView = playerView;
        }

    }
}