using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.StateMachine;


namespace Boss
{
    public class BossStateBase : StateBase
    {
        protected BossBase boss;

        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss = (BossBase)objs[0]; //o primeiro parametro recebido quando inicializado é o script de boss, 0 no index de params
        }
    }

    public class BossStateInit : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.StartInitAnimation();
            Debug.Log("Boss Load: " + boss);
        }

    }    
    
    public class BossStateWalk : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.GoToRandomPoint(OnArrive); //callback - realiza a ação ao final do processo
        }

        private void OnArrive()
        {
            boss.SwitchStates(BossActions.ATTACK);
        }

        public override void OnStateExit()
        {
            Debug.Log("Exit Walk");
            base.OnStateExit();
            boss.StopAllCoroutines();
        }

    }    
    
    public class BossStateAttack : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.StartAttack(EndAttacks);
        }

        private void EndAttacks()
        {
            boss.SwitchStates(BossActions.WALK);
        }

        public override void OnStateExit()
        {
            Debug.Log("Exit Attack");
            base.OnStateExit();
            boss.StopAllCoroutines();
        }

    }    
    
    public class BossStateDeath : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            Debug.Log("Enter Death");
            boss.transform.localScale = Vector3.one * .2f;
        }


    }

}
