using Newtonsoft.Json;
using ProjetoUnipWeb.Models.Cadastros;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace ProjetoUnipWeb.Areas.Funcionario.Controllers
{
    public class AdministradorController : Controller
    {
        [HttpPost]
        public JsonResult SalvarFuncionario(FuncionarioViewModel u)
        {
            
            int retorno = -1;
            string mensagem = "";
            u.Pessoa.Usuario.PerfilId = 3; // funcionario
            
            //u.Pessoa.Usuario.Ativo = true;
            //u.CargoId = 1; // Atendente

            if (u.Pessoa.Usuario.ConfirmacaoSenha != u.Pessoa.Usuario.Senha)
            {
                mensagem = "Confirmação de Senha incorreta!";
                return Json(new { ret = retorno, msg = mensagem });
            }
            u.Pessoa.Usuario.ConfirmacaoSenha = null;
            //u.Pessoa.DataCriacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            u.Pessoa.DataCriacao = DateTime.Now;
            u.Pessoa.DataNascimento = u.Pessoa.DataNascimento.ToString().Substring(6,4) + "-" + u.Pessoa.DataNascimento.ToString().Substring(3, 2) + "-" + u.Pessoa.DataNascimento.ToString().Substring(0, 2) + "T00:00:00";
            u.Salario = string.Format("{0:0.00}", decimal.Parse(u.Salario)).Replace(",",".");

            RestClient restClient = new RestClient(string.Format("http://localhost:5000/api/Funcionario"));
            RestRequest restRequest = new RestRequest(Method.POST);

            //var json = JsonConvert.SerializeObject(u);

            var json = JsonConvert.SerializeObject(u,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                                
                            });
            json = json.Replace(string.Format(@"""Id"":0,"), "").Replace(string.Format(@"""UsuarioId"":0,"), "");

            restRequest.AddParameter("text/json", json, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode <= 0)
            {
                mensagem = "Desculpe! Houve um problema de conexão.";
                return Json(new { ret = retorno, msg = mensagem });
            }

            if (restResponse.StatusCode != System.Net.HttpStatusCode.Created)
            {
                mensagem = "Ocorreu um problema! Funcionário não cadastrado!";
                return Json(new { ret = retorno, msg = mensagem });
            }
            else
            {
                retorno = 1;
                return Json(new { ret = retorno, msg = "Funcionário Cadastrado com sucesso!" });
            }


                //return Json(new { ret = retorno, msg = "" }); 
        }

        [HttpPut]
        public JsonResult EditarFuncionario(FuncionarioViewModel u)
        {

            int retorno = -1;
            string mensagem = "";
            u.Pessoa.Usuario.PerfilId = 3; // funcionario

            //u.Pessoa.Usuario.Ativo = true;
            //u.CargoId = 1; // Atendente

            if (u.Pessoa.Usuario.ConfirmacaoSenha != u.Pessoa.Usuario.Senha)
            {
                mensagem = "Confirmação de Senha incorreta!";
                return Json(new { ret = retorno, msg = mensagem });
            }

            DateTime valor;
            var convertido = DateTime
                .TryParseExact(u.Pessoa.DataNascimento,
                                "dd/MM/yyyy",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None,
                                out valor);
            if (!convertido)
            {
                mensagem = "Data de Nascimento com formato incorreto!";
                return Json(new { ret = retorno, msg = mensagem });
            }

            u.Pessoa.Usuario.ConfirmacaoSenha = null;
            //u.Pessoa.DataCriacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //u.Pessoa.DataCriacao = DateTime.Now;
            u.Pessoa.DataNascimento = u.Pessoa.DataNascimento.ToString().Substring(6, 4) + "-" + u.Pessoa.DataNascimento.ToString().Substring(3, 2) + "-" + u.Pessoa.DataNascimento.ToString().Substring(0, 2) + "T00:00:00";
            u.Salario = string.Format("{0:0.00}", decimal.Parse(u.Salario)).Replace(",", ".");

            RestClient restClient = new RestClient(string.Format("http://localhost:5000/api/Funcionario/{0}", u.Id));
            RestRequest restRequest = new RestRequest(Method.PUT);

            //var json = JsonConvert.SerializeObject(u);

            var json = JsonConvert.SerializeObject(u,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,

                            });
            json = json.Replace(string.Format(@"""Id"":0,"), "").Replace(string.Format(@"""UsuarioId"":0,"), "");

            restRequest.AddParameter("text/json", json, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode <= 0)
            {
                mensagem = "Desculpe! Houve um problema de conexão.";
                return Json(new { ret = retorno, msg = mensagem });
            }

            if (restResponse.StatusCode != System.Net.HttpStatusCode.Created)
            {
                mensagem = "Ocorreu um problema! Funcionário não cadastrado!";
                return Json(new { ret = retorno, msg = mensagem });
            }
            else
            {
                retorno = 1;
                return Json(new { ret = retorno, msg = "Funcionário Atualizado com sucesso!" });
            }


            //return Json(new { ret = retorno, msg = "" }); 
        }

        [HttpPost]
        public JsonResult SalvarPaciente(PacienteViewModel u)
        {
            int retorno = -1;
            string mensagem = "";

            return Json(new { ret = retorno, msg = "" });
        }

        [HttpPost]
        public JsonResult SalvarMedico(MedicoViewModel u)
        {
            int retorno = -1;
            string mensagem = "";

            return Json(new { ret = retorno, msg = "" });
        }

        // GET: Funcionario/Administrador
        public ActionResult Index()
        {
            return View();
        }

        // GET: Funcionario/Administrador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Funcionario/Administrador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Administrador/Create
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

        // GET: Funcionario/Administrador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Funcionario/Administrador/Edit/5
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

        // GET: Funcionario/Administrador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Funcionario/Administrador/Delete/5
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


        public ActionResult Funcionario()
        {
            Cache cache = new Cache();
            if (cache["DadosUsuario"] != null)
            //if (Session["usuarioLogadoID"] != null)
            {
                return View(Url.Content("~/Areas/Funcionario/Views/Administrador/Funcionario.cshtml"));
            }
            else
            {
                //return RedirectToAction("Login");
                return RedirectToAction("Index", "Login", new { Area = "" });
                //return RedirectToAction("Index", "Login");
            }
            
        }

        public ActionResult Medico()
        {
            Cache cache = new Cache();
            if (cache["DadosUsuario"] != null)
            //if (Session["usuarioLogadoID"] != null)
            {
                return View(Url.Content("~/Areas/Funcionario/Views/Administrador/Medico.cshtml"));
            }
            else
            {
                //return RedirectToAction("Login");
                return RedirectToAction("Index", "Login", new { Area = "" });
                //return RedirectToAction("Index", "Login");
            }
            
        }

        public ActionResult Paciente()
        {
            Cache cache = new Cache();
            if (cache["DadosUsuario"] != null)
            //if (Session["usuarioLogadoID"] != null)
            {
                return View(Url.Content("~/Areas/Funcionario/Views/Administrador/Paciente.cshtml"));
            }
            else
            {
                //return RedirectToAction("Login");
                return RedirectToAction("Index", "Login", new { Area = "" });
                //return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult GetFuncionarios()
        {

            RestClient restClient = new RestClient(string.Format("http://localhost:5000/api/Funcionario"));
            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode <= 0)
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
            }

            if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<ProjetoUnipWeb.Domain.Person.Funcionario> apiFuncionarios = new JsonDeserializer().Deserialize<List<ProjetoUnipWeb.Domain.Person.Funcionario>>(restResponse);

                var rows = apiFuncionarios.Select(_ => new[]
                {
                    _.Id.ToString(),
                    _.Pessoa.Nome,
                    _.Pessoa.Cpf,
                    _.Pessoa.Usuario.Email,
                    _.Cargo.Descricao
                });

                return JsonLargeData(new
                {
                    draw = 1,
                    recordsTotal = rows.Count(),
                    recordsFiltered = rows.Count(),
                    data = rows
                });
            }

            //var Funcionarios = new FuncionarioViewModel();

            //return Json(new { data = "" }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult JsonLargeData(object data)
        {
            return new JsonResult() { Data = data, MaxJsonLength = int.MaxValue, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult FormFuncionario(long? id)
        {
            //FuncionarioViewModel vm = new FuncionarioViewModel();
            FuncionarioViewModel apiFuncionarios = new FuncionarioViewModel();

            if (id != null)
            {
                

                RestClient restClient = new RestClient(string.Format("http://localhost:5000/api/Funcionario/{0}", id));
                RestRequest restRequest = new RestRequest(Method.GET);

                IRestResponse restResponse = restClient.Execute(restRequest);

                if (restResponse.StatusCode <= 0)
                {

                }

                if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {

                }
                else
                {
                    apiFuncionarios = new JsonDeserializer().Deserialize<FuncionarioViewModel>(restResponse);
                    apiFuncionarios.Pessoa.DataNascimento = apiFuncionarios.Pessoa.DataNascimento.Substring(8, 2) + "/" + apiFuncionarios.Pessoa.DataNascimento.Substring(5, 2)
                        + "/" + apiFuncionarios.Pessoa.DataNascimento.Substring(0, 4);
                }
            }
            

            return PartialView(Url.Content("~/Areas/Funcionario/Views/Partials/Administrador/FormFuncionario.cshtml"), apiFuncionarios);
        }

        public ActionResult FormMedico()
        {
            MedicoViewModel vm = null;
            vm = new MedicoViewModel
            {
                //Contribuinte = contribuinte,
                //Endereco = endereco
            };
            return PartialView(Url.Content("~/Areas/Funcionario/Views/Partials/Administrador/FormMedico.cshtml"), vm);
        }

        public ActionResult FormPaciente()
        {
            PacienteViewModel vm = null;
            vm = new PacienteViewModel
            {
                //Contribuinte = contribuinte,
                //Endereco = endereco
            };
            return PartialView(Url.Content("~/Areas/Funcionario/Views/Partials/Administrador/FormPaciente.cshtml"), vm);
        }

    }
}
