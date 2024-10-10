using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    private float dealtDamage = 5;

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();

        if (p != null)
        {
            Debug.Log("Death Zone");
            Player.Instance.Respawn();
            //p.healthBase.Damage(dealtDamage);
        }

    }





}
