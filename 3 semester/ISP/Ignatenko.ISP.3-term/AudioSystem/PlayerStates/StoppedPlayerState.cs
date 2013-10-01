namespace AudioSystem.PlayerStates
{
    class StoppedPlayerState : PlayerState
    {
        public override void Play(Player player)
        {
            player.InternalPlay();
            player.SetState(new PlayingPlayerState());
        }

        public override void Pause(Player player)
        {
        }

        public override void Stop(Player player)
        {
        }
    }
}
