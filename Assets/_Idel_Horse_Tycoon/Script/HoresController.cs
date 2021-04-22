using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class HoresController : MonoBehaviour
{
    public MapManagment mapManagment;
    public Transform[] Targtes;
    public Transform SpawnPos;
    [HideInInspector]
    public Vector3 Currat_target_pos;

    public bool TempHores;
    public bool IsFastHores;

    //public float Rotationspeed;
    public float TargetRadios;
    public float RandomTargetRadios;

    public int poscounter = 0;
    //private float _Rotationspeed;
    private float _TargetRadios;
    private float _RandomTargetRadios;

    public float Speed;

    [SerializeField] float m_MovingTurnSpeed = 360;
    [SerializeField] float m_StationaryTurnSpeed = 180;

    private NavMeshAgent NavMeshAgent;
    private ThirdPersonCharacter thirdPersonCharacter;

    private bool DestrildAfterArraiwDestination;

    float m_TurnAmount;
    float m_ForwardAmount;


    // Start is called before the first frame update
    void Start()
    {
        if (Currat_target_pos == Vector3.zero)
            Currat_target_pos = Targtes[poscounter].position;

        // _Rotationspeed = Rotationspeed;
        _TargetRadios = TargetRadios;
        _RandomTargetRadios = RandomTargetRadios;

        NavMeshAgent = GetComponent<NavMeshAgent>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();

        NavMeshAgent.updateRotation = false;
        // NavMeshAgent.updatePosition = false;

        FastRun();
        CancelInvoke("SlowRun");
        Invoke("SlowRun", Random.Range(2,4));
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(Currat_target_pos, transform.position) < TargetRadios)
        {
            if (DestrildAfterArraiwDestination)
            {
                mapManagment.mapData.AllHoresList.Remove(GetComponent<HoresController>());

                Destroy(gameObject);
            }

            poscounter++;

            if (TempHores)
            {
                if (poscounter >= Targtes.Length && Plus_2_Hores_Managment.TimerCounter <= 0)
                {
                    poscounter = 0;
                    TargetRadios = 0.5f;
                    _TargetRadios = 0.5f;
                    Currat_target_pos = SpawnPos.position;
                    DestrildAfterArraiwDestination = true;

                }
                else if (poscounter >= Targtes.Length)
                {
                    poscounter = 0;
                    Currat_target_pos = new Vector3(Random.Range(Targtes[poscounter].position.x - RandomTargetRadios, Targtes[poscounter].position.x + RandomTargetRadios), Targtes[poscounter].position.y, Random.Range(Targtes[poscounter].position.z - RandomTargetRadios, Targtes[poscounter].position.z + RandomTargetRadios));

                }
                else
                {
                    Currat_target_pos = new Vector3(Random.Range(Targtes[poscounter].position.x - RandomTargetRadios, Targtes[poscounter].position.x + RandomTargetRadios), Targtes[poscounter].position.y, Random.Range(Targtes[poscounter].position.z - RandomTargetRadios, Targtes[poscounter].position.z + RandomTargetRadios));

                }

            }
            else
            {
                if (poscounter >= Targtes.Length)
                    poscounter = 0;

                Currat_target_pos = new Vector3(Random.Range(Targtes[poscounter].position.x - RandomTargetRadios, Targtes[poscounter].position.x + RandomTargetRadios), Targtes[poscounter].position.y, Random.Range(Targtes[poscounter].position.z - RandomTargetRadios, Targtes[poscounter].position.z + RandomTargetRadios));
            }

            //  Currat_target_pos = Targtes[poscounter].position;
        }

      //  var targetRotation = Quaternion.LookRotation(Currat_target_pos - transform.position);
        //  transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,targetRotation.eulerAngles.y,0), Rotationspeed * Time.deltaTime);


        if (gameObject.activeSelf)
        {

            NavMeshAgent.SetDestination(Currat_target_pos);

            NavMeshAgent.speed = 2 * Speed;

            //if (NavMeshAgent.remainingDistance > NavMeshAgent.stoppingDistance)
            //    thirdPersonCharacter.Move(NavMeshAgent.desiredVelocity, Speed, false, false);
            //else
            //    thirdPersonCharacter.Move(Vector3.zero, 1, false, false)



            if (NavMeshAgent.remainingDistance > NavMeshAgent.stoppingDistance)
                Move(NavMeshAgent.desiredVelocity, Speed);
            else
                Move(Vector3.zero,1);

        }


        if (BootTime_Managment.IsActive || IsFastHores)
        {

            CancelInvoke("SlowRun");
            FastRun();
            Invoke("SlowRun", 1);

        }
    }

    public void FastRun(int time)
    {


        if (GameManager.GameTutorial == 0)
            UiManager.inst.Hand.SetActive(false);
        //    GameManager.GameTutorial++;

        // GetComponent<Animator>().SetBool("FastRun", true);
        // CancelInvoke("SlowRun");

        FastRun();
        CancelInvoke("SlowRun");
        Invoke("SlowRun", time);

    }
    public void FastRun()
    {

        Speed = 2.5f;
        TargetRadios = 3;
        RandomTargetRadios = 0;
        NavMeshAgent.acceleration = 15;
    }

    private void SlowRun()
    {

        //GetComponent<Animator>().SetBool("FastRun", false);
        //Rotationspeed = _Rotationspeed;
        TargetRadios = _TargetRadios;
        RandomTargetRadios = _RandomTargetRadios;

        Speed = 1;
        NavMeshAgent.acceleration = 10;

    }

    public void Move(Vector3 move,float speed)
    {

        // convert the world relative moveInput vector into a local-relative
        // turn amount and forward amount required to head in the desired
        // direction.
        if (move.magnitude > 1f)
            move.Normalize();


        move = transform.InverseTransformDirection(move);

        m_TurnAmount = Mathf.Atan2(move.x, move.z)*speed;
        m_ForwardAmount = move.z * speed;

        Animator m_Animator = GetComponent<Animator>();

        m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);

        ApplyExtraTurnRotation();
    }
    void ApplyExtraTurnRotation()
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }
}


