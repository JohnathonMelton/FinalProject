using System;
using System.Collections.Generic;
using FinalProject.Models;

namespace FinalProject
{
    public interface IPokemonRepository
    {
        public IEnumerable<Pokemon> GetAllPokemon();
        public Pokemon GetPokemon(int id);
        public void UpdatePokemon(Pokemon pokemon);
        public void AddPokemon(Pokemon pokemonToAdd);
        public IEnumerable<Pokemon>GetPokemon();

        public Pokemon AssignCategory();
        public void DeletePokemon(Pokemon pokemon);
    }
}
