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
    }
    public class StateJump : IState
    {
        public void OperateEnter()
        {
            Player.inst.myRigid.AddForce(Vector3.up * 300.0f);
            //myRigid.AddForce(Vector3.up * 300.0f);
        }

        public void OperateExit()
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
    }
}