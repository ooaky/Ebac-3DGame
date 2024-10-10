using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnBase : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform bossSpawnPosition;
    public float waitBeforeAttack = 2f;
    public Boss.BossBase _boss;

    private Player _player;
    private Coroutine coroutine;

    [SerializeField] private List<GameObject> _activateOnDeathList;


    private void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();

        if (p != null)
        {
            var spawn = Instantiate(bossPrefab);
            spawn.transform.position = bossSpawnPosition.position;
            _boss = spawn.GetComponentInChildren<Boss.BossBase>();
            coroutine = StartCoroutine(SpawnCourroutine());
            _boss.healthBase.OnKill += OnBossKill;
            _player.healthBase.OnKill += OnPlayerKill;
        }

    }

    private void OnBossKill(HealthBase h)
    {
        foreach (var i in _activateOnDeathList)
        {
            i.SetActive(true);
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
        }
    }

    private void OnPlayerKill (HealthBase h)
    {
        Destroy(_boss.gameObject);

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    IEnumerator SpawnCourroutine()
    {
        _boss.SwitchInit();
        yield return new WaitForSeconds(waitBeforeAttack);
        _boss.SwitchWalk();
        StopCoroutine(SpawnCourroutine()); //nao sei se eh necessario
    }


    private void OnTriggerExit(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();

        if (p != null)
        {

            Destroy(_boss.gameObject);//destroi a instancia spawnada do _boss, nao o prefab

            if(coroutine!=null) //verifica se a corrotina esta ainda rodando e mata ela para evitar de rodar algo que nao existe
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }



    }



}
