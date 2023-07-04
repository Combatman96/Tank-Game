using System.Collections;
using UnityEngine;

namespace TurnBase.System
{
    internal class EnemyTurn : State
    {
        public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
        {
        }

        public override IEnumerator Attack()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Enemy Attack");
            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }

        public override IEnumerator Heal()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Enemy Heal");
            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }
    }
}