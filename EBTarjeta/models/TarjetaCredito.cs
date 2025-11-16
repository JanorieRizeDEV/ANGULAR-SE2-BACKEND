using System.ComponentModel.DataAnnotations;

namespace EBTarjeta.models
{
    public class TarjetaCredito
    {
        public int Id { get; set; }

      
        public required string Titular { get; set; }
        
        public required string NumeroTarjeta { get; set; }

        // Corregido: FechaExpiracion (antes FechaExperiacion)
        public required string FechaExpiracion { get; set; }
        
        public required int CVV { get; set; }
    }
}
