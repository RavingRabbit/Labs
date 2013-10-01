namespace AudioSystem.PlayerStates
{
    class PausedPlayerState : PlayerState
    {
        public override void Play(Player player)
        {
            player.InternalResume();
            player.SetState(new PlayingPlayerState());
        }

        public override void Pause(Player player)
        {
        }

        public override void Stop(Player player)
        {
            player.InternalStop();
            player.SetState(new StoppedPlayerState());
        }
    }
}
