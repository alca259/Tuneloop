using SQLite;

namespace Tuneloop.Data.Models;

/// <summary>Listado de canciones personalizado</summary>
[Table(AppConstants.Tables.PLAYLIST)]
public sealed class PlaylistEntity : BaseEntity
{
    /// <summary>Nombre</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>Fecha de creación</summary>
    public DateTime Created { get; set; }
    /// <summary>Última fecha de actualización</summary>
    public DateTime? LastUpdated { get; set; }
    /// <summary>Cantidad de canciones que contiene</summary>
    public uint SongsCount { get; set; }
    /// <summary>Tiempo total en segundos de la duración de las canciones contenidas</summary>
    public uint SongLength { get; set; }
}
