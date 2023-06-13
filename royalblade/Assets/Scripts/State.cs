using UnityEngine;

namespace playerController
{
    public class StateRun : IState
    {
        public void OperateEnter()
        {
            Player.inst.SetCamParent(false);
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
            Player.inst.SetCamParent(false);
        }

        public void OperateUpdate()
        {
            
        }
        public void OperateFixedUpdate()
        {
            if (Player.inst.dist > 0.0f)
            {
                Player.inst.SetCamParent(true);
            }
            if (Player.inst.myRigid.velocity.y < 0.0f && Player.inst.player.localPosition.y > 0.1f)
            {
                Player.inst.stateMachine.SetState(PlayerState.Fall);
            }
        }
    }
    public class StateFall : IState
    {
        public void OperateEnter()
        {

        }

        public void OperateExit()
        {
            Player.inst.SetCamParent(false);
        }

        public void OperateFixedUpdate()
        {
            if (Player.inst.dist < -0.9f)
            {
                Player.inst.SetCamParent(true);
            }
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