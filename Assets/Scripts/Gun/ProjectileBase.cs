using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy = 2f;
    public int damageAmount = 1;
    public float speed = 30f;

    public List<string> tagsToHit;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        var projectile = collision.collider.GetComponent<ProjectileBase>(); //verifica se houve colisao com o projetil

        if (projectile != null) return; //se o projetil colidiu com si mesmo, nao faz a proxima parte do codigo


        foreach (var t in tagsToHit) //verifica a lista de tags
        {
            if (collision.transform.tag == t) //só causa dano/tem colisao caso o item esteja na lista de tags
            {
                var damageable = collision.transform.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    Vector3 dir = collision.transform.position - transform.position; //identifica a direção da colisao e calcula para onde mover o inimigo
                    dir = -dir.normalized; //retorna o vetor para 1 independente da conta anterior
                    dir.y = 0;

                    damageable.Damage(damageAmount, dir);
                }
            }

        }

        Destroy(gameObject);

    }
}
