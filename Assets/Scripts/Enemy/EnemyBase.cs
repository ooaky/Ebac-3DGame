using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;
using UnityEngine.Events;


namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public Collider collider;
        public FlashColour flashColor;

        public ParticleSystem particleSystem;

        public float startLife = 10f;

        public float dealtDamage = 5;

        public bool lookAtPlayer = false;

        private Player _player;

        [SerializeField] private float _currentLife;

        [Header("Spawn Animation")]
        public float startAnimationDuration = .5f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithSpawnAnimation = true;

        [Header("Animations")]
        [SerializeField] private AnimationBase _animationBase;

        [Header("Event")]
        public UnityEvent onKillEvent;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _player = GameObject.FindObjectOfType<Player>();
        }

        protected virtual void Init()
        {
            ResetLife();
            if(startWithSpawnAnimation)
                SpawnAnimation();
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
            
        }

        protected virtual void Kill()
        {


            OnKill();
        }

        protected virtual void OnKill()
        {

            if (collider != null) collider.enabled = false;


            Destroy(gameObject, 3f);
            PlayAnimationByTrigger(AnimationType.DEATH);

            onKillEvent?.Invoke(); //quando o inimigo morre, ativa um evento descrito no editor

        }

        public void OnDamageTaken(float f)
        {
            if (flashColor != null) flashColor.Flash();
            if (particleSystem != null) particleSystem.Emit(15);

            //transform.position -= transform.forward;

            _currentLife -= f;
            
            if(_currentLife <= 0)
            {
                Kill();
            }           
        }

        public void Damage (float damage, Vector3 dir) //interface usada para fazer checagens em larga escala
        {
            //Debug.Log("Damaged");
            OnDamageTaken(damage);
            transform.DOMove(transform.position -= dir, .1f);
        }

        public void Damage (float damage) //interface usada para fazer checagens em larga escala
        {
            Debug.Log("Damaged");
            OnDamageTaken(damage);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Player p = collision.transform.GetComponent<Player>(); //identifica se a colisão foi com o player
            //precisa de um collider, o player controller nao implementa fisica desse jeito
            if (p != null)
            {
                p.healthBase.Damage(dealtDamage);
            }
        }


        #region Animations

        private void SpawnAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }


        #endregion

        #region Update


        public virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.T)) OnDamageTaken(5f);


            if(lookAtPlayer)
            {
                transform.LookAt(_player.transform.position);
            }

        }




        #endregion

    }
}
