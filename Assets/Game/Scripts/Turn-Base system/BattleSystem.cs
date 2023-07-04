using UnityEngine;

namespace TurnBase.System
{
    public class BattleSystem: StateMachine
    {

        private void Start()
        {
            SetState(new Begin(this));  
        }
        public void OnUnitAttack()
        {
            StartCoroutine(State.Attack());
        }

        public void OnUnitHeal()
        {
            StartCoroutine(State.Heal());
        }
    }
}
