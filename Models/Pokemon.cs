using System;
using System.Collections.Generic;


namespace FinalProject
{
    public class Pokemon
    {
       

        public int PokemonID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Abilities { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public string ImageURL { get; set; }


        public IEnumerable<Pokemon> Pokemons { get; set; }
        

    }
}
