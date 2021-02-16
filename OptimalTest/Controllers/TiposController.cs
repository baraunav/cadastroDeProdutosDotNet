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
    public class TiposController : Controller
    {
        private readonly ITipoRepository _tipoRepository;
        public TiposController(ITipoRepository tipoRepository){
            _tipoRepository = tipoRepository;
        }

        // GET: TiposController
        public async Task<ActionResult> Index()
        {
            var tipos = await _tipoRepository.ListAll();
            return View(tipos);
        }

        // GET: TiposController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var tipo = await _tipoRepository.GetTipoById(id);
            return View(tipo);
        }

        // GET: TiposController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TipoProduto tipo)
        {
            try
            {
                if(ModelState.IsValid){
                    await _tipoRepository.Add(tipo);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiposController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var tipo = await _tipoRepository.GetTipoById(id);
            return View(tipo);
        }

        // POST: TiposController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TipoProduto tipo)
        {
            try
            {   
                if(ModelState.IsValid)
                    await _tipoRepository.Update(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiposController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var tipo = await _tipoRepository.GetTipoById(id);
            return View(tipo);
        }

        // POST: TiposController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TipoProduto tipo)
        {
            try
            {
                await _tipoRepository.Delete(tipo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
