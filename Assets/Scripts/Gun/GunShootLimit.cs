using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootLimit : GunBase
{
    public List<UIFillUpdate> uiGunUpdater;
    public UIFillUpdateType uiUpdateType;

    public float maxAmmo = 5f;
    public float timeToReload = 1f;

    private float _currentShots;
    private bool _needReload = false;


    private void Awake()
    {
        GetUIs();
    }


    protected override IEnumerator ShootCouroutine()
    {


        if (_needReload) yield break; //nao deixa executar o while se need reload for true

        while (true)
        {
            if(_currentShots < maxAmmo)
            {
                Shoot();
                _currentShots++;
                CheckReload();
                UpdateUI();
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }
    }

    private void CheckReload()
    {
        if (_currentShots >= maxAmmo)
        {
            StopShoot();
            ReloadGun();
        }
    }


    private void ReloadGun()
    {
        _needReload = true;
        StartCoroutine(ReloadGunCourroutine());

    }

    IEnumerator ReloadGunCourroutine()
    {
        float time = 0;

        while (time < timeToReload)
        {
            time += Time.deltaTime;
            uiGunUpdater.ForEach(i => i.UpdateValue(time / timeToReload));
            yield return new WaitForEndOfFrame();
        }

        _currentShots = 0;
        _needReload = false;

    }

    private void UpdateUI()
    {
        uiGunUpdater.ForEach(i => i.UpdateValue(maxAmmo, _currentShots));
    }


    private void GetUIs() //ineficiente, pesado, mas funciona para opções pequenas
    {
        uiGunUpdater = GameObject.FindObjectsOfType<UIFillUpdate>().ToList(); //original, pega todos os objetos que existem com esse script
        
        for(int i = uiGunUpdater.Count - 1; i>=0;i--)
        {
            if (uiGunUpdater[i].uiUpdateType != UIFillUpdateType.Ammo) uiGunUpdater.RemoveAt(i);
        }


        //uiGunUpdater = GameObject.Find("UI_Ammo").GetComponents<UIFillUpdate>().ToList(); // revisado, pega apenas 1 item
        //uiGunUpdater = GameObject.Find("UI_Ammo_Screen").GetComponents<UIFillUpdate>().ToList(); // revisado, pega apenas 1 item
        //está pegando o ultimo item apenas
        //nao eh uma pratica boa procurar objetos pelo seu nome, pode levar a conflitos


    }


}
