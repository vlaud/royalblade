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
        //������Ʈ���� ����
        private Dictionary<PlayerState, IState> dicState = new Dictionary<PlayerState, IState>();
        private void Awake()
        {
            inst = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            //���� ����
            IState run = new StateRun();
            IState jump = new StateJump();
            IState fall = new StateFall();
            IState dead = new StateDead();

            //Ű�Է� � ���� ������ ���¸� ���� �� �� �ְ� ��ųʸ��� ����
            dicState.Add(PlayerState.Run, run);
            dicState.Add(PlayerState.Jump, jump);
            dicState.Add(PlayerState.Fall, fall);
            dicState.Add(PlayerState.Dead, dead);

            //�⺻���´� �޸���� ����.
            stateMachine = new StateMachine(run);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log(stateMachine.CurrentState);
            }
            //�������� �����ؾ��ϴ� ���� ȣ��.
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