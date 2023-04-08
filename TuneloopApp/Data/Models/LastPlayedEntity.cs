using SQLite;

namespace Tuneloop.Data.Models;

/// <summary>Última reproducción que se ha quedado a medias, bien canción o bien playlist.</summary>
[Table(AppConstants.Tables.LAST_PLAYED)]
public sealed class LastPlayedEntity : BaseEntity
{
    /// <summary>ID de la canción que estaba sonando por última vez.</summary>
    public int SongId { get; set; }
    /// <summary>Momento en el que se detuvo la música. (en segundos)</summary>
    public uint LastLength { get; set; }
    /// <summary>Si se estaba reproduciendo una playlist, guardaremos el Id</summary>
    public int? PlaylistId { get; set; }
}
