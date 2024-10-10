using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    //usa o método novo de input da unity

    public GunBase gunBase;
    public Transform gunPosition;

    public List<GunBase> gunList;

    private GunBase _currentGun;

    private List<GunBase> gunInstances;
    private int gunIndex = 0;

    public FlashColour flashColor;

    

    protected override void Init()
    {
        base.Init(); 

        CreateGun();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        //funciona via callbacks
        //verifica se a acao conforme o editor foi realizada e busca um callback

        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();

        inputs.Gameplay.ChangeGun1.performed += ctx => ChangeGunNext();
        inputs.Gameplay.ChangeGun2.performed += ctx => ChangeGunPrevious();
    }

    private void CreateGun()
    {
        //pedido pelo exercício -> trocar arma usando 1 e 2
        gunInstances = new List<GunBase>(); //define uma lista com base nas guns

        for(int i = 0; i < gunList.Count; i++)
        {
            gunInstances.Add(Instantiate(gunList[i], gunPosition)); //instancia todas as armas da lista
            gunInstances[gunInstances.Count - 1].transform.localPosition = Vector3.zero;
            gunInstances[gunInstances.Count - 1].gameObject.SetActive(false); //desativa todas as armas
        }

        _currentGun = gunInstances[0];
        _currentGun.gameObject.SetActive(true); //reativa a primeira arma da lista
        gunIndex = 0;

        //jeito da aula, só seleciona na mão
        /*_currentGun = Instantiate(gunBase, gunPosition);
          _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;*/
    }


    private void StartShoot()
    {
        _currentGun.StartShoot();
        flashColor?.Flash(); //?. = if(xx != null)
        CameraShake.Instance.Shake();
    }

    private void CancelShoot()
    {
        _currentGun.StopShoot();
    }

    private void ChangeGunNext()
    {
        _currentGun.gameObject.SetActive(false);
        gunIndex++;

        if (gunIndex >= gunInstances.Count) gunIndex = 0;

        _currentGun = gunInstances[gunIndex];
        _currentGun.gameObject.SetActive(true);
    }

    private void ChangeGunPrevious()
    {
        _currentGun.gameObject.SetActive(false);
        gunIndex--;

        if (gunIndex < 0) gunIndex = gunInstances.Count - 1;

        _currentGun = gunInstances[gunIndex];
        _currentGun.gameObject.SetActive(true);
    }

}
