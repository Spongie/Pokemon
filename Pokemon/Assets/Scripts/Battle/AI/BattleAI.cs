using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame.Assets.Scripts.Battle.AI
{
    public class BattleAI : IBattleAI
    {
        public BattleActionType GetBattleAction(PokemonBattle battle)
        {
            return BattleActionType.Attack1;
        }

        public BattleActionType GetSwapWhenDeadPokemon(PokemonBattle battle)
        {
            return BattleActionType.Swap1;
        }
    }
}
