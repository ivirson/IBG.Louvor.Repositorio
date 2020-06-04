using IBG.Louvor.Repertorio.Models;
using IBG.Louvor.Repertorio.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBG.Louvor.Repertorio.Web.Controllers
{
    public class MusicasController : Controller
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

        public ActionResult Index()
        {
            try
            {
                Session["musicas"] = listMusicas;
                var musicas = (List<Musica>)Session["musicas"];
                return View(musicas.OrderBy(m => m.Nome));
            }
            catch (Exception e)
            {
                Utils.SalvaLog(e.Message, e.StackTrace, 0);
                return View(new Equipe());
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var musicas = (List<Musica>)Session["musicas"];
                var musica = musicas.FirstOrDefault(m => m.Id == id);
                return View(musica);
            }
            catch (Exception e)
            {
                Utils.SalvaLog(e.Message, e.StackTrace, 0);
                return View(new Musica());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Musica musica)
        {
            try
            {
                var musicas = (List<Musica>)Session["musicas"];
                if (ModelState.IsValid)
                {
                    musicas.Add(musica);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Utils.SalvaLog(e.Message, e.StackTrace, 0);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var musicas = (List<Musica>)Session["musicas"];
                var musica = musicas.FirstOrDefault(m => m.Id == id);
                return View(musica);
            }
            catch (Exception e)
            {
                Utils.SalvaLog(e.Message, e.StackTrace, 0);
                return View(new Musica());
            }
        }

        [HttpPost]
        public ActionResult Edit(Musica musica)
        {
            try
            {
                var musicas = (List<Musica>)Session["musicas"];
                if (ModelState.IsValid)
                {
                    var musicaAtual = musicas.FirstOrDefault(m => m.Id == musica.Id);
                    musicas.Remove(musicaAtual);
                    musicas.Add(musica);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Utils.SalvaLog(e.Message, e.StackTrace, 0);
                return View();
            }
        }

        [HttpPost]
        public void Delete(int id)
        {
            try
            {
                var musicas = (List<Musica>)Session["musicas"];
                var musica = musicas.FirstOrDefault(m => m.Id == id);
                musicas.Remove(musica);
            }
            catch (Exception e)
            {
                Utils.SalvaLog(e.Message, e.StackTrace, 0);
            }
        }
    }
}
