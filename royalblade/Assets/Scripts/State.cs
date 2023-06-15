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
            float addPower = ButtonManager.instance.jumpButton.myImage.fillAmount + 1.0f;
            Debug.Log(addPower);
            Player.inst.myRigid.AddForce(Vector3.up * Player.inst.jumpPower * addPower);
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
            if (Mathf.Abs(Player.inst.myRigid.velocity.y) > Player.inst.limitVelocity) // 가속도가 5 이상이라면
                Player.inst.myRigid.velocity = new Vector3(Player.inst.myRigid.velocity.x, Mathf.Sign(Player.inst.myRigid.velocity.y) 
                    * Player.inst.limitVelocity, Player.inst.myRigid.velocity.z); //가속도 제한
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