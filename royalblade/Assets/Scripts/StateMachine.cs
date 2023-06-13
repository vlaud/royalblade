using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���µ��� �ֻ��� �������̽�.
public interface IState
{
    void OperateEnter();
    void OperateUpdate();
    void OperateExit();
}
namespace playerController
{
    public class StateMachine
    {
        //���� ���¸� ��� ������Ƽ.
        public IState CurrentState { get; private set; }

        //�⺻ ���¸� �����ÿ� �����ϰ� ������ �����.
        public StateMachine(IState defaultState)
        {
            CurrentState = defaultState;
        }

        //�ܺο��� ������¸� �ٲ��ִ� �κ�.
        public void SetState(IState state)
        {
            //���� �ൿ�� ���̾ �������� ���ϵ��� ����ó��.
            //���� ���, ���� �������ε� �� ������ �ϴ� �������� ���׸� �����Ҽ��� �ִ�.
            if (CurrentState == state)
            {
                Debug.Log("���� �̹� �ش� �����Դϴ�.");
                return;
            }

            //���°� �ٲ�� ����, ���� ������ Exit�� ȣ���Ѵ�.
            CurrentState.OperateExit();

            //���� ��ü.
            CurrentState = state;

            //�� ������ Enter�� ȣ���Ѵ�.
            CurrentState.OperateEnter();
        }

        //�������Ӹ��� ȣ��Ǵ� �Լ�.
        public void DoOperateUpdate()
        {
            CurrentState.OperateUpdate();
        }
    }
}
