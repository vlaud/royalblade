using System.Collections.Generic;
using UnityEngine;

//상태들의 최상위 인터페이스.
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
        //현재 상태를 담는 프로퍼티.
        public IState CurrentState { get; private set; }

        //스테이트들을 보관
        private Dictionary<PlayerState, IState> dicState = new Dictionary<PlayerState, IState>();

        //기본 상태를 생성시에 설정하게 생성자 만들기.
        public StateMachine(PlayerState stateName, IState defaultState)
        {
            AddState(stateName, defaultState);
            CurrentState = GetState(stateName);
        }

        //외부에서 현재상태를 바꿔주는 부분.
        public void SetState(PlayerState stateName)
        {
            //같은 행동을 연이어서 세팅하지 못하도록 예외처리.
            //예를 들어, 지금 점프중인데 또 점프를 하는 무한점프 버그를 예방할수도 있다.
            if (CurrentState == GetState(stateName))
            {
                Debug.Log("현재 이미 해당 상태입니다.");
                return;
            }

            //상태가 바뀌기 전에, 이전 상태의 Exit를 호출한다.
            CurrentState.OperateExit();

            //상태 교체.
            CurrentState = GetState(stateName);

            //새 상태의 Enter를 호출한다.
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
        //매프레임마다 호출되는 함수.
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
