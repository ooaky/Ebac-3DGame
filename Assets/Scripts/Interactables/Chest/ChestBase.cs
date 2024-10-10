using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
    {
        public KeyCode interactKey = KeyCode.E;

        public Animator animator;
        public string triggerOpen = "Open";

        [Space]
        public ChestItemBase chestItem;
        public float timeToShowItem = 1f;

        [Header("Notification")]
        public GameObject notification;
        public float tweenDuration = .2f;
        public Ease tweenease = Ease.OutBack;
        private float startScale;
        private bool _isOpen = false;

        void Start()
        {
            HideNotification();
            startScale = notification.transform.localScale.x;
        }


        void Update()
        {
            if (_isOpen) return;
            if (Input.GetKeyDown(interactKey) && notification.activeSelf)
            {
                OpenChest();

            }
        }


        [NaughtyAttributes.Button]
        private void OpenChest()
        {
            animator.SetTrigger(triggerOpen);
            _isOpen = true;
            HideNotification();
            Invoke(nameof(ShowItem), timeToShowItem);
        }

        private void ShowItem()
        {
            chestItem.ShowItem();
            Invoke(nameof(CollectItem), 1f);
        }

    private void CollectItem()
    {
        chestItem.Collect();
    }


    public void OnTriggerEnter(Collider other)
        {
            Player p = other.transform.GetComponent<Player>();

            if (p != null)
            {
                ShowNotification();
            }
        }

        [NaughtyAttributes.Button]
        private void ShowNotification()
        {
            notification.SetActive(true);
            notification.transform.localScale = Vector3.zero;
            notification.transform.DOScale(startScale, tweenDuration).SetEase(tweenease);
        }


        public void OnTriggerExit(Collider other)
        {
            Player p = other.transform.GetComponent<Player>();

            if (p != null)
            {
                HideNotification();
            }
        }

        [NaughtyAttributes.Button]
        private void HideNotification()
        {
            notification.SetActive(false);
            //notification.transform.DOScale(startScale, -tweenDuration).SetEase(tweenease).From();
        }
    }
