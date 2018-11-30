using Crud.Aplicacao.Interfaces;
using Crud.Aplicacao.ViewModels;
using System;
using System.Globalization;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Crud.apresentacao.Ui.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppServicos _produtoAppServicos;

        public ProdutoController(IProdutoAppServicos produtoAppServicos)
        {
            _produtoAppServicos = produtoAppServicos;
        }
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produto/Details/5
        //public ActionResult Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProdutoViewModel produtoViewModel = _produtoAppServicos.ObterPorId(id.Value);
        //    if (produtoViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(produtoViewModel);
        //}

        public JsonResult Details(Guid? id)
        {
            if (id == null)
            {
                var errorReturn = new { success = false, Error = HttpStatusCode.BadRequest };
                return Json(errorReturn);
            }
            ProdutoViewModel produtoViewModel = _produtoAppServicos.ObterPorId(id.Value);
            if (produtoViewModel == null)
            {
                var errorReturn = new { success = false, Error = HttpNotFound() };
                return Json(errorReturn);
            }
            var successReturn = new { success = true, Produto = produtoViewModel };
            return Json(successReturn);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(string descricaoProd, double qtdEstoqueProd, string dataValidadeProd)
        {
            ProdutoViewModel produtoViewModel = new ProdutoViewModel();
            produtoViewModel.Descricao = descricaoProd;
            produtoViewModel.QtdEstoque = qtdEstoqueProd;
            DateTime dataValidadeDt = DateTime.Parse(dataValidadeProd);
            produtoViewModel.DataValidade = dataValidadeDt;
            produtoViewModel.Ativo = true;


            try
            {
                if (ModelState.IsValid)
                {
                    produtoViewModel = _produtoAppServicos.Adicionar(produtoViewModel);
                }

                return View("Index", _produtoAppServicos.ObterTodos());
            }
            catch
            {
                return View(produtoViewModel);
            }
        }

        // POST: Produto/CreateAsync
        [HttpPost]
        public JsonResult CreateAsync(string Descricao, int QtdEstoque, string DataValidade, bool Ativo)
        {

            ProdutoViewModel produtoViewModel = new ProdutoViewModel();
            produtoViewModel.Descricao = Descricao;
            produtoViewModel.QtdEstoque = QtdEstoque;
            DateTime dataValidadeDt = DateTime.Parse(DataValidade);
            produtoViewModel.DataValidade = dataValidadeDt;
            produtoViewModel.Ativo = Ativo;


            try
            {
                if (ModelState.IsValid)
                {
                    
                    produtoViewModel = _produtoAppServicos.Adicionar(produtoViewModel);
                    if (produtoViewModel != null)
                    {
                        var sucessReturn = new { success = true, dados = produtoViewModel };

                        return Json(sucessReturn);
                    }else
                    {
                        var returnErro = new { success = false, mensagem = "Verifique se a descrição possuí 4 ou mais caracteres ou se já possuí um produto com essa descrição!" };
                        return Json(returnErro);
                    }


                }

                var returnData = new { success = false, dados = produtoViewModel };
                return Json(returnData);
            }
            catch
            {

                return Json(produtoViewModel);
            }
        }

        public JsonResult ObterProdutos()
        {
            return Json(_produtoAppServicos.ObterTodos());
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoViewModel produtoViewModel = _produtoAppServicos.ObterPorId(id.Value);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        //POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoAppServicos.Atualizar(produtoViewModel);
                    return RedirectToAction("Index");
                }
                return View(produtoViewModel);
            }
            catch (Exception e)
            {
                return View(produtoViewModel);
            }
        }

        // POST: Produto/Edit/5
        [HttpPost, ActionName("EditAsync")]
        public JsonResult EditAsync(ProdutoViewModel produtoViewModel)
        {
            try
            {
                
                
                if (ModelState.IsValid)
                {
                    _produtoAppServicos.Atualizar(produtoViewModel);
                    var sucessReturn = new { success = true };

                    return Json(sucessReturn);
                }
                var erroReturn = new { success = false  };

                return Json(erroReturn);
            }
            catch (Exception e)
            {
                var erroReturn = new { success = false, mensagem = e };

                return Json(erroReturn);
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoViewModel produtoViewModel = _produtoAppServicos.ObterPorId(id.Value);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        // POST: Produto/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    try
        //    {
        //        _produtoAppServicos.Remover(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {

        //        return View();
        //    }
        //}

        [HttpPost, ActionName("Delete")]
        [AllowAnonymous]
        [ValidateHeaderAntiForgeryToken]
        public JsonResult DeleteConfirmed(Guid id)
        {
            try
            {
                _produtoAppServicos.Remover(id);
                var returnData = new { success = true, mensagem = "Removido com sucesso" };
                return Json(returnData);
            }
            catch (Exception e)
            {
                var returnData = new { success = false, mensagem = e.ToString() };
                return Json(returnData);
            }
        }

        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        private sealed class ValidateHeaderAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }

                var httpContext = filterContext.HttpContext;
                var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
                AntiForgery.Validate(cookie != null ? cookie.Value : null, httpContext.Request.Headers["__RequestVerificationToken"]);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _produtoAppServicos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
