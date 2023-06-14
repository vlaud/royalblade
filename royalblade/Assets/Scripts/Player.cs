using UnityEngine;

namespace playerController
{
    public class Player : Observers
    {
        public static Player inst = null;
        public LayerMask blockMask = default;
        public Transform myCam = null;
        public Transform player = null;
        public Transform stage = null;
        public float dist;
        public StateMachine stateMachine { get; private set;}
        private void Awake()
        {
            inst = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            player = transform;
            stateMachine = new StateMachine(PlayerState.Run, new StateRun());
            stateMachine.AddState(PlayerState.Jump, new StateJump());
            stateMachine.AddState(PlayerState.Fall, new StateFall());
            stateMachine.AddState(PlayerState.Dead, new StateDead());
        }

        // Update is called once per frame
        void Update()
        {
            //매프레임 실행해야하는 동작 호출.
            stateMachine.DoOperateUpdate();
        }
        private void FixedUpdate()
        {
            dist = player.position.y - myCam.position.y;
            stateMachine.DoOperateFixedUpdate();
        }
        public void OnJump()
        {
            if (stateMachine.CurrentState == stateMachine.GetState(PlayerState.Run))
            {
                Debug.Log("jump " + stateMachine.CurrentState);
                stateMachine.SetState(PlayerState.Jump);
            }
        }
        public void OnBlock()
        {
            if(myTarget != null) myTarget.GetComponent<Observer>().Notified(AttackState.Block);
        }
        public void OnAttack()
        {
            if (myTarget != null) myTarget.GetComponent<Observer>().Notified(AttackState.Attack);
        }
        public void SetCamParent(bool v)
        {
            if (v) myCam.SetParent(player);
            else myCam.SetParent(stage);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
                stateMachine.SetState(PlayerState.Run);

            if ((blockMask & 1 << collision.gameObject.layer) != 0)
            {
                if (myTarget != collision.transform) myTarget = collision.transform;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if ((blockMask & 1 << collision.gameObject.layer) != 0)
            {
                if (myTarget == collision.transform) myTarget = null;
            }
        }
    }
}