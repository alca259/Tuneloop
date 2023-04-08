using SQLite;

namespace Tuneloop.Data.Models;

/// <summary>Rangos para controlar potencias de volumen</summary>
[Table(AppConstants.Tables.EQUALIZER_GROUP)]
public sealed class EqualizerGroupEntity : BaseEntity
{
    /// <summary>Código único</summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>Rango mínimo. Ej: 20Hz</summary>
    public uint MinRange { get; set; }
    /// <summary>Rango máximo. Ej: 80Hz</summary>
    public uint MaxRange { get; set; }
    /// <summary>Valor a configurar. Ej: 60Hz</summary>
    public uint Value { get; set; }
    /// <summary>Valores entre -30db y 30db.</summary>
    public int Volume { get; set; }
}
