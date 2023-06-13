using System.Collections.Generic;
using UnityEngine;

//���µ��� �ֻ��� �������̽�.
public interface IState
{
    void OperateEnter();
    void OperateUpdate();
    void OperateFixedUpdate();
    void OperateExit();
}
namespace playerController
{
    public enum PlayerState
    {
        Run,
        Jump,
        Fall,
        Dead
    }
    public class StateMachine
    {
        //���� ���¸� ��� ������Ƽ.
        public IState CurrentState { get; private set; }

        //������Ʈ���� ����
        private Dictionary<PlayerState, IState> dicState = new Dictionary<PlayerState, IState>();

        //�⺻ ���¸� �����ÿ� �����ϰ� ������ �����.
        public StateMachine(PlayerState stateName, IState defaultState)
        {
            AddState(stateName, defaultState);
            CurrentState = GetState(stateName);
        }

        //�ܺο��� ������¸� �ٲ��ִ� �κ�.
        public void SetState(PlayerState stateName)
        {
            //���� �ൿ�� ���̾ �������� ���ϵ��� ����ó��.
            //���� ���, ���� �������ε� �� ������ �ϴ� �������� ���׸� �����Ҽ��� �ִ�.
            if (CurrentState == GetState(stateName))
            {
                Debug.Log("���� �̹� �ش� �����Դϴ�.");
                return;
            }

            //���°� �ٲ�� ����, ���� ������ Exit�� ȣ���Ѵ�.
            CurrentState.OperateExit();

            //���� ��ü.
            CurrentState = GetState(stateName);

            //�� ������ Enter�� ȣ���Ѵ�.
            CurrentState.OperateEnter();
        }
        public void AddState(PlayerState stateName, IState state)
        {
            if(!dicState.ContainsKey(stateName))
            {
                dicState.Add(stateName, state);
            }
        }
        public IState GetState(PlayerState stateName)
        {
            if (dicState.TryGetValue(stateName, out IState state))
                return state;
            return null;
        }
        //�������Ӹ��� ȣ��Ǵ� �Լ�.
        public void DoOperateUpdate()
        {
            CurrentState.OperateUpdate();
        }
        public void DoOperateFixedUpdate()
        {
            CurrentState.OperateFixedUpdate();
        }
    }
}
