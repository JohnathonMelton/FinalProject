using System;
using System.Data;
using System.Collections.Generic;
using FinalProject.Models;
using Dapper;
using Org.BouncyCastle.Asn1.Esf;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Extensions.Logging;

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
            return _connection.QueryFirstOrDefault<Pokemon>("SELECT * FROM POKEMON WHERE POKEMONID = @id", new { id = id });
        }

        public void AddPokemon(Pokemon pokemonToAdd)
        {
            _connection.Execute("INSERT INTO pokemon (POKEMONID, NAME, TYPE, ABILITIES, HP, ATTACK, DEFENSE, SPECIALATTACK, SPECIALDEFENSE, SPEED, GENERATION, IMAGEURL) VALUES (@pokemonid, @name, @type, @abilities, @hp, @attack, @defense, @specialattack, @specialdefense, @speed, @generation, @imageurl);",
                new { pokemonid = pokemonToAdd.PokemonID, name = pokemonToAdd.Name, type = pokemonToAdd.Type, abilities = pokemonToAdd.Abilities, hp = pokemonToAdd.HP, attack = pokemonToAdd.Attack, defense = pokemonToAdd.Defense, specialAttack = pokemonToAdd.SpecialAttack, specialDefense = pokemonToAdd.SpecialDefense, speed = pokemonToAdd.Speed, generation = pokemonToAdd.Generation, imageURL = pokemonToAdd.ImageURL });

        }

        public void UpdatePokemon(Pokemon updatedPokemon)
        {
            string sql = @"UPDATE POKEMON SET Name = @Name, Type = @Type, Abilities = @Abilities, HP = @Hp, Attack = @Attack, Defense = @Defense, SpecialAttack = @SpecialAttack, SpecialDefense = @SpecialDefense, Speed = @Speed, Generation = @Generation, ImageURL = @ImageURL WHERE PokemonID = @PokemonID";
            _connection.Execute(sql, updatedPokemon);
        }

        public void DeletePokemon(Pokemon pokemon)
        {
            _connection.Execute("DELETE FROM Pokemon WHERE PokemonID = @id;", new {id = pokemon.PokemonID});
        }
    }
}
