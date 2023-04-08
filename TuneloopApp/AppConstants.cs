using SQLite;

namespace Tuneloop;

public static class AppConstants
{
    public struct Database
    {
        public const string FILENAME = "TuneLoop_v1.db3";
        public const SQLiteOpenFlags OPEN_FLAGS =
            // open the database in read/write mode
            SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLiteOpenFlags.SharedCache;

        public const CreateFlags CREATE_FLAGS =
            CreateFlags.AllImplicit | CreateFlags.AutoIncPK;

        public static string FullPath => Path.Combine(FileSystem.AppDataDirectory, FILENAME);
    }

    public struct Tables
    {
        public const string EQUALIZER = "Equalizer";
        public const string EQUALIZER_GROUP = "EqualizerGroup";
        public const string LAST_PLAYED = "LastPlayed";
        public const string LIBRARY_FOLDER = "LibraryFolder";
        public const string PLAYLIST = "Playlist";
        public const string RELATED_EQUALIZER_GROUP = "RelEqualizerGroup";
        public const string RELATED_PLAYLIST_SONG = "RelPlaylistSong";
        public const string SONG = "Song";
        public const string SONG_STATS = "SongStats";
    }

    public struct EqualizerGroupCodes
    {
        /// <summary>Subgraves</summary>
        public const string LOWEST = "Lowest";
        /// <summary>Graves</summary>
        public const string LOW = "Low";
        /// <summary>Medios</summary>
        public const string MIDDLE = "Middle";
        /// <summary>Medios-agudos</summary>
        public const string MIDDLE_HIGH = "MiddleHigh";
        /// <summary>Agudos</summary>
        public const string HIGH = "High";
    }
}
