using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collectables;

    public class ActionLifePack : MonoBehaviour
    {
        public SOInt soInt;
        public KeyCode healButton = KeyCode.I; 


        private void Start()
        {
            soInt = ItemManager.Instance.GetItemByType(ItemType.LIFE_PACK).soInt;
        }

        public void RecoverLife()
        {
            if(soInt.value > 0)
            {
                ItemManager.Instance.RemoveByType(ItemType.LIFE_PACK);
                Player.Instance.healthBase.ResetLife();
            }

        }

        private void Update()
        {
            if (Input.GetKeyDown(healButton)) RecoverLife();
        }

    }
