using System;
using System.Data;
using System.Collections.Generic;
using FinalProject.Models;
using Dapper;
using System.Net.Http.Headers;

namespace FinalProject
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IDbConnection _connection;

        public PokemonRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Pokemon AssignCategory()
        {
            var pokemonID = GetAllPokemon();
            var pokemon = new Pokemon();
            pokemon.Pokemons = pokemonID;
            return pokemon;
        }
        public void AddPokemon(Pokemon pokemonToAdd)
        {
            _connection.Execute("INSERT INTO pokemon (NAME, TYPE, POKEMONID) VALUES (@name, @type, @pokemonid);",
                new { name = pokemonToAdd.Name, type = pokemonToAdd.Type, pokemonid = pokemonToAdd.PokemonID });
        }

        public void DeletePokemon(Pokemon pokemon)
        {
            _connection.Execute("DELETE FROM POKEMON WHERE PokemonID = @id;", new {id = pokemon.PokemonID });
        }

        public IEnumerable<Pokemon> GetAllPokemon()
        {
            return _connection.Query<Pokemon>("SELECT * FROM POKEMON;");
        }

        public Pokemon GetPokemon(int id)
        {
            return _connection.QuerySingle<Pokemon>("SELECT * FROM POKEMON WHERE POKEMONID = @id", new {id = id});
        }

        public void UpdatePokemon(Pokemon pokemon)
        {
            _connection.Execute("UPDATE pokemon SET Name = @name, Type = @type WHERE pokemonid = @id",
                new { name = pokemon.Name, type = pokemon.Type, id = pokemon.PokemonID });
        }

        public IEnumerable<Pokemon> GetPokemon()
        {
            return _connection.Query<Pokemon>("SELECT * FROM pokemons;");
        }
    }
}
