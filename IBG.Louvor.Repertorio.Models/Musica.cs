using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBG.Louvor.Repertorio.Models
{
    public class Musica
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cantor { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public Musica()
        {
            Ativo = true;
        }
    }
}
