using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Web.Application.Categoria;
using MyMovie.Web.Extensions;
using MyMovie.Web.Models.Categoria;
using MyMovie.Web.ViewModel.Categoria;
using Newtonsoft.Json;

namespace MyMovie.Web.Controllers
{
    public class CategoriaController : CustomController
    {
        private readonly ICategoriaApplication _categoriaApplication;

        public CategoriaController(ICategoriaApplication categoriaApplication)
        {
            _categoriaApplication = categoriaApplication;
        }

        public ActionResult Categorias()
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
                        CadastroUsuarioId = item.CadastroUsuarioId,
                        DataCadastro = item.DataCadastro,
                        AlteracaoUsuarioId = item.AlteracaoUsuarioId,
                        DataAlteracao = item.DataAlteracao,
                        Ativo = item.Ativo,
                    });
                }


                return View("_Grid", lstCategoria);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("_Grid");
            }
        }

        public ActionResult Cadastrar()
        {
            return View("_Cadastrar");
        }

        public ActionResult Post([FromForm] CategoriaViewModel categoria)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("_Cadastrar");

                var userSession = HttpContext.Session.GetUsuario();
                if (userSession == null)
                    RedirectToAction("Index", "Login");

                var novaCategoria = new Categoria(
                    categoria.Nome,
                    userSession.UsuarioId,
                    categoria.Ativo
                );

                var categoriaRequest = _categoriaApplication.Post(userSession.Token, novaCategoria);
                if (!categoriaRequest.IsSuccessStatusCode)
                {
                    if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Cadastrar");
                }

                return RedirectToAction("Categorias");
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

                var categoriaRequest = _categoriaApplication.Get(userSession.Token, id);
                if (!categoriaRequest.IsSuccessStatusCode)
                {
                    if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Editar");
                }

                var categoriaResponse = JsonConvert.DeserializeObject<Categoria>(categoriaRequest.Content.ReadAsStringAsync().Result);
                var categoria = new CategoriaViewModel
                {
                    CategoriaId = categoriaResponse.CategoriaId,
                    Nome = categoriaResponse.Nome,
                    Ativo = categoriaResponse.Ativo
                };

                return View("_Editar", categoria);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("_Editar");
            }
        }

        public ActionResult Put([FromForm] CategoriaViewModel categoria)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("_Editar");

                var userSession = HttpContext.Session.GetUsuario();
                if (userSession == null)
                    RedirectToAction("Index", "Login");

                var novaCategoria = new Categoria(
                    categoria.CategoriaId,
                    categoria.Nome,
                    userSession.UsuarioId,
                    categoria.Ativo
                );

                var categoriaRequest = _categoriaApplication.Put(userSession.Token, novaCategoria);
                if (!categoriaRequest.IsSuccessStatusCode)
                {
                    if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Editar");
                }

                return RedirectToAction("Categorias");
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

                var categoriaRequest = _categoriaApplication.Get(userSession.Token, id);
                if (!categoriaRequest.IsSuccessStatusCode)
                {
                    if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    return Error(categoriaRequest.Content.ReadAsStringAsync().Result, "_Detalhes");
                }

                var categoriaResponse = JsonConvert.DeserializeObject<Categoria>(categoriaRequest.Content.ReadAsStringAsync().Result);
                var categoria = new CategoriaViewModel
                {
                    CategoriaId = categoriaResponse.CategoriaId,
                    Nome = categoriaResponse.Nome,
                    CadastroUsuarioId = categoriaResponse.CadastroUsuarioId,
                    DataCadastro = categoriaResponse.DataCadastro,
                    AlteracaoUsuarioId = categoriaResponse.AlteracaoUsuarioId,
                    DataAlteracao = categoriaResponse.DataAlteracao,
                    Ativo = categoriaResponse.Ativo
                };

                return View("_Detalhes", categoria);
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

                var categoriaRequest = _categoriaApplication.Delete(userSession.Token, id);
                if (!categoriaRequest.IsSuccessStatusCode)
                {
                    if (categoriaRequest.StatusCode == HttpStatusCode.Unauthorized)
                        return RedirectToAction("Index", "Login");

                    var errorContent = JsonConvert.DeserializeObject<ErrorContent>(categoriaRequest.Content.ReadAsStringAsync().Result);
                    ModelState.AddModelError("Error", errorContent.GetErrorMessage());

                    var categoriasRequest = _categoriaApplication.Get(userSession.Token);
                    var categoriaResponse = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(categoriasRequest.Content.ReadAsStringAsync().Result);
                    var lstCategoria = new List<CategoriaViewModel>();

                    foreach (var item in categoriaResponse)
                    {
                        lstCategoria.Add(new CategoriaViewModel
                        {
                            CategoriaId = item.CategoriaId,
                            Nome = item.Nome,
                            CadastroUsuarioId = item.CadastroUsuarioId,
                            DataCadastro = item.DataCadastro,
                            AlteracaoUsuarioId = item.AlteracaoUsuarioId,
                            DataAlteracao = item.DataAlteracao,
                            Ativo = item.Ativo,
                        });
                    }

                    return View("_Grid", lstCategoria);
                }

                return RedirectToAction("Categorias");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Ocorreu um erro inesperado");
                return View("_Grid");
            }
        }
    }
}
