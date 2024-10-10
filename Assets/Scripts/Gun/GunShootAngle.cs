using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootAngle : GunShootLimit
{

    public int ammountPerShot = 4;
    public float shotAngle = 15f;


    public override void Shoot()
    {
        int mult = 0;

        for(int i = 0; i< ammountPerShot; i++)
        {
            if(i%2 == 0)
            {
                mult++;
            }


            var projectile = Instantiate(prefabProjectile, shootPosition);

            projectile.transform.position = shootPosition.position;

            projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? shotAngle : -shotAngle) * mult;
            //                                      vetor (0,1,0)      definidor de se é par ou nao - se for par multiplica por positivo, se for impar por negativo

            projectile.speed = shotSpeed;

            projectile.transform.parent = null; //tira de dentro do parent

        }
    }
}
