using SQLite;

namespace Tuneloop.Data.Models;

/// <summary>Estadísticas de las canciones a lo largo del tiempo</summary>
[Table(AppConstants.Tables.SONG_STATS)]
public sealed class SongStatsEntity : BaseEntity
{
    /// <summary>ID de la canción</summary>
    public int SongId { get; set; }
    /// <summary>Veces que se le ha dado a play (y no es porque estuviese pausada).</summary>
    public uint PlayedTimes { get; set; }
    /// <summary>Tiempo en segundos que se ha escuchado de la canción</summary>
    public uint PlayedLength { get; set; }
    /// <summary>El día que almacena estos stats.</summary>
    public DateTime PlayedDay { get; set; }
}
