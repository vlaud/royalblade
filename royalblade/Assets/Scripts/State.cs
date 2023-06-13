using UnityEngine;
namespace playerController
{
    public class StateRun : IState
    {
        public void OperateEnter()
        {

        }

        public void OperateExit()
        {

        }

        public void OperateUpdate()
        {

        }
        public void OperateFixedUpdate()
        {

        }
    }
    public class StateJump : IState
    {
        public void OperateEnter()
        {
            Player.inst.myRigid.AddForce(Vector3.up * 300.0f);
        }

        public void OperateExit()
        {

        }

        public void OperateUpdate()
        {

        }
        public void OperateFixedUpdate()
        {
            Player.inst.OnFall();
        }
    }
    public class StateFall : IState
    {
        public void OperateEnter()
        {

        }

        public void OperateExit()
        {

        }

        public void OperateFixedUpdate()
        {

        }

        public void OperateUpdate()
        {

        }
    }
    public class StateDead : IState
    {
        public void OperateEnter()
        {

        }

        public void OperateExit()
        {

        }

        public void OperateUpdate()
        {

        }
        public void OperateFixedUpdate()
        {

        }
    }
}