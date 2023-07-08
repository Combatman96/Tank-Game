using System.Collections;



namespace TurnBase.System
{
    public abstract class State 
    {
        protected BattleSystem BattleSystem { get; set; }

        protected State(BattleSystem battleSystem)
        {
            BattleSystem = battleSystem;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual IEnumerator Attack()
        {
            yield break;
        }

        public virtual IEnumerator Heal()
        {
            yield break;
        }

        public virtual IEnumerator EndState()
        {
            yield break;
        }
    }
}

