using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Cloth;

public class HealthBase : MonoBehaviour,IDamageable
{
    public float startLife = 10f;
    public bool destroyOnKill = false;

    public float damageMultiply = 1;

    [SerializeField] private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    public List<UIFillUpdate> healthUpdater;


    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        _currentLife = startLife;
        UpdateUI();
    }

    protected virtual void Kill()
    {
        if(destroyOnKill)
            Destroy(gameObject, 3f);

        OnKill?.Invoke(this);
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }


    public void Damage(float f)
    {
        _currentLife -= f * damageMultiply;

        if (_currentLife <= 0)
        {
            Kill();
        }

        UpdateUI();
        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }

    private void UpdateUI()
    {
        if (healthUpdater != null)
        {
            healthUpdater.ForEach(i => i.UpdateValue((float)_currentLife / startLife));
        }
    }

    public void ChangeDamageMult(float damageMult, float duration)
    {
        StartCoroutine(ChangeDamageMultCourroutine(damageMult, duration));
    }

    IEnumerator ChangeDamageMultCourroutine(float damageMult, float duration)
    {
        this.damageMultiply = damageMult;
        yield return new WaitForSeconds(duration);
        this.damageMultiply = 1;
    }

}
