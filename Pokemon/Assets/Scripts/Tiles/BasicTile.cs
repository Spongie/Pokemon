using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PokemonGame.Assets.Scripts.Character;

namespace PokemonGame.Assets.Scripts.Tiles
{
    public class BasicTile : ITile
    {
        public bool CanEnter(Player player)
        {
            return true;
        }

        public void OnTileEntered(Player player)
        {

        }

        public void OnTileExit(Player player)
        {

        }
    }
}
