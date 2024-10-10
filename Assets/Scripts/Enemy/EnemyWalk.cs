using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyWalk : EnemyBase
    {


        [Header("Movement")]
        public GameObject[] waypoints;
        public float minDistance = 1f;
        public float speed = 10f;


        private int _index = 0;


        public override void Update()
        {
            base.Update();

            if(Vector3.Distance(transform.position, waypoints[_index].transform.position) < minDistance) //verifica se a posição atual em relação ao waypoint é menor que o definido
            {
                _index++;
                if(_index >= waypoints.Length)
                {
                    _index = 0;
                }
            }

                transform.position = Vector3.MoveTowards(transform.position, waypoints[_index].transform.position, Time.deltaTime * speed);
            transform.LookAt(waypoints[_index].transform.position);
        }





    }
}
