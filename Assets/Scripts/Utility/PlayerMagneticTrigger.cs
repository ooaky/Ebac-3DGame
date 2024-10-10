using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collectables;

public class PlayerMagneticTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        BaseCollectable i = other.transform.GetComponent<BaseCollectable>();
        if(i !=null)
        {
            i.gameObject.AddComponent<Magnetic>(); //adiciona o script ao objeto quando o trigger acontece
        }
    }
}

