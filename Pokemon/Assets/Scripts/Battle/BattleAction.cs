namespace PokemonGame.Assets.Scripts.Battle
{
    public class BattleAction
    {
        public static BattleAction CreateAction(string method, params object[] parameters)
        {
            var x = new BattleAction();

            x.MethodName = method;
            x.Parmeter = parameters;

            return x;
        }

        public string MethodName { get; set; }
        public object Parmeter { get; set; }
    }
}
