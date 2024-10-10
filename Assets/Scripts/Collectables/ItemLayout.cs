using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Collectables
{
    public class ItemLayout : MonoBehaviour
    {
        private ItemSettup _currItemSettup;
        public Image uiIcon;
        public TextMeshProUGUI uiValue;

        public void Load(ItemSettup settup)
        {
            _currItemSettup = settup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _currItemSettup.icon;
        }

        private void Update()
        {
            uiValue.text = _currItemSettup.soInt.value.ToString();
        }
    }
}
