using System.Collections;
using UnityEngine;

namespace TurnBase.System
{
    public class Begin : State
    {
        public Begin(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            Debug.Log("Begin");
            BattleSystem.SetState(new FirstUnitState(BattleSystem));
        }
    }
}
