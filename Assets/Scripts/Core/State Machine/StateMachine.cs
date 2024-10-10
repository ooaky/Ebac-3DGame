using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;


namespace Core.StateMachine
{
    /*public class Test
    {
        public enum TesteEnum
        {
            NONE
        }


        public void Teste()
        {
            StateMachine<TesteEnum> stateMachine = new StateMachine<TesteEnum>();

            stateMachine.RegisterStates(Test.TesteEnum.NONE, new StateBase());
        }

    }*/



    public class StateMachine<T> where T : System.Enum
        //o parametro da state machine é um Enum
        //funciona para ser replicavel no jogo ou na maior parte dele
    {



        //chave
        public Dictionary<T, StateBase> dictionaryState; //chave, o que vai ser utilizado

        private StateBase _currentState; //guarda o state atual
        public float timeToStartGame = 1f;


        public StateBase CurrentState
        {
            get { return _currentState; }
        }

        public void Init()
        {
            dictionaryState = new Dictionary<T, StateBase>();
        }


        public void RegisterStates(T typeEnum, StateBase state)
        {
            dictionaryState.Add(typeEnum, state);
        }


        public void SwitchState(T state, params object[] objs) //ao se utilizar o params, pode ser definida uma lista de parametros a serem analisados e lidos
        {

            if (_currentState != null) _currentState.OnStateExit(); //se o state não é null, termina o state atual

            _currentState = dictionaryState[state]; //define novo state

            _currentState.OnStateEnter(objs); //identifica para o objeto o novo state

        }

        public void Update()
        {
            if (_currentState != null) _currentState.OnStateStay(); //se um state nao for null, rodar
        }
    }
}