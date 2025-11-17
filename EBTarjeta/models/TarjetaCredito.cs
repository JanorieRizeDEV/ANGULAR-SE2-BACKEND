using System.ComponentModel.DataAnnotations;

namespace EBTarjeta.models
{
    // Modelo que representa una tarjeta de crédito en la base de datos.
    // Las propiedades usan tipos simples; la validación adicional puede añadirse con DataAnnotations.
    public class TarjetaCredito
    {
        // Identificador primario de la tarjeta.
        public int Id { get; set; }

        // Nombre del titular tal como aparece en la tarjeta.
        public required string Titular { get; set; }
        
        // Número de la tarjeta (sin espacios ni separadores).
        public required string NumeroTarjeta { get; set; }

        // Fecha de expiración en formato MM/AA o similar.
        // Está marcada como required; considerar un tipo más específico si se necesita validación de fecha.
        public required string FechaExpiracion { get; set; }
        
        // Código de seguridad CVV; se usa int para almacenamiento y validación previa en la capa de UI.
        public required int CVV { get; set; }
    }
}
