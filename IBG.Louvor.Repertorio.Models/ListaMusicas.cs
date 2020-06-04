using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBG.Louvor.Repertorio.Models
{
    public class ListaMusicas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<Musica> Musicas { get; set; }
        public Equipe Equipe { get; set; }
        public int EquipeId { get; set; }
        public DateTime DataApresentacao { get; set; }
        public string DiaDaSemana { get; set; }
        public bool Ativo { get; set; }

        public ListaMusicas()
        {
            Ativo = true;
            Musicas = new List<Musica>();
        }
    }
}
