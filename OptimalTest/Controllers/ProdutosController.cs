using Domain;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimalTest.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ITipoRepository _tipoRepository;

        public ProdutosController(IProdutoRepository produtoRepository, ITipoRepository tipoRepository){
            _produtoRepository = produtoRepository;
            _tipoRepository = tipoRepository;
        }


        // GET: ProdutosController
        public async Task<ActionResult> Index()
        {
            var produtos = await _produtoRepository.GetAllProdutosWithTipoAsync();
            return View(produtos);
        }

        // GET: ProdutosController/Details/5
        public async Task<ActionResult> Details(int id){
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            return View(produto);
        }

        // GET: ProdutosController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Tipos = new SelectList((await _tipoRepository.ListAll()), "id", "descricao");
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Produto produto, string TipoProduto)
        {
            try
            {
                if(ModelState.IsValid){
                    var tipoProduto = await _tipoRepository.GetTipoById(int.Parse(TipoProduto)); 

                    produto.TipoProduto = tipoProduto;
                    await _produtoRepository.Add(produto);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            ViewBag.Tipos = new SelectList(await _tipoRepository.ListAll(), "id", "descricao", produto.TipoProduto);
            return View(produto);
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Produto produto, string TipoProduto)
        {                       
            try
            {
                if(ModelState.IsValid){
                    var tipoProduto = await _tipoRepository.GetTipoById(int.Parse(TipoProduto)); 

                    produto.TipoProduto = tipoProduto;
                    await _produtoRepository.Update(produto);

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            return View(produto);
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Produto produto)
        {
            try
            {
                await _produtoRepository.Delete(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
