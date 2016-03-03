using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame.Assets.Scripts.Battle.AI
{
    public interface IBattleAI
    {
        BattleActionType GetBattleAction(PokemonBattle battle);
        BattleActionType GetSwapWhenDeadPokemon(PokemonBattle battle);
    }
}
