using System;
using System.Collections.Generic;
using System.Linq;

namespace AudioSystem
{
    class Program
    {
        private static readonly ObjectPool<Player> Pool = new ObjectPool<Player>(() => new Player(), 10);

        static void Main()
        {
            var players = new List<Player> { Pool.GetObject() };
            while (true)
            {
                Console.WriteLine("Players:");
                Console.WriteLine("####################");
                Console.ForegroundColor = ConsoleColor.Green;
                int s = 0;
                foreach (var player in players)
                {
                    var msg = string.Format("*Player* [{0}]", ++s);
                    if (player.Playing)
                        msg += string.Format(" playing - {0}", player.CurrentTrack.Title);
                    if (player.Paused)
                        msg += string.Format(" paused - {0}", player.CurrentTrack.Title);
                    Console.WriteLine(msg);
                }
                Console.ResetColor();
                Console.WriteLine("####################");
                DisplayMainMenuCommandsInfo();
                var cmd = GetCommand();
                switch (cmd)
                {
                    case "se":
                    case "select":
                        Console.WriteLine("Enter player number:");
                        int playerNumber;
                        if (!int.TryParse(Console.ReadLine(), out playerNumber))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error. Invalid player number.");
                            Console.ResetColor();
                            break;
                        }
                        var selectedPlayer = players[playerNumber - 1];
                        ManagePlayer(selectedPlayer);
                        break;

                    case "ad":
                    case "add":
                        var newPlayer = Pool.GetObject();
                        if (newPlayer == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error. Maximum quantity of players has been achieved.");
                            Console.ResetColor();
                            break;
                        }
                        players.Add(NewPlayer());
                        break;

                    case "ex":
                    case "exit":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Incorrect command.");
                        continue;
                }
            }
        }

        private static void ManagePlayer(Player player)
        {
            while (true)
            {
                DisplayPlayerCommandsInfo();
                var cmd = GetCommand();
                switch (cmd)
                {
                    case "lo":
                    case "load":
                        Console.WriteLine("Enter path to the playlist:");
                        var path = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(path))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid playlist path.");
                            Console.ResetColor();
                            continue;
                        }
                        try
                        {
                            var pl = DataContractFormatter<Playlist>.Load(path);
                            player.LoadPlayList(pl);
                            Console.WriteLine("Playlist was loaded.");
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Playlist loading error!");
                            Console.ResetColor();
                        }
                        break;

                    case "pl":
                    case "play":
                        player.Play();
                        break;

                    case "pa":
                    case "pause":
                        player.Pause();
                        break;

                    case "st":
                    case "stop":
                        player.Stop();
                        break;

                    case "ne":
                    case "next":
                        player.NextTrack();
                        break;

                    case "pr":
                    case "previous":
                        player.PreviousTrack();
                        break;

                    case "in":
                    case "info":
                        DisplayPlayerCommandsInfo();
                        break;

                    case "se":
                    case "select":
                        return;

                    case "ex":
                    case "exit":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error. Incorrect command.");
                        Console.ResetColor();
                        continue;
                }
            }
        }

        private static Player NewPlayer()
        {
            var player = new Player();
            player.TrackPlayingStarter +=
                (sender, eventArgs) => Console.WriteLine("Track {0} started.", eventArgs.EventInfo.Title);
            player.TrackPlayingFinished +=
                (sender, eventArgs) => Console.WriteLine("Track {0} finished.", eventArgs.EventInfo.Title);
            return player;
        }

        private static void DisplayMainMenuCommandsInfo()
        {
            Console.WriteLine();
            Console.WriteLine("################################");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Select [se] - select player;" + Environment.NewLine +
                              "Add [ad] - add player;" + Environment.NewLine +
                              "Exit [ex] - exit.");
            Console.ResetColor();
            Console.WriteLine("################################");
            Console.WriteLine();
        }

        private static void DisplayPlayerCommandsInfo()
        {
            Console.WriteLine();
            Console.WriteLine("################################");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Load [lo] - load playlist;" + Environment.NewLine +
                              "Play [pl] - start playing;" + Environment.NewLine +
                              "Pause [pa] - pause playing;" + Environment.NewLine +
                              "Stop [se] - stop playing;" + Environment.NewLine +
                              "Next [ne] - play next track;" + Environment.NewLine +
                              "Previous [pr] - play previous track;" + Environment.NewLine +
                              "Info [in] - print information about commands;" + Environment.NewLine +
                              "Select [se] - select another player;" + Environment.NewLine +
                              "Exit [ex] - exit.");
            Console.ResetColor();
            Console.WriteLine("################################");
            Console.WriteLine();
        }

        private static string GetCommand()
        {
            Console.WriteLine("Enter command:");
            var cmd = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(cmd))
            {
                Console.WriteLine("Invalid command.");
                return GetCommand();
            }
            cmd = cmd.ToLower();
            return cmd;
        }
    }
}
