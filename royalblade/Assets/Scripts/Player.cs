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
        public float blockPower = 600.0f;
        public float fillAttack = 0.1f;
        public float fillBlock = 0.4f;
        public float jumpPower = 300.0f;
        public float limitVelocity = 5.0f;
        public Detection detection = null;
        public StateMachine stateMachine { get; private set;}
        private void Awake()
        {
            inst = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            player = transform;
            detection.SetLayer(blockMask);
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
        public void OnJumpUltimate()
        {
            stateMachine.SetState(PlayerState.Jump);
            myRigid.AddForce(Vector3.up * jumpPower * 2.0f);
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
        public override void FindTarget(Transform target)
        {
            myTarget = target;
            myTarget.GetComponent<Detect>().FindTarget(transform);
        }
        public override void LostTarget()
        {
            myTarget = null;
            detection.myTarget = null;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
                stateMachine.SetState(PlayerState.Run);
        }
    }
}