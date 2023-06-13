using System.Collections.Generic;
using UnityEngine;

namespace playerController
{
    public class Player : CharacterProperty
    {
        public static Player inst = null;
        private enum PlayerState
        {
            Run,
            Jump,
            Fall,
            Dead
        }

        private StateMachine stateMachine;
        //스테이트들을 보관
        private Dictionary<PlayerState, IState> dicState = new Dictionary<PlayerState, IState>();
        private void Awake()
        {
            inst = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            //상태 생성
            IState run = new StateRun();
            IState jump = new StateJump();
            IState fall = new StateFall();
            IState dead = new StateDead();

            //키입력 등에 따라서 언제나 상태를 꺼내 쓸 수 있게 딕셔너리에 보관
            dicState.Add(PlayerState.Run, run);
            dicState.Add(PlayerState.Jump, jump);
            dicState.Add(PlayerState.Fall, fall);
            dicState.Add(PlayerState.Dead, dead);

            //기본상태는 달리기로 설정.
            stateMachine = new StateMachine(run);
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
            if (stateMachine.CurrentState == dicState[PlayerState.Run])
            {
                stateMachine.SetState(dicState[PlayerState.Jump]);
            }
        }
        public void OnFall()
        {
            if (myRigid.velocity.y < 0f)
            {
                stateMachine.SetState(dicState[PlayerState.Fall]);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            stateMachine.SetState(dicState[PlayerState.Run]);
        }
    }
}