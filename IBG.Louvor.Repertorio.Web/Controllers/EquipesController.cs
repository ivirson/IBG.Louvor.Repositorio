using IBG.Louvor.Repertorio.Models;
using IBG.Louvor.Repertorio.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IBG.Louvor.Repertorio.Web.Controllers
{
    public class EquipesController : Controller
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
                Session["equipes"] = listEquipes;
                var equipes = (List<Equipe>)Session["equipes"];
                foreach (var item in equipes)
                {
                    item.Usuarios = listUsuarios.Where(u => u.Equipe.Id == item.Id).OrderBy(u => u.Nome).ToList();
                }
                return View(equipes);
            }
            catch (Exception e)
            {
                Utils.SalvaLog(e.Message, e.StackTrace, 0);
                return View(new Equipe());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Equipe equipe)
        {
            try
            {
                var equipes = (List<Equipe>)Session["equipes"];
                if (ModelState.IsValid)
                {
                    equipes.Add(equipe);
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
                var equipes = (List<Equipe>)Session["equipes"];
                var equipe = equipes.FirstOrDefault(e => e.Id == id);
                return View(equipe);
            }
            catch (Exception e)
            {
                Utils.SalvaLog(e.Message, e.StackTrace, 0);
                return View(new Equipe());
            }
        }

        [HttpPost]
        public ActionResult Edit(Equipe equipe)
        {
            try
            {
                var equipes = (List<Equipe>)Session["equipes"];
                if (ModelState.IsValid)
                {
                    var equipeAtual = equipes.FirstOrDefault(e => e.Id == equipe.Id);
                    equipes.Remove(equipeAtual);
                    equipes.Add(equipe);
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
            var equipes = (List<Equipe>)Session["equipes"];
            try
            {
                var equipe = listEquipes.FirstOrDefault(e => e.Id == id);
                equipes.Remove(equipe);
            }
            catch (Exception e)
            {
                Utils.SalvaLog(e.Message, e.StackTrace, 0);
            }
        }
    }
}
