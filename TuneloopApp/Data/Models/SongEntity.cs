using SQLite;

namespace Tuneloop.Data.Models;

/// <summary>Canciones</summary>
[Table(AppConstants.Tables.SONG)]
public sealed class SongEntity : BaseEntity
{
    /// <summary>Nombre de la canción</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>Ruta en disco hasta el fichero</summary>
    public string Path { get; set; } = string.Empty;
    /// <summary>Longitud de la canción (en segundos)</summary>
    public uint Length { get; set; } = 0;
    /// <summary>Fecha que se añadió</summary>
    public DateTime Added { get; set; }
    /// <summary>Género musical</summary>
    public string? Genre { get; set; }
    /// <summary>Albúm o disco</summary>
    public string? Album { get; set; }
    /// <summary>Artista o compositor</summary>
    public string? Artist { get; set; }
}
