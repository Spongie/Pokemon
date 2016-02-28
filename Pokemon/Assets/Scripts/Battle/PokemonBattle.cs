using PokemonGame.Assets.Scripts.Battle.Attacks;
using PokemonGame.Assets.Scripts.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PokemonGame.Assets.Scripts.Battle
{
    public class PokemonBattle : MonoBehaviour
    {
        public Party player;
        public Party enemy;

        public Pokemon PlayerActivePokemon;
        public Pokemon EnemyActivePokemon;
        public BattleState State;

        private Stack<IEnumerator> battleStack;
        private bool routine_running = false;
        private BattleAI ai;

        void Start()
        {
            ai = new BattleAI();
            PlayerActivePokemon = player.GetFirstAlivePokemon();
            EnemyActivePokemon = enemy.GetFirstAlivePokemon();
            battleStack = new Stack<IEnumerator>();
            State = BattleState.SelectingAction;
        }

        public void SelectAction(BattleAction action)
        {
            if (State == BattleState.SelectingAction)
            {
                var actions = new List<IEnumerator>();
                var aiAction = ai.GetBattleAction(this);

                bool playerSwap = WasAttackSelected(action);
                bool aiSwap = WasAttackSelected(aiAction);

                if (playerSwap)
                {
                    PlayerSwap(action, actions, aiAction, aiSwap);
                }
                else if (aiSwap)
                {
                    EnemySwap(action, actions, aiAction, playerSwap);
                }
                else
                {
                    HandleBothAttacks(action, actions, aiAction);
                }

                State = BattleState.ResolvingActions;
            }
        }

        private void HandleBothAttacks(BattleAction action, List<IEnumerator> actions, BattleAction aiAction)
        {
            bool playerFastest = PlayerActivePokemon.Stats.GetRealStats().Speed > EnemyActivePokemon.Stats.GetRealStats().Speed;

            if (playerFastest)
            {
                actions.Add(Attack(player.Pokemons.IndexOf(PlayerActivePokemon), PlayerActivePokemon.Attacks[(int)action]));
                actions.Add(Attack(enemy.Pokemons.IndexOf(EnemyActivePokemon), EnemyActivePokemon.Attacks[(int)aiAction]));
            }
            else
            {
                actions.Add(Attack(enemy.Pokemons.IndexOf(EnemyActivePokemon), EnemyActivePokemon.Attacks[(int)aiAction]));
                actions.Add(Attack(player.Pokemons.IndexOf(PlayerActivePokemon), PlayerActivePokemon.Attacks[(int)action]));
            }
        }

        private void EnemySwap(BattleAction action, List<IEnumerator> actions, BattleAction aiAction, bool playerSwap)
        {
            if (!playerSwap)
                actions.Add(Attack(player.Pokemons.IndexOf(PlayerActivePokemon), PlayerActivePokemon.Attacks[(int)action]));
            else
                actions.Add(Swap(player, GetSwapIndex(action)));

            actions.Add(Swap(enemy, GetSwapIndex(aiAction)));
        }

        private void PlayerSwap(BattleAction action, List<IEnumerator> actions, BattleAction aiAction, bool aiSwap)
        {
            if (!aiSwap)
                actions.Add(Attack(enemy.Pokemons.IndexOf(EnemyActivePokemon), EnemyActivePokemon.Attacks[(int)aiAction]));
            else
                actions.Add(Swap(enemy, GetSwapIndex(aiAction)));

            actions.Add(Swap(player, GetSwapIndex(action)));
        }

        private static int GetSwapIndex(BattleAction aiAction)
        {
            return (int)aiAction - 4;
        }

        private static bool WasAttackSelected(BattleAction action)
        {
            return action == BattleAction.Attack1 || action == BattleAction.Attack2 || action == BattleAction.Attack3 || action == BattleAction.Attack4;
        }

        void Update()
        {
            if (State == BattleState.ResolvingActions && !routine_running)
            {
                var action = battleStack.Pop();
                StartCoroutine(action);
                routine_running = true;
            }
        }

        private IEnumerator Attack(int attackerIndex, Attack attack)
        {
            return null;
        }

        private IEnumerator Swap(Party owner, int newIndex)
        {
            return null;
        }

        private IEnumerator DealDamage(Pokemon target, int amount)
        {
            return null;
        }
    }
}
