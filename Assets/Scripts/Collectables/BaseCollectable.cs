using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectables
{
    public class BaseCollectable : MonoBehaviour
    {
        public SFXType sfxType;
        public ItemType itemType;

        public string compareTag = "Player";
        public ParticleSystem particleSystem;
        public float timeToHide = 1f;
        public GameObject graphicItem;
        public Collider collider;

        public AudioSource audioSource;


        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        private void PlaySFX()
        {
            SFXPool.Instance.Play(sfxType);
        }

        protected virtual void Collect()
        {
            PlaySFX();
            gameObject.SetActive(false);
            if (graphicItem != null) graphicItem.SetActive(false);
            Invoke("HideObject", timeToHide);
            OnCollect();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnCollect()
        {
            if (particleSystem != null)
            {
                particleSystem.transform.SetParent(null);
                particleSystem.Play();
                Destroy(particleSystem.gameObject, 2f);
            }

            if (audioSource != null) audioSource.Play();

            ItemManager.Instance.AddByType(itemType);
        }

    }
}
