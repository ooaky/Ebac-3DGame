using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{


    public class ClothPickerBase : MonoBehaviour
    {
        public ClothType clothType;

        public float duration = 2f;

        public string compareTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(compareTag)) Collect();
        }

        public virtual void Collect()
        {
            Debug.Log("Collected");

            var setup = ChlothesManager.Instance.GetSetupByType(clothType);

            Player.Instance.ChangeTexture(setup, duration);

            HideObject();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }


    }
}
