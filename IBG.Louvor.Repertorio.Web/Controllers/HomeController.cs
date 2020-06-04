using IBG.Louvor.Repertorio.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBG.Louvor.Repertorio.Web.Controllers
{
    public class HomeController : Controller
    {
        public static List<Equipe> listEquipes = new List<Equipe>
        {
            new Equipe
            {
                Id = 1,
                Nome = "Equipe Washington",
                NomeAbreviado = "EQ1"
            },
            new Equipe
            {
                Id = 2,
                Nome = "Equipe Ítalo",
                NomeAbreviado = "EQ2"
            }
        };

        public static List<Usuario> listUsuarios = new List<Usuario>
        {
            new Usuario
            {
                Id = 1,
                Nome = "Washington Junior",
                DataCadastro = DateTime.Now,
                Login = "junior",
                Senha = "123456",
                Equipe = listEquipes.FirstOrDefault(e => e.Id == 1)
            },
            new Usuario
            {
                Id = 2,
                Nome = "Ítalo Eider",
                DataCadastro = DateTime.Now,
                Login = "italo",
                Senha = "123456",
                Equipe = listEquipes.FirstOrDefault(e => e.Id == 2)
            },
            new Usuario
            {
                Id = 3,
                Nome = "Lorena Silva",
                DataCadastro = DateTime.Now,
                Login = "lorena",
                Senha = "123456",
                Equipe = listEquipes.FirstOrDefault(e => e.Id == 1)
            },
            new Usuario
            {
                Id = 4,
                Nome = "Isabela Abreu",
                DataCadastro = DateTime.Now,
                Login = "bela",
                Senha = "123456",
                Equipe = listEquipes.FirstOrDefault(e => e.Id == 2)
            }
        };

        public static List<Musica> listMusicas = new List<Musica>
        {
            new Musica
            {
                Id = 1,
                Nome = "Não tenhas sobre ti",
                Cantor = "Paulo César Baruk",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 2,
                Nome = "Nada além do sangue",
                Cantor = "Fernandinho",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 3,
                Nome = "Até que Ele venha",
                Cantor = "Missões Mundiais",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 4,
                Nome = "Ousado amor",
                Cantor = "Paulo César Baruk",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 5,
                Nome = "Quebrantado",
                Cantor = "Vineyard",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 6,
                Nome = "Aleluia",
                Cantor = "Aline Barros",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 7,
                Nome = "Consagração",
                Cantor = "Aline Barros",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 8,
                Nome = "Canção do Apocalipse",
                Cantor = "Gabriela Rocha",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 9,
                Nome = "Grande é o Senhor",
                Cantor = "Adhemar de Campos",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 10,
                Nome = "Eis-me aqui",
                Cantor = "Luciano Claw",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 11,
                Nome = "Vim para adorar-Te",
                Cantor = "Corinho",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Musica
            {
                Id = 12,
                Nome = "Digno é o Senhor",
                Cantor = "Aline Barros",
                DataInclusao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            }
        };

        public static List<MusicaEquipe> listMusicasEquipes = new List<MusicaEquipe>
        {
            new MusicaEquipe
            {
                Id = 1,
                EquipeId = 1,
                MusicaId = 1,
                Tom = "C"
            },
            new MusicaEquipe
            {
                Id = 1,
                EquipeId = 2,
                MusicaId = 2,
                Tom = "C"
            },
            new MusicaEquipe
            {
                Id = 1,
                EquipeId = 3,
                MusicaId = 1,
                Tom = "Bb"
            },
            new MusicaEquipe
            {
                Id = 1,
                EquipeId = 3,
                MusicaId = 2,
                Tom = "Bb"
            }
        };

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            var musicas = (List<Musica>)Session["musicas"];
            if (musicas != null)
            {
                ViewBag.UltimasMusicas = musicas.OrderByDescending(m => m.DataInclusao).Where(m => m.DataInclusao >= DateTime.Now.AddDays(-1)).ToList();
            }
            else
            {
                ViewBag.UltimasMusicas = new List<Musica>();
            }
            
            return View();
        }
    }
}