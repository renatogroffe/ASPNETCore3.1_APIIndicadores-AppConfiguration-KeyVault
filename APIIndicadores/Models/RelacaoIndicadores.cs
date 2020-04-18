using System;

namespace APIIndicadores.Models
{
    public class RelacaoIndicadores
    {
        private static Guid _IdAplicacao = Guid.NewGuid();

        public Guid IdAplicacao { get => _IdAplicacao; }
        public double SalarioMinimo { get; set; }
        public double SELIC { get; set; }
        public double IPCA { get; set; }
    }
}