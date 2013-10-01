using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace AudioPlayer
{
    [Serializable]
    [DataContract(Name = "track")]
    public class Track : IEquatable<Track>
    {
        private const int DefaultRating = 5;
        private const int MaxTitleLength = 256;
        private const int MaxSingerLength = 256;
        [DataMember(Name = "location", Order = 0)]
        private readonly string _location;
        [DataMember(Name = "title", Order = 1)]
        private readonly string _title;
        [DataMember(Name = "singer", Order = 2)]
        private readonly string _singer;
        [DataMember(Name = "duration", Order = 3)]
        private readonly int _duration;
        [DataMember(Name = "id", Order = 7)]
        private readonly int _id;
        [DataMember(Name = "rating", Order = 4)]
        private int _rating = DefaultRating;

        public Track(FileSystemInfo trachLocation, string title, string singer, int durationSeconds)
            : this(trachLocation, title, singer, TimeSpan.FromSeconds(durationSeconds))
        {
        }

        public Track(FileSystemInfo trackLocation, string title, string singer, TimeSpan duration)
        {
            /* arguments validation */
            if (trackLocation == null)
                throw new ArgumentNullException("trackLocation");
            if (title == null)
                throw new ArgumentNullException("title");
            if (title.Length > MaxTitleLength)
                throw new ArgumentException(string.Format("Title length must be less or equal {0}.", MaxTitleLength));
            if (singer == null)
                throw new ArgumentNullException("title");
            if (singer.Length > MaxSingerLength)
                throw new ArgumentException(string.Format("Singer length must be less or equal {0}.", MaxSingerLength));
            if (duration == null)
                throw new ArgumentNullException("duration");
            if (duration.Ticks == 0)
                throw new ArgumentException("Track duration must be greater than zero.");
            
            _location = trackLocation.FullName;
            _title = title;
            _singer = singer;
            _duration = (int) duration.TotalSeconds;
            unchecked
            {
                _id = _title.GetHashCode() ^ singer.GetHashCode() ^ _duration.GetHashCode();
            }
            Album = "unknown";
            Genre = "unknown";
        }

        
        public string Location
        {
            get { return _location; }
        }

        public string Title
        {
            get { return _title; }
        }

        public string Singer
        {
            get { return _singer; }
        }

        public TimeSpan Duration
        {
            get { return TimeSpan.FromSeconds(_duration); }
        }

        public int ID
        {
            get { return _id; }
        }

        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("Rating must be from 0 to 10.");
                _rating = value;
            }
        }

        [DataMember(Name = "album", Order = 5)]
        public string Album { get; set; }

        [DataMember(Name = "genre", Order = 6)]
        public string Genre { get; set; }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals((Track) other);
        }

        public bool Equals(Track other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _id == other._id;
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }
}