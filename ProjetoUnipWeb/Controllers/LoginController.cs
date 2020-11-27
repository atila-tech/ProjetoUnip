using ProjetoUnipWeb.Domain.User;
using ProjetoUnipWeb.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoUnipWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            DestruirCache();
            return View();
        }

    private void DestruirCache()
    {
        try
        {
            Cache cache = new Cache();
            FormsAuthentication.SignOut();
            if (cache["DadosUsuario"] != null)
            {
                cache.Remove("DadosUsuario");
                //cache["DadosUsuario"] = null;
            }
                    
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
        
    }

    private void SalvarEmCache(Usuario user)
    {
        try
        {
            //Instancio a classe Pessoa, passo as propriedades dela e as atribuo os valores aos textboxes
            //Pessoa objPessoa = new Pessoa();
            //objPessoa.Nome = txtNome.Text;
            //objPessoa.Cidade = txtCidade.Text;
            //Crio o Cache com o nome DadosPessoa, que recebe o objeto instanciado da classe Pessoa
            Cache cache = new Cache();
            cache["DadosUsuario"] = user;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }



        [AllowAnonymous]
        public void Sair()
        {
            if (HttpContext.Session != null)
            {
                HttpContext.Session.Clear();
            }

            //limpa o cache
            //HttpContext.Cache.Remove("countNewMessages");

            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();

        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult Login(AccountViewModel u)
        {
            int retorno = -1;
            string mensagem = string.Empty;
            string url = string.Empty;
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                if (string.IsNullOrEmpty(u.Login))
                {
                    mensagem = "Digite um usuário.";
                    return Json(new { ret = retorno, msg = mensagem, urlRedirection = url });
                }

                if (string.IsNullOrEmpty(u.Senha))
                {
                    mensagem = "Digite uma senha.";
                    return Json(new { ret = retorno, msg = mensagem, urlRedirection = url });
                }

                RestClient restClient = new RestClient(string.Format("http://localhost:5000/api/Usuario/{0}/{1}", u.Login, u.Senha));
                RestRequest restRequest = new RestRequest(Method.GET);

                IRestResponse restResponse = restClient.Execute(restRequest);

                if (restResponse.StatusCode <= 0)
                {
                    mensagem = "Desculpe! Houve um problema de conexão.";
                    return Json(new { ret = retorno, msg = mensagem, urlRedirection = url });
                }

                if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    mensagem = "Usuário ou senha inválidos.";
                    return Json(new { ret = retorno, msg = mensagem, urlRedirection = url });
                }
                else
                {
                    ProjetoUnipWeb.Domain.User.Usuario apiUsuario = new JsonDeserializer().Deserialize<ProjetoUnipWeb.Domain.User.Usuario>(restResponse);
                    //Session["usuarioLogadoID"] = apiUsuario.Id;
                    //Session["nomeUsuarioLogado"] = apiUsuario.Login;
                    //Cache cache = new Cache();
                    //cache["DadosUsuario"] = apiUsuario;
                    SalvarEmCache(apiUsuario);
                    retorno = 1;
                    FormsAuthentication.SetAuthCookie(apiUsuario.Id.ToString(CultureInfo.InvariantCulture), false);
                    if (apiUsuario.PerfilId == 1)
                    {
                        url = Url.Action("Index", "Index", new { Area = "Medico" });
                        return Json(new { ret = retorno, msg = mensagem, urlRedirection = url });
                    }
                    else if (apiUsuario.PerfilId == 2)
                    {
                        url = Url.Action("Index", "Index", new { Area = "Paciente" });
                        return Json(new { ret = retorno, msg = mensagem, urlRedirection = url });
                    }
                    else if (apiUsuario.PerfilId == 3)
                    {
                        url = Url.Action("Index", "Index", new { Area = "Funcionario" });
                        return Json(new { ret = retorno, msg = mensagem, urlRedirection = url });
                    }
                    else
                    {
                        retorno = -1;
                        mensagem = "Usuário sem permissão de acesso!";
                        return Json(new { ret = retorno, msg = mensagem, urlRedirection = url });
                    }
                    
                }
            }
            return Json(new { ret = retorno, msg = mensagem, urlRedirection = url });
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
