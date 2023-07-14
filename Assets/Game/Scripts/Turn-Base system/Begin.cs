using System.Collections;
using UnityEngine;

namespace TurnBase.System
{
    public class Begin : State
    {
        public Begin(BattleSystem battleSystem) : base(battleSystem)
        {
            Debug.Log("Current State:Begin");
        }

        public override IEnumerator Start()
        {
            yield return null;
            Debug.Log("Begin");
            BattleSystem.SetState(new FirstUnitState(BattleSystem));
        }
    }
}
