using System.Collections;
using UnityEngine;

namespace TurnBase.System
{
    public class FirstUnitState : State
    {
        public FirstUnitState(BattleSystem battleSystem) : base(battleSystem)
        {
            Debug.Log("Current State: First Unit state");
        }

        public override IEnumerator Attack()
        {
            yield return null;
            Debug.Log("First Unit Attack");
        }

        public override IEnumerator Heal()
        {
            yield return null;
            Debug.Log("First Unit Heal");
        }

        public override IEnumerator EndState()
        {
            yield return null;
            BattleSystem.SetState(new SecondUnitState(BattleSystem));
        }
    }
}