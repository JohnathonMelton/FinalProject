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

        //Action method to display all pokemon
        public IActionResult Index()
        {
            var pokemon = repo.GetAllPokemon();

            return View(pokemon);
        }

        // Action method to display details of a specific Pokemon based on its ID
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

        // Action method to handle the update of a Pokemon's information in the database
        [HttpPost]
        public IActionResult UpdatePokemonToDatabase(Pokemon pokemon)
        {
            repo.UpdatePokemon(pokemon); // Updating the Pokemon's information in the repository

            return RedirectToAction("Index"); // Redirecting to the Index action after updating
        }

        public IActionResult AddPokemon()
        {
            var pokemon = repo.AssignCategory(); // Retrieving data necessary for assigning a category to the new Pokemon

            return View(pokemon); // Passing the retrieved data to the corresponding view for adding a new Pokemon
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
