using SQLite;

namespace Tuneloop.Data.Models;

/// <summary>Directorios raíz en los que se buscarán canciones</summary>
[Table(AppConstants.Tables.LIBRARY_FOLDER)]
public sealed class LibraryFolderEntity : BaseEntity
{
    /// <summary>Nombre de la carpeta</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>Ruta hasta la carpeta</summary>
    public string Path { get; set; } = string.Empty;
    /// <summary>Cuando se escaneó por última vez</summary>
    public DateTime? LastScan { get; set; }
}
