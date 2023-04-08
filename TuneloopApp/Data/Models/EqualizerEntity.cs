using SQLite;

namespace Tuneloop.Data.Models;

/// <summary>Datos del ecualizador</summary>
[Table(AppConstants.Tables.EQUALIZER)]
public sealed class EqualizerEntity : BaseEntity
{
    /// <summary>Si está habilitado</summary>
    public bool Enabled { get; set; } = false;
    /// <summary>Si el control se realiza automáticamente en función del género de la canción o si es personalizado por el usuario.</summary>
    public bool Automatic { get; set; } = true;
    /// <summary>Volumen del sistema multimedia. Valores de 0-100</summary>
    public uint Volume { get; set; } = 100;
    /// <summary>
    /// <para>Compensación de altavoz para la salida de estéreo.</para>
    /// <para>Los valores positivos hasta 1.0, enviará más volumen por el altavoz derecho.</para>
    /// <para>Los valores negativos hasta -1.0, enviará más volumen por el altavoz izquierdo.</para>
    /// </summary>
    public double VolumeCompensation { get; set; } = 0.0;
}
