using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBG.Louvor.Repertorio.Models
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Equipe Equipe { get; set; }
        public int EquipeId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {
            Ativo = true;
        }
    }
}
