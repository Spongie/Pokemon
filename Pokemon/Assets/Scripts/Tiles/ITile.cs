using PokemonGame.Assets.Scripts.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame.Assets.Scripts.Tiles
{
    public interface ITile
    {
        void OnTileEntered(Player player);
        void OnTileExit(Player player);
        bool CanEnter(Player player);
    }
}
