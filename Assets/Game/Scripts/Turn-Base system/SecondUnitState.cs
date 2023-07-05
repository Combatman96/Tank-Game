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
            yield return new WaitForSeconds(1f);
            Debug.Log("Second Unit Attack");
            BattleSystem.SetState(new FirstUnitState(BattleSystem));
        }

        public override IEnumerator Heal()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Second Unit Heal");
            BattleSystem.SetState(new FirstUnitState(BattleSystem));
        }
    }
}