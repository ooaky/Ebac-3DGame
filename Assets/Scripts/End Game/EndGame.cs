using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public List<GameObject> endGameObjects;

    [SerializeField]
    private bool _endGame = false;

    public int _currentLevel = 1;


    private void Awake()
    {
        endGameObjects.ForEach(i => i.SetActive(false));
    }

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>(); 

        if (!_endGame && p != null)
        {
            ShowEndGame(); //roda a função quando identifica o player na area
            Debug.Log("in");
        }
    }

    private void ShowEndGame()
    {

        _endGame = true;
        endGameObjects.ForEach(i => i.SetActive(true));

        foreach(var i in endGameObjects)
        {
            i.SetActive(true);
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            SaveManager.Instance.SaveLastLevel(_currentLevel);
            SaveManager.Instance.SaveLastCheckpoint(0);
        }
    }

}
