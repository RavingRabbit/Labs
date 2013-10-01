using System;
using System.Collections.Generic;

namespace AudioPlayer
{
    class Program
    {
        static void Main()
        {
            var players = new List<Player> { NewPlayer(), NewPlayer(), NewPlayer(), NewPlayer(), NewPlayer() };

            while (true)
            {
                var s = 0;
                foreach (var player in players)
                {
                    var msg = string.Format("*Player* [{0}]", ++s);
                    if (player.Playing)
                        msg += string.Format(" playing - {0}", player.CurrentTrack.Title);
                    Console.WriteLine(msg);
                }
                Console.WriteLine();
                Console.WriteLine("Select [S] - select player;" + Environment.NewLine +
                              "Add [A] - add player;" + Environment.NewLine +
                              "Exit [E] - exit.");
                Console.WriteLine();
                var cmd = GetCommand();
                switch (cmd)
                {
                    case "s":
                    case "select":
                        Console.WriteLine("Players:");
                        var i = 0;
                        foreach (var player in players)
                        {
                            var msg = string.Format("*Player* [{0}]", ++i);
                            if (player.Playing)
                                msg += string.Format(" playing - {0}", player.CurrentTrack.Title);
                            Console.WriteLine(msg);
                        }
                        Console.WriteLine("Enter player number:");
                        var playerNumber = int.Parse(Console.ReadLine()) - 1; //todo: проверить входные данные
                        var selectedPlayer = players[playerNumber];
                        ManagePlayer(selectedPlayer);
                        break;

                    case "a":
                    case "add":
                        players.Add(NewPlayer());
                        break;

                    case "e":
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
                DisplayInfo();
                var cmd = GetCommand();
                switch (cmd)
                {
                    case "l":
                    case "load":
                        Console.WriteLine("Enter path to the playlist:");
                        var path = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(path))
                        {
                            Console.WriteLine("Invalid playlist path.");
                            continue;
                        }
                        try
                        {
                            var pl = DataContractFormatter<Playlist>.Load(path);
                            //todo: обработать исключения
                            player.LoadPlayList(pl);
                            Console.WriteLine("Playlist was loaded.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Playlist loading error!");
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

                    case "s":
                    case "stop":
                        player.Stop();
                        break;

                    case "i":
                    case "info":
                        DisplayInfo();
                        break;

                    case "se":
                    case "select":
                        return;

                    case "e":
                    case "exit":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Incorrect command.");
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

        private static void DisplayInfo()
        {
            Console.WriteLine("Load [L] - load playlist;" + Environment.NewLine +
                              "Play [Pl] - start playing;" + Environment.NewLine +
                              "Pause [Pa] - pause playing;" + Environment.NewLine +
                              "Stop [S] - stop playing;" + Environment.NewLine +
                              "Info [I] - print information about commands;" + Environment.NewLine +
                              "Select [se] - select another player;" + Environment.NewLine +
                              "Exit [E] - exit.");
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
