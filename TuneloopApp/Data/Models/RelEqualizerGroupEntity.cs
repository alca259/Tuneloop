using SQLite;

namespace Tuneloop.Data.Models;

/// <summary>Relación entre ecualizador y grupos</summary>
[Table(AppConstants.Tables.RELATED_EQUALIZER_GROUP)]
public sealed class RelEqualizerGroupEntity : BaseEntity
{
    /// <summary>ID del ecualizador</summary>
    public int EqualizerId { get; set; }
    /// <summary>ID del grupo</summary>
    public int EqualizerGroupId { get; set; }
}
