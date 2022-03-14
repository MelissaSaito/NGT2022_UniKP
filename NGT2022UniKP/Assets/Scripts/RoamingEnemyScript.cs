using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class RoamingEnemyScript : MonoBehaviour
{
    [SerializeField] [Tooltip("���񂷂�n�_�̔z��")] private Transform[] waypoints;
    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;
    private float enemySpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemySpeed;
        // �ŏ��̖ړI�n������
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        // �ړI�n�_�܂ł̋���(remainingDistance)���ړI�n�̎�O�܂ł̋���(stoppingDistance)�ȉ��ɂȂ�����
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // �ړI�n�̔ԍ����P�X�V�i�E�ӂ���]���Z�q�ɂ��邱�ƂŖړI�n�����[�v�������j
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            // �ړI�n�����̏ꏊ�ɐݒ�
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    //Player�𔭌�������
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("��������!!");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.speed = 0.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.speed = enemySpeed;
        }
    }
}
