﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Hurricane.Model.Music.Imagment;

namespace Hurricane.Model.Music.TrackProperties
{
    /// <summary>
    /// Provides information about an artist
    /// </summary>
    [Serializable]
    public class Artist : PropertyChangedBase
    {
        private string _biography;
        private List<Artist> _similarArtists;
        private bool _providesAdvancedInfo;
        private List<TopTrack> _topTracks;

        /// <summary>
        /// Initializes a new instance of <see cref="Artist"/>
        /// </summary>
        /// <param name="name">The name of the artist</param>
        public Artist(string name)
        {
            Name = name;
            Guid = Guid.NewGuid();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Artist"/>
        /// </summary>
        public Artist()
        {
        }

        /// <summary>
        /// The name of the artist
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// The <see href="https://musicbrainz.org/doc/MusicBrainz_Identifier">MusicBrainz Identifier</see>
        /// </summary>
        [XmlAttribute]
        public string MusicBrainzId { get; set; }

        /// <summary>
        /// The <see href="http://wwww.last.fm/">Last.fm</see> url
        /// </summary>
        [XmlAttribute]
        public string Url { get; set; }

        /// <summary>
        /// The id of the artist (set by the program)
        /// </summary>
        [XmlIgnore]
        public Guid Guid { get; set; }

        /// <summary>
        /// The small sized image of the artist (34x34px)
        /// </summary>
        public ImageProvider SmallImage { get; set; }

        /// <summary>
        /// The medium sized image of the artist (~64x64px)
        /// </summary>
        public ImageProvider MediumImage { get; set; }

        /// <summary>
        /// The really large image of the artist (~500x500px)
        /// </summary>
        public ImageProvider LargeImage { get; set; }

        /// <summary>
        /// Similar artists
        /// </summary>
        [XmlIgnore]
        public List<Artist> SimilarArtists
        {
            get { return _similarArtists; }
            set { SetProperty(value, ref _similarArtists); }
        }

        /// <summary>
        /// A short biography (max. 300 chars)
        /// </summary>
        [XmlIgnore]
        public string Biography
        {
            get { return _biography; }
            set { SetProperty(value, ref _biography); }
        }

        /// <summary>
        /// Returns if the properties <see cref="Biography"/>, <see cref="TopTracks"/> and <see cref="SimilarArtists"/> are set
        /// </summary>
        [XmlIgnore]
        public bool ProvidesAdvancedInfo
        {
            get { return _providesAdvancedInfo; }
            set { SetProperty(value, ref _providesAdvancedInfo); }
        }

        /// <summary>
        /// Top tracks of the artist
        /// </summary>
        [XmlIgnore]
        public List<TopTrack> TopTracks
        {
            get { return _topTracks; }
            set { SetProperty(value, ref _topTracks); }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}