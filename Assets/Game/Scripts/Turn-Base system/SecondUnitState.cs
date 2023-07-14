using System.Collections;
using UnityEngine;

namespace TurnBase.System
{
    internal class SecondUnitState : State
    {
        public SecondUnitState(BattleSystem battleSystem) : base(battleSystem)
        {
            Debug.Log("Current State: Second Unit state");
        }

        public override IEnumerator Attack()
        {
            yield return null;
            Debug.Log("Second Unit Attack");
        }

        public override IEnumerator Heal()
        {
            yield return null;
            Debug.Log("Second Unit Heal");
        }

        public override IEnumerator EndState()
        {
            yield return null;
            BattleSystem.SetState(new FirstUnitState(BattleSystem));
        }
    }
}