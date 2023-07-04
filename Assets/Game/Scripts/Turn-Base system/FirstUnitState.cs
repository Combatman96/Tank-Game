using System.Collections;
using UnityEngine;

namespace TurnBase.System
{
    public class FirstUnitState : State
    {
        public FirstUnitState(BattleSystem battleSystem) : base(battleSystem)
        {
             
        }

        public override IEnumerator Attack()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("First Unit Attack");
            BattleSystem.SetState(new SecondUnitState(BattleSystem));
        }

        public override IEnumerator Heal()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("First Unit Heal");
            BattleSystem.SetState(new SecondUnitState(BattleSystem));
        }
    }
}