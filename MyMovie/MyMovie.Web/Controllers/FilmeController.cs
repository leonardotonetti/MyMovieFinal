using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyMovie.Web.Application.Categoria;
using MyMovie.Web.Application.Filme;
using MyMovie.Web.Extensions;
using MyMovie.Web.Models.Categoria;
using MyMovie.Web.Models.Filme;
using MyMovie.Web.ViewModel.Categoria;
using MyMovie.Web.ViewModel.Filme;
using Newtonsoft.Json;

namespace MyMovie.Web.Controllers
{
    public class FilmeController : CustomController
    {
        private readonly IFilmeApplication _filmeApplication;
        private readonly ICategoriaApplication _categoriaApplication;

        public FilmeController(IFilmeApplication filmeApplication, ICategoriaApplication categoriaApplication)
        {
            _filmeApplication = filmeApplication;
            _categoriaApplication = categoriaApplication;
        }

        public ActionResult Filmes()
        {
            try
            {
                var userSession = HttpContext.Session.GetUsuario();
                if (userSession == null)
                    RedirectToAction("Index", "Login");

                var filmeRequest = _filmeApplication.Get(userSession.Token);
                if (!filmeRequest.IsSuccessStatusCode)
                {
                    if (filmeRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(filmeRequest.Content.ReadAsStringAsync().Result, "_Grid");
                }

                var filmeResponse = JsonConvert.DeserializeObject<IEnumerable<Filme>>(filmeRequest.Content.ReadAsStringAsync().Result);
                var lstFilme = new List<FilmeViewModel>();

                foreach (var item in filmeResponse)
                {
                    lstFilme.Add(new FilmeViewModel
                    {
                        FilmeId = item.FilmeId,
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        CategoriaId = item.Categoria.CategoriaId,
                        Categoria = new CategoriaViewModel
                        {
                            CategoriaId = item.Categoria.CategoriaId,
                            Nome = item.Categoria.Nome
                        },
                        CadastroUsuarioId = item.CadastroUsuarioId,
                        DataCadastro = item.DataCadastro,
                        AlteracaoUsuarioId = item.AlteracaoUsuarioId,
                        DataAlteracao = item.DataAlteracao,
                        Ativo = item.Ativo
                    });
                }

                return View("_Grid", lstFilme);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("_Grid");
            }
        }

        public ActionResult Cadastrar()
        {
            try
            {
                var userSession = HttpContext.Session.GetUsuario();
                if (userSession == null)
                    RedirectToAction("Index", "Login");

                var categoriaRequest = _categoriaApplication.Get(userSession.Token);
                if (!categoriaRequest.IsSuccessStatusCode)
                {
                    if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Grid");
                }

                var categoriaResponse = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(categoriaRequest.Content.ReadAsStringAsync().Result);
                var lstCategoria = new List<CategoriaViewModel>();

                foreach (var item in categoriaResponse)
                {
                    lstCategoria.Add(new CategoriaViewModel
                    {
                        CategoriaId = item.CategoriaId,
                        Nome = item.Nome,
                    });
                }

                var comboCategoria = new SelectList(lstCategoria, "CategoriaId", "Nome");

                return View("_Cadastrar", new FilmeViewModel{ComboCategoria = comboCategoria });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult Post([FromForm] FilmeViewModel filme)
        {
            try
            {
                var userSession = HttpContext.Session.GetUsuario();
                if (userSession == null)
                    RedirectToAction("Index", "Login");

                if (!ModelState.IsValid)
                {
                    var categoriaRequest = _categoriaApplication.Get(userSession.Token);
                    if (!categoriaRequest.IsSuccessStatusCode)
                    {
                        if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                            return RedirectToAction("Index", "Login");

                        return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Grid");
                    }

                    var categoriaResponse = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(categoriaRequest.Content.ReadAsStringAsync().Result);
                    var lstCategoria = new List<CategoriaViewModel>();

                    foreach (var item in categoriaResponse)
                    {
                        lstCategoria.Add(new CategoriaViewModel
                        {
                            CategoriaId = item.CategoriaId,
                            Nome = item.Nome,
                        });
                    }

                    var comboCategoria = new SelectList(lstCategoria, "CategoriaId", "Nome");

                    return View("_Cadastrar", new FilmeViewModel{ComboCategoria = comboCategoria});
                }

                var novaCategoria = new Filme(
                    filme.Nome,
                    filme.Descricao,
                    filme.CategoriaId,
                    userSession.UsuarioId,
                    filme.Ativo
                );

                var filmeRequest = _filmeApplication.Post(userSession.Token, novaCategoria);
                if (!filmeRequest.IsSuccessStatusCode)
                {
                    if (filmeRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    var errorContent = JsonConvert.DeserializeObject<ErrorContent>(filmeRequest.Content.ReadAsStringAsync().Result);
                    ModelState.AddModelError("Error", errorContent.GetErrorMessage());

                    var categoriaRequest = _categoriaApplication.Get(userSession.Token);
                    if (!categoriaRequest.IsSuccessStatusCode)
                    {
                        if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                            return RedirectToAction("Index", "Login");

                        return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Grid");
                    }

                    var categoriaResponse = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(categoriaRequest.Content.ReadAsStringAsync().Result);
                    var lstCategoria = new List<CategoriaViewModel>();

                    foreach (var item in categoriaResponse)
                    {
                        lstCategoria.Add(new CategoriaViewModel
                        {
                            CategoriaId = item.CategoriaId,
                            Nome = item.Nome,
                        });
                    }

                    var comboCategoria = new SelectList(lstCategoria, "CategoriaId", "Nome");

                    return View("_Cadastrar", new FilmeViewModel{ComboCategoria = comboCategoria});
                }

                return RedirectToAction("Filmes");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("_Cadastrar");
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                var userSession = HttpContext.Session.GetUsuario();
                if (userSession == null)
                    RedirectToAction("Index", "Login");

                var filmeRequest = _filmeApplication.Get(userSession.Token, id);
                if (!filmeRequest.IsSuccessStatusCode)
                {
                    if (filmeRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(filmeRequest.Content.ReadAsStringAsync().Result, "_Editar");
                }

                var categoriaRequest = _categoriaApplication.Get(userSession.Token);
                if (!categoriaRequest.IsSuccessStatusCode)
                {
                    if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Grid");
                }

                var categoriaResponse = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(categoriaRequest.Content.ReadAsStringAsync().Result);
                var lstCategoria = new List<CategoriaViewModel>();

                foreach (var item in categoriaResponse)
                {
                    lstCategoria.Add(new CategoriaViewModel
                    {
                        CategoriaId = item.CategoriaId,
                        Nome = item.Nome,
                    });
                }

                var filmeResponse = JsonConvert.DeserializeObject<Filme>(filmeRequest.Content.ReadAsStringAsync().Result);
                var filme = new FilmeViewModel
                {
                    FilmeId = filmeResponse.FilmeId,
                    Nome = filmeResponse.Nome,
                    Descricao = filmeResponse.Descricao,
                    CategoriaId = filmeResponse.Categoria.CategoriaId,
                    Categoria = new CategoriaViewModel
                    {
                        CategoriaId = filmeResponse.Categoria.CategoriaId,
                        Nome = filmeResponse.Categoria.Nome
                    },
                    CadastroUsuarioId = filmeResponse.CadastroUsuarioId,
                    DataCadastro = filmeResponse.DataCadastro,
                    AlteracaoUsuarioId = filmeResponse.AlteracaoUsuarioId,
                    DataAlteracao = filmeResponse.DataAlteracao,
                    Ativo = filmeResponse.Ativo,
                    ComboCategoria = new SelectList(lstCategoria, "CategoriaId", "Nome", filmeResponse.Categoria.CategoriaId)
                };

                return View("_Editar", filme);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("_Editar");
            }
        }

        public ActionResult Put([FromForm] FilmeViewModel filme)
        {
            try
            {
                var userSession = HttpContext.Session.GetUsuario();
                if (userSession == null)
                    RedirectToAction("Index", "Login");

                if (!ModelState.IsValid)
                {
                    var categoriaRequest = _categoriaApplication.Get(userSession.Token);
                    if (!categoriaRequest.IsSuccessStatusCode)
                    {
                        if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                            return RedirectToAction("Index", "Login");

                        return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Grid");
                    }

                    var categoriaResponse = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(categoriaRequest.Content.ReadAsStringAsync().Result);
                    var lstCategoria = new List<CategoriaViewModel>();

                    foreach (var item in categoriaResponse)
                    {
                        lstCategoria.Add(new CategoriaViewModel
                        {
                            CategoriaId = item.CategoriaId,
                            Nome = item.Nome,
                        });
                    }

                    var comboCategoria = new SelectList(lstCategoria, "CategoriaId", "Nome");

                    return View("_Editar", new FilmeViewModel{ComboCategoria = comboCategoria});
                }

                var novaCategoria = new Filme(
                    filme.FilmeId,
                    filme.Nome,
                    filme.Descricao,
                    filme.CategoriaId,
                    userSession.UsuarioId,
                    filme.Ativo
                );

                var filmeRequest = _filmeApplication.Put(userSession.Token, novaCategoria);
                if (!filmeRequest.IsSuccessStatusCode)
                {
                    if (filmeRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    var errorContent = JsonConvert.DeserializeObject<ErrorContent>(filmeRequest.Content.ReadAsStringAsync().Result);
                    ModelState.AddModelError("Error", errorContent.GetErrorMessage());

                    var categoriaRequest = _categoriaApplication.Get(userSession.Token);
                    if (!categoriaRequest.IsSuccessStatusCode)
                    {
                        if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                            return RedirectToAction("Index", "Login");

                        return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Grid");
                    }

                    var categoriaResponse = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(categoriaRequest.Content.ReadAsStringAsync().Result);
                    var lstCategoria = new List<CategoriaViewModel>();

                    foreach (var item in categoriaResponse)
                    {
                        lstCategoria.Add(new CategoriaViewModel
                        {
                            CategoriaId = item.CategoriaId,
                            Nome = item.Nome,
                        });
                    }

                    var comboCategoria = new SelectList(lstCategoria, "CategoriaId", "Nome");

                    return View("_Editar", new FilmeViewModel { ComboCategoria = comboCategoria });
                }

                return RedirectToAction("Filmes");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("_Editar");
            }
        }

        public ActionResult Detalhes(int id)
        {
            try
            {
                var userSession = HttpContext.Session.GetUsuario();
                if (userSession == null)
                    RedirectToAction("Index", "Login");

                var filmeRequest = _filmeApplication.Get(userSession.Token, id);
                if (!filmeRequest.IsSuccessStatusCode)
                {
                    if (filmeRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(filmeRequest.Content.ReadAsStringAsync().Result, "_Detalhes");
                }

                var filmeResponse = JsonConvert.DeserializeObject<Filme>(filmeRequest.Content.ReadAsStringAsync().Result);
                var filme = new FilmeViewModel
                {
                    FilmeId = filmeResponse.FilmeId,
                    Nome = filmeResponse.Nome,
                    Descricao = filmeResponse.Descricao,
                    Categoria = new CategoriaViewModel
                    {
                        CategoriaId = filmeResponse.Categoria.CategoriaId,
                        Nome = filmeResponse.Categoria.Nome
                    },
                    CadastroUsuarioId = filmeResponse.CadastroUsuarioId,
                    DataCadastro = filmeResponse.DataCadastro,
                    AlteracaoUsuarioId = filmeResponse.AlteracaoUsuarioId,
                    DataAlteracao = filmeResponse.DataAlteracao,
                    Ativo = filmeResponse.Ativo,
                };

                return View("_Detalhes", filme);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("_Detalhes");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var userSession = HttpContext.Session.GetUsuario();
                if (userSession == null)
                    RedirectToAction("Index", "Login");

                var filmeRequest = _filmeApplication.Delete(userSession.Token, id);
                if (!filmeRequest.IsSuccessStatusCode)
                {
                    if (filmeRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(filmeRequest.Content.ReadAsStringAsync().Result, "_Grid");
                }

                return RedirectToAction("Filmes");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("_Grid");
            }
        }
    }
}
