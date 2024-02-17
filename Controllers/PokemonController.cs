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
        private readonly IPokemonRepository pokeRepo;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            this.pokeRepo = pokemonRepository;
        }

        public IActionResult Index()
        {
            var pokemon = pokeRepo.GetAllPokemon();
            return View(pokemon);
        }

        public IActionResult Details(int id)
        {
            var pokemon = pokeRepo.GetPokemon(id);
            return View(pokemon);
        }

        public IActionResult UpdatePokemon(int id)
        {
            Pokemon pokemon = pokeRepo.GetPokemon(id);
            if (pokemon == null)
            {
                return View("PokemonNotFound");
            }
            return View(pokemon);
        }

        public IActionResult UpdatePokemonToDatabase(Pokemon pokemon)
        {
            pokeRepo.UpdatePokemon(pokemon);

            return RedirectToAction("ViewPokemon", new { id = pokemon.PokemonID });
        }

        public IActionResult AddPokemon()
        {
            var pokemon = pokeRepo.AssignCategory();
            return View(pokemon);
        }

        public IActionResult AddPokemonToDatabase(Pokemon pokemonToAdd)
        {
            pokeRepo.AddPokemon(pokemonToAdd);
            return RedirectToAction("Index");
        }

        public ActionResult DeletePokemon(Pokemon pokemon)
        {
            pokeRepo.DeletePokemon(pokemon);
            return RedirectToAction("Index");
        }

    }
}
