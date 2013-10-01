using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace AudioPlayer
{
    [Serializable]
    [DataContract(Name = "playlist")]
    public class Playlist : ICollection<Track>
    {
        private const int MaxNameLength = 256;
        [DataMember(Name = "id", Order = 2)]
        private readonly int _id;
        [DataMember(Name = "title", Order = 1)]
        private readonly string _title;
        [DataMember(Name = "tracks", Order = 3)]
        private readonly HashSet<Track> _tracks = new HashSet<Track>();

        public Playlist(string title)
        {
            if (title == null)
                throw new ArgumentNullException("title");
            if (title.Length > MaxNameLength)
                throw new ArgumentOutOfRangeException(string.Format("Name length must be less or equal {0}.", MaxNameLength));
            _title = title;
            unchecked
            {
                _id = title.GetHashCode() ^ DateTime.Now.GetHashCode();
            }
        }

        public string Name
        {
            get { return _title; }
        }

        public int ID
        {
            get { return _id; }
        }

        public TimeSpan Duration
        {
            get { return TimeSpan.FromSeconds(CountTotalDuration()); }
        }

        public int Rating
        {
            get { return CountAverageRating(); }
        }

        public int Count
        {
            get { return _tracks.Count; }
        }

        bool ICollection<Track>.IsReadOnly
        {
            get { return false; }
        }

        private int CountTotalDuration()
        {
            return _tracks.Sum(track => (int)track.Duration.TotalSeconds);
        }

        private int CountAverageRating()
        {
            return (int)_tracks.Average(track => track.Rating);
        }

        public void Add(Track track)
        {
            if (track == null)
                throw new ArgumentNullException("track");
            _tracks.Add(track);
        }

        public bool Remove(Track track)
        {
            return _tracks.Remove(track);
        }

        public void Clear()
        {
            _tracks.Clear();
        }

        public bool Contains(Track item)
        {
            return _tracks.Contains(item);
        }

        public void CopyTo(Track[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("arrayIndex");
            _tracks.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Track> GetEnumerator()
        {
            return _tracks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}