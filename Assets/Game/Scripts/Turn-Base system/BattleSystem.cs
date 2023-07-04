using UnityEngine;

namespace TurnBase.System
{
    public class BattleSystem: StateMachine
    {
        private void Start()
        {
            SetState(new Begin(this));  
        }
        public void OnAttackButton()
        {
            StartCoroutine(State.Attack());
        }

        public void OnHealButton()
        {
            StartCoroutine(State.Heal());
        }
    }
}
