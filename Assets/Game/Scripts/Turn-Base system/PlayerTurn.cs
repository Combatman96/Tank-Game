using System.Collections;
using UnityEngine;

namespace TurnBase.System
{
    internal class PlayerTurn : State
    {
        public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
        {
             
        }

        public override IEnumerator Attack()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Player Attack");
            BattleSystem.SetState(new EnemyTurn(BattleSystem));
        }

        public override IEnumerator Heal()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Player Heal");
            BattleSystem.SetState(new EnemyTurn(BattleSystem));
        }
    }
}