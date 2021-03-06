﻿using System.Threading.Tasks;
using System.Windows.Media;
using Hurricane.Model.AudioEngine;
using Hurricane.Model.Music.Playable;

namespace Hurricane.Services.YouTube
{
    public class YouTubeTrack : Streamable
    {
        public string YouTubeVideoId { get; set; }

        public override string Url => $"https://www.youtube.com/watch?v={YouTubeVideoId}";
        public override string ProviderUrl { get; } = "https://www.youtube.com/";
        public override string ProviderName { get; } = "YouTube";
        public override Geometry ProviderIcon => YouTubeService.GetYouTubeVector();

        public override Task<IPlaySource> GetSoundSource()
        {
            return YouTubeExtractor.GetPlaySource(YouTubeVideoId);
        }
    }
}