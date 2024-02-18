using System;
using System.Data;
using System.Collections.Generic;
using FinalProject.Models;
using Dapper;

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
            var pokedex = GetAllPokemon();
            var pokemon = new Pokemon();
            pokemon.Pokemons = pokedex;
            return pokemon;
        }

        public IEnumerable<Pokemon> GetAllPokemon()
        {
            return _connection.Query<Pokemon>("SELECT * FROM POKEMON;");
        }

        public Pokemon GetPokemon(int id)
        {
            return _connection.QuerySingle<Pokemon>("SELECT * FROM POKEMON WHERE POKEMONID = @id", new { id = id });
        }

        public void AddPokemon(Pokemon pokemonToAdd)
        {
            _connection.Execute("INSERT INTO pokemon (NAME, TYPE, ABILITIES, HP, ATTACK, DEFENSE, SPECIALATTACK, SPECIALDEFENSE, SPEED, GENERATION, LEGENDARY) VALUES (@name, @type, @abilities, @hp, @attack, @defense, @specialattack, @specialdefense, @speed, @generation, @legendary);",
                new { name = pokemonToAdd.Name, type = pokemonToAdd.Type, abilities = pokemonToAdd.Abilities, hp = pokemonToAdd.HP, attack = pokemonToAdd.Attack, defense = pokemonToAdd.Defense, specialAttack = pokemonToAdd.SpecialAttack, specialDefense = pokemonToAdd.SpecialDefense, speed = pokemonToAdd.Speed, generation = pokemonToAdd.Generation, legendary = pokemonToAdd.Legendary });

        }

        public void UpdatePokemon(Pokemon pokemon)
        {
            _connection.Execute("UPDATE pokemon SET Name = @name, Type = @type WHERE PokemonID = @id",
               new { name = pokemon.Name, type = pokemon.Type, id = pokemon.PokemonID });
        }

        public void DeletePokemon(Pokemon pokemon)
        {
            _connection.Execute("DELETE FROM Pokemon WHERE PokemonID = @id;", new {id = pokemon.PokemonID});
        }
    }
}
