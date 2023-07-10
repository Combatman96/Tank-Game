using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBase.System
{
    public class TrackingAction : MonoBehaviour
    {
        [SerializeField] private BattleSystem battleSystem;
        private Text actionLeftText;

        private void Awake()
        {
           actionLeftText = GetComponent<Text>();
        }
        // Update is called once per frame
        void Update()
        {
            actionLeftText.text = "Action left: " + battleSystem.NumberOfActions;
        }
    }

}
