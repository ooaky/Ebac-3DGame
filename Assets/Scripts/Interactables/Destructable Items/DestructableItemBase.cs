using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableItemBase : MonoBehaviour
{
    public HealthBase healthBase;

    public float shakeDuration = .1f;
    public int shakeForce = 5;

    [Header("Item Drop")]
    public Transform dropPosition;
    public Vector2 randomRange = new Vector2(-2f, 2f);
    public int dropAmmount = 10;
    [Space]
    public GameObject coinPrefab;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;
    }


    private void OnDamage(HealthBase h) //need tag to be "Enemy", looking for a bug fix
    {
        transform.DOShakeScale(shakeDuration, Vector3.up/2, shakeForce);
        DropGroupOfCoins();
    }

    private void DropCoins()
    {
        var i = Instantiate(coinPrefab);
        i.transform.position = dropPosition.transform.position + Vector3.forward * Random.Range(randomRange.x, randomRange.y) + Vector3.right * Random.Range(randomRange.x, randomRange.y);
        i.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From();
    }

    private void DropGroupOfCoins()
    {
        for (int i = 0; i < dropAmmount; i++) DropCoins();
        //StartCoroutine(DropGroupOfCoinsCouroutine());
            //opcao com delay para o drop das moedas
    }



    IEnumerator DropGroupOfCoinsCouroutine()
    {
        for (int i = 0; i < dropAmmount; i++) DropCoins();
        yield return new WaitForSeconds(.1f);
    }
}
