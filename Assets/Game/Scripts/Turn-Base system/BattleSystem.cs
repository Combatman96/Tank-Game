using UnityEngine;

namespace TurnBase.System
{
    public class BattleSystem: StateMachine
    {
        [SerializeField][Range(1,3)] int maxActions;
        public int NumberOfActions;
        private void Start()
        {
            ResetAction();
            SetState(new Begin(this));  
        }
        public void OnUnitAttack()
        {
            StartCoroutine(State.Attack());
            NumberOfActions--;
        }

        public void OnUnitHeal()
        {
            StartCoroutine(State.Heal());
            NumberOfActions--;
        }

        public void OnUnitEndState() {
            StartCoroutine(State.EndState());
            ResetAction();
        }

        private void ResetAction()
        {
            NumberOfActions = maxActions;
        }
    }
}
