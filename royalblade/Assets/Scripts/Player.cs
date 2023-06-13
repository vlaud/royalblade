using System.Collections.Generic;
using UnityEngine;

namespace playerController
{
    public class Player : CharacterProperty
    {
        public static Player inst = null;
        public Transform myCam = null;
        

        public StateMachine stateMachine { get; private set;}
        private void Awake()
        {
            inst = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            stateMachine = new StateMachine(PlayerState.Run, new StateRun());
            stateMachine.AddState(PlayerState.Jump, new StateJump());
            stateMachine.AddState(PlayerState.Fall, new StateFall());
            stateMachine.AddState(PlayerState.Dead, new StateDead());
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log(stateMachine.CurrentState);
            }
            //매프레임 실행해야하는 동작 호출.
            stateMachine.DoOperateUpdate();
        }
        private void FixedUpdate()
        {
            stateMachine.DoOperateFixedUpdate();
        }
        public void OnJump()
        {
            if(stateMachine.CurrentState == stateMachine.GetState(PlayerState.Run))
            {
                stateMachine.SetState(PlayerState.Jump);
            }
        }
       
        private void OnCollisionEnter(Collision collision)
        {
            stateMachine.SetState(PlayerState.Run);
        }
    }
}