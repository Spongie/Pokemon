using UnityEngine;

namespace PokemonGame.Assets.Scripts.Character
{
    public class PokemonBehaviour : MonoBehaviour
    {
        public Pokemon PokemonEntity;

        public Pokemon GetPokemonClone()
        {
            return PokemonEntity.Copy();
        }
    }
}
