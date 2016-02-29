using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonGame.Assets.Scripts.Battle
{
    public class BattleAI
    {
        public BattleActionType GetBattleAction(PokemonBattle battle)
        {
            return BattleActionType.Attack1;
        }
    }
}
