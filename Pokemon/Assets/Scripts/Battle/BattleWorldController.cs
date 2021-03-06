﻿using PokemonGame.Assets.Scripts.Character;
using PokemonGame.Assets.Scripts.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace PokemonGame.Assets.Scripts.Battle
{
    public class BattleWorldController : MonoBehaviour
    {
        public GameObject battleObject;
        public Transform enemySpawn;
        public Transform playerSpawn;
        private PokemonBattle Battle;

        private GameObject activePlayer;
        private GameObject activeEnemy;

        public bool WaitingForAction;
        public Camera mainCamera;
        public FirstPersonController PlayerController;
        public Camera BattleCamera;

        public Image PlayerPokemonHealth;
        public Text PlayerPokemonHealthText;

        void Start() 
        {
            Battle = battleObject.GetComponent<PokemonBattle>();

            Battle.EnemyPokemonChanged += Battle_EnemyPokemonChanged;
            Battle.PlayerPokemonChanged += Battle_PlayerPokemonChanged;
        }

        private void Battle_PlayerPokemonChanged(object sender, EventArgs e)
        {
            activePlayer = (GameObject)Instantiate(PokemonManager.GetPokemonById(Battle.PlayerActivePokemon.Info.ID), playerSpawn.position, Quaternion.identity);

            foreach (var renderer in activePlayer.GetComponentsInChildren<MeshRenderer>())
            {
                renderer.enabled = true;
            }
        }

        private void Battle_EnemyPokemonChanged(object sender, EventArgs e)
        {
            activeEnemy = (GameObject)Instantiate(PokemonManager.GetPokemonById(Battle.EnemyActivePokemon.Info.ID), enemySpawn.position, Quaternion.identity);

            foreach (var renderer in activeEnemy.GetComponentsInChildren<MeshRenderer>())
            {
                renderer.enabled = true;
            }
        }

        void Update()
        {
            WaitingForAction = Battle.State == BattleState.SelectingAction || Battle.State == BattleState.PlayerSelectSwap;

            if (activePlayer != null && activeEnemy != null)
            {
                SetPokemonRotation();

                SetPlayerHealthInfo();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                mainCamera.enabled = false;
                PlayerController.enabled = false;
                BattleCamera.enabled = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                Party playerParty = new Party();
                playerParty.Pokemons.Add(PokemonManager.Pokemons.First().Value.GetComponent<PokemonBehaviour>().PokemonEntity.Copy());
                playerParty.Pokemons[0].FullyRestore();
                playerParty.Pokemons[0].SetLevel(50);

                Party enemyParty = new Party();
                enemyParty.Pokemons.Add(PokemonManager.Pokemons.First().Value.GetComponent<PokemonBehaviour>().PokemonEntity.Copy());
                enemyParty.Pokemons[0].FullyRestore();
                enemyParty.Pokemons[0].SetLevel(50);

                Battle.enemy = enemyParty;
                Battle.player = playerParty;

                battleObject.SetActive(true);
            }
        }

        private void SetPlayerHealthInfo()
        {
            PlayerPokemonHealth.fillAmount = Battle.PlayerActivePokemon.Stats.CurrentHealth / (float)Battle.PlayerActivePokemon.GetStats().Health;
            PlayerPokemonHealthText.text = Battle.PlayerActivePokemon.Stats.CurrentHealth + "/" + (float)Battle.PlayerActivePokemon.GetStats().Health;
        }

        private void SetPokemonRotation()
        {
            activeEnemy.transform.rotation = Quaternion.LookRotation(activePlayer.transform.position - activeEnemy.transform.position);
            activePlayer.transform.rotation = Quaternion.LookRotation(activeEnemy.transform.position - activePlayer.transform.position);
        }
    }
}
