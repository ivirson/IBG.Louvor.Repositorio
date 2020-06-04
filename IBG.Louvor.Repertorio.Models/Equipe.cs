using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBG.Louvor.Repertorio.Models
{
    public class Equipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeAbreviado { get; set; }
        public bool Ativo { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public Equipe()
        {
            Ativo = true;
        }
    }
}
