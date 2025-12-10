using System;
using System.Collections.Generic;
using Telhai.CS.CsharpCourse._05_WpfLinq.Models;

namespace Telhai.CS.CsharpCourse._05_WpfLinq
{
    public class RandomSongService : ISongService
    {
        // Singleton instance
        private static readonly RandomSongService _instance = new RandomSongService();
        public static RandomSongService Instance => _instance;

        // single Random for the service
        private readonly Random rnd = new Random();

        // private ctor
        private RandomSongService() { }

        // 5–10 artists
        private static readonly string[] Artists =
        {
            "Ed Sheeran",
            "Taylor Swift",
            "Justin Bieber",
            "Zayn",
            "Shawn Mendes",
            "One Direction",
            "Adele"
        };

        // 5–10 song titles
        private static readonly string[] Titles =
        {
            "Perfect",
            "Blank Space",
            "Peaches",
            "Dusk Till Dawn",
            "Stitches",
            "Bad Habits",
            "Love Yourself",
            "Lover",
            "In My Blood",
            "Intentions"
        };

        public List<Song> GenerateSongs(int count)
        {
            var list = new List<Song>();

            for (int i = 0; i < count; i++)
            {
                string artist = Artists[rnd.Next(Artists.Length)];
                string title = Titles[rnd.Next(Titles.Length)];
                double duration = Math.Round(rnd.NextDouble() * (10.0 - 2.0) + 2.0, 1); // 2.0–10.0

                list.Add(new Song
                {
                    Id = Guid.NewGuid(),
                    Artist = artist,
                    Title = title,
                    Duration = duration
                });
            }

            return list;
        }
    }
}
