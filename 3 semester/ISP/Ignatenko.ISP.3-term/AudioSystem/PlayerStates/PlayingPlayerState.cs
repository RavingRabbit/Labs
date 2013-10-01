namespace AudioSystem.PlayerStates
{
    class PlayingPlayerState : PlayerState
    {
        public override void Play(Player player)
        {
        }

        public override void Pause(Player player)
        {
            player.InternalPause();
            player.SetState(new PausedPlayerState());
        }

        public override void Stop(Player player)
        {
            player.InternalStop();
            player.SetState(new StoppedPlayerState());
        }
    }
}
