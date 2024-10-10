using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform shootPosition;

    public float shotSpeed = 50f;

    public float timeBetweenShots = .3f;
    public KeyCode shootKey = KeyCode.Mouse0;

    private Coroutine _currentCoroutine;



    private void Update()
    {
        
        //método antigo da unity
        /*if (Input.GetKeyDown(shootKey))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(shootKey))
        {
            if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        }*/

    }

    protected virtual IEnumerator ShootCouroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    public virtual void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = shootPosition.position;
        projectile.transform.rotation = shootPosition.rotation;
        projectile.speed = shotSpeed;

    }

    public void StartShoot()
    {
        StopShoot();
        _currentCoroutine = StartCoroutine(ShootCouroutine());
    }

    public void StopShoot()
    {
       if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);

    }
}
