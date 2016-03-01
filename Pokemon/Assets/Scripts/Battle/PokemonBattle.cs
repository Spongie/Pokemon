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
    public delegate void BattleFinished(bool victory);

    public class PokemonBattle : MonoBehaviour
    {
        public Party player;
        public Party enemy;

        public Pokemon PlayerActivePokemon;
        public Pokemon EnemyActivePokemon;
        public BattleState State;

        public bool IsBattleComplete;
        public event BattleFinished OnBattleFinished;

        private Stack<BattleAction> battleStack;
        private bool routine_running = false;
        private BattleAI ai;

        private bool playerPokemonDied;
        private bool enemyPokemonDied;

        void Awake()
        {
            ai = new BattleAI();
            PlayerActivePokemon = player.GetFirstAlivePokemon();
            EnemyActivePokemon = enemy.GetFirstAlivePokemon();
            battleStack = new Stack<BattleAction>();
            State = BattleState.SelectingAction;
        }

        public void SelectAction(BattleActionType action)
        {
            var aiAction = ai.GetBattleAction(this);

            bool playerSwap = !WasAttackSelected(action);
            bool aiSwap = !WasAttackSelected(aiAction);

            if (State == BattleState.PlayerSelectSwap)
            {
                battleStack.Push(BattleAction.CreateAction("Swap", player, GetSwapIndex(action)));
                State = BattleState.ResolvingEndOfCombat;
                return;
            }

            playerPokemonDied = false;
            enemyPokemonDied = false;

            if (playerSwap)
            {
                PlayerSwap(action, aiAction, aiSwap);
            }
            else if (aiSwap)
            {
                EnemySwap(action, aiAction, playerSwap);
            }
            else
            {
                HandleBothAttacks(action, aiAction);
            }

            State = BattleState.ResolvingActions;
        }

        private void HandleBothAttacks(BattleActionType action, BattleActionType aiAction)
        {
            bool playerFastest = PlayerActivePokemon.GetStats().Speed > EnemyActivePokemon.GetStats().Speed;

            if (playerFastest)
            {
                battleStack.Push(BattleAction.CreateAction("Attack", EnemyActivePokemon, EnemyActivePokemon.Attacks[(int)aiAction]));
                battleStack.Push(BattleAction.CreateAction("Attack", PlayerActivePokemon, PlayerActivePokemon.Attacks[(int)action]));
            }
            else
            {
                battleStack.Push(BattleAction.CreateAction("Attack", PlayerActivePokemon, PlayerActivePokemon.Attacks[(int)action]));
                battleStack.Push(BattleAction.CreateAction("Attack", EnemyActivePokemon, EnemyActivePokemon.Attacks[(int)aiAction]));
            }
        }

        private void EnemySwap(BattleActionType action, BattleActionType aiAction, bool playerSwap)
        {
            if (!playerSwap)
                battleStack.Push(BattleAction.CreateAction("Attack", PlayerActivePokemon, PlayerActivePokemon.Attacks[(int)action]));
            else
                battleStack.Push(BattleAction.CreateAction("Swap", player, GetSwapIndex(action)));

            battleStack.Push(BattleAction.CreateAction("Swap", enemy, GetSwapIndex(aiAction)));
        }

        private void PlayerSwap(BattleActionType action, BattleActionType aiAction, bool aiSwap)
        {
            if (!aiSwap)
                battleStack.Push(BattleAction.CreateAction("Attack", EnemyActivePokemon, EnemyActivePokemon.Attacks[(int)aiAction]));
            else
                battleStack.Push(BattleAction.CreateAction("Swap", enemy, GetSwapIndex(aiAction)));

            battleStack.Push(BattleAction.CreateAction("Swap", player, GetSwapIndex(action)));
        }

        private static int GetSwapIndex(BattleActionType aiAction)
        {
            return (int)aiAction - 4;
        }

        private static bool WasAttackSelected(BattleActionType action)
        {
            return action == BattleActionType.Attack1 || action == BattleActionType.Attack2 || action == BattleActionType.Attack3 || action == BattleActionType.Attack4;
        }

        void Update()
        {
            if (State == BattleState.SelectingAction)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    SelectAction(BattleActionType.Attack1);   
                }
            }
            if (State == BattleState.ResolvingActions && !routine_running)
            {
                if (!battleStack.Any())
                {
                    State = BattleState.EndCombat;
                }
                else
                {
                    BattleAction action = battleStack.Pop();
                    routine_running = true;
                    StartCoroutine(action.MethodName, action.Parmeter);
                }
            }
            else if (State == BattleState.PostCombat && !routine_running)
            {
                HandleEnemyStatusDamage();
                HandlePlayerStatusDamage();

                State = BattleState.EndCombat;
            }
            else if (State == BattleState.EndCombat && !routine_running)
            {
                if (battleStack.Any())
                {
                    BattleAction action = battleStack.Pop();
                    routine_running = true;
                    StartCoroutine(action.MethodName, action.Parmeter);
                }
                else
                {
                    if (!PlayerActivePokemon.IsAlive())
                    {
                        State = BattleState.PlayerSelectSwap;
                        playerPokemonDied = true;
                    }
                    if (!EnemyActivePokemon.IsAlive())
                    {
                        enemyPokemonDied = true;
                        var aiAction = ai.GetSwapWhenDeadPokemon(this);
                        battleStack.Push(BattleAction.CreateAction("Swap", enemy, GetSwapIndex(aiAction)));
                    }

                    if (State != BattleState.PlayerSelectSwap)
                        State = BattleState.ResolvingEndOfCombat;
                }
            }
            else if (State == BattleState.ResolvingEndOfCombat)
            {
                if (battleStack.Any())
                {
                    BattleAction action = battleStack.Pop();
                    routine_running = true;
                    StartCoroutine(action.MethodName, action.Parmeter);
                }
                else
                {
                    if (player.IsAllPokemonDead())
                    {
                        if (OnBattleFinished != null)
                            OnBattleFinished(false);

                        IsBattleComplete = true;
                    }
                    else if (enemy.IsAllPokemonDead())
                    {
                        if (OnBattleFinished != null)
                            OnBattleFinished(true);

                        IsBattleComplete = true;
                    }
                    else
                    {
                        if (!playerPokemonDied)
                            PlayerActivePokemon.TurnsWithCurrentStatus++;
                        if (!enemyPokemonDied)
                            EnemyActivePokemon.TurnsWithCurrentStatus++;
                    }
                }
            }
        }

        private void HandleEnemyStatusDamage()
        {
            if (!EnemyActivePokemon.IsAlive())
                return;

            if (EnemyActivePokemon.CurrentStatus == StatusType.Poison || EnemyActivePokemon.CurrentStatus == StatusType.BadlyPoison)
            {
                battleStack.Push(BattleAction.CreateAction("DealDamage", EnemyActivePokemon, BattleCalculations.CalculateStatusDamage(EnemyActivePokemon), null, StatusType.Poison));
            }
            if (EnemyActivePokemon.CurrentStatus == StatusType.Burn)
            {
                battleStack.Push(BattleAction.CreateAction("DealDamage", EnemyActivePokemon, BattleCalculations.CalculateStatusDamage(EnemyActivePokemon), null, StatusType.Burn));
            }
        }

        private void HandlePlayerStatusDamage()
        {
            if (!PlayerActivePokemon.IsAlive())
                return;

            if (PlayerActivePokemon.CurrentStatus == StatusType.Poison || PlayerActivePokemon.CurrentStatus == StatusType.BadlyPoison)
            {
                battleStack.Push(BattleAction.CreateAction("DealDamage", PlayerActivePokemon, BattleCalculations.CalculateStatusDamage(PlayerActivePokemon), null, StatusType.Poison));
            }
            if (PlayerActivePokemon.CurrentStatus == StatusType.Burn)
            {
                battleStack.Push(BattleAction.CreateAction("DealDamage", PlayerActivePokemon, BattleCalculations.CalculateStatusDamage(PlayerActivePokemon), null, StatusType.Burn));
            }
        }

        private IEnumerator Attack(object[] param)
        {
            Pokemon attacker = (Pokemon)param[0];
            Attack attack = (Attack)param[1];
            Pokemon target = attacker == PlayerActivePokemon ? EnemyActivePokemon : PlayerActivePokemon;

            int damage = BattleCalculations.CalculateDamage(attacker, target, attack);

            battleStack.Push(BattleAction.CreateAction("DealDamage", target, damage, attack));

            routine_running = false;

            yield return null;
        }

        private static float GetDamageTime(int damage)
        {
            float damageTime = 1000f;

            if (damage < 20)
                damageTime = 200;
            else if (damage < 60)
                damageTime = 500;

            return damageTime;
        }

        private IEnumerator Swap(object[] param)
        {
            Party owner = (Party)param[0];
            int newIndex = (int)param[1];

            if (owner == player)
            {
                PlayerActivePokemon = owner.Pokemons[newIndex];
            }
            else
            {
                EnemyActivePokemon = owner.Pokemons[newIndex];
            }

            routine_running = false;

            yield return null;
        }

        private IEnumerator DealDamage(object[] param)
        {
            Pokemon target = (Pokemon)param[0];
            int damage = (int)param[1];
            Attack attack = (Attack)param[2];
            StatusType damageFromStatus = StatusType.None;

            if (param.Length == 4)
                damageFromStatus = (StatusType)param[3];    

            float msPerDamage = GetDamageTime(damage) / damage;

            while (damage >= 0 && target.IsAlive())
            {   
                target.Stats.CurrentHealth--;
                damage--;
                yield return new WaitForSeconds(msPerDamage / 1000);
            }

            if (damageFromStatus != StatusType.None)
            {
                if (target.IsAlive())
                {
                    attack.ApplyEffect(target);
                }
            }

            if (!target.IsAlive())
            {
                battleStack.Clear();
                if (target == EnemyActivePokemon)
                {
                    //reward xp to playerpokemon
                }
            }

            routine_running = false;
        }
    }
}
