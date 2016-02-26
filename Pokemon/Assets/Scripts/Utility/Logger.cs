using UnityEngine;

namespace PokemonGame.Assets.Scripts.Utility
{
    public class PokemonLogger
    {
        public static void Log(object message)
        {
            if (Debug.isDebugBuild)
                Debug.Log(message);
        }
    }
}
