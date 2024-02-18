using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository repo;

        public PokemonController(IPokemonRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var pokemon = repo.GetAllPokemon();

            return View(pokemon);
        }

        public IActionResult Details(int id)
        {
            var pokemon = repo.GetPokemon(id);
            return View(pokemon);
        }

        public IActionResult UpdatePokemon(int id)
        {
            Pokemon pokemon = repo.GetPokemon(id);
            if (pokemon == null)
            {
                return View("PokemonNotFound");
            }
            return View(pokemon);
        }

        public IActionResult UpdatePokemonToDatabase(Pokemon pokemon)
        {
            repo.UpdatePokemon(pokemon);

            return RedirectToAction("ViewPokemon", new { id = pokemon.PokemonID });
        }

        public IActionResult AddPokemon()
        {
            var pokemon = repo.AssignCategory();
            return View(pokemon);
        }

        public IActionResult AddPokemonToDatabase(Pokemon pokemonToAdd)
        {
            repo.AddPokemon(pokemonToAdd);
            return RedirectToAction("Index");
        }

        public ActionResult DeletePokemon(Pokemon pokemon)
        {
            repo.DeletePokemon(pokemon);
            return RedirectToAction("Index");
        }

    }
}
