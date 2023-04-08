using SQLite;

namespace Tuneloop.Data.Models;

/// <summary>Relación entre playlist y canción</summary>
[Table(AppConstants.Tables.RELATED_PLAYLIST_SONG)]
public sealed class RelPlaylistSongEntity : BaseEntity
{
    /// <summary>ID de la playlist</summary>
    public int PlaylistId { get; set; }
    /// <summary>ID de la canción</summary>
    public int SongId { get; set; }
}
