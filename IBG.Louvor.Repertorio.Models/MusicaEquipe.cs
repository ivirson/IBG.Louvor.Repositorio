using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBG.Louvor.Repertorio.Models
{
    public class MusicaEquipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Musica Musica { get; set; }
        public int MusicaId { get; set; }
        public Equipe Equipe { get; set; }
        public int EquipeId { get; set; }
        public string Tom { get; set; }
    }
}
