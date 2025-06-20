using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // ����һ�����ڴ洢·�������Ϸ��������
    private int currentWaypointIndex = 0; // ��ǰ·�������������ʼ��Ϊ0

    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //��Ӵ��󱨸�
        if (waypoints.Length == 0)
        {
            Debug.LogError("Waypoints array is empty!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Ϊ���������Զ�ѭ�������ƶ���ֻ�ƶ�һ�ξͲ��ûָ�0 ��
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position,transform.position) < .1f)// ��鵱ǰ��Ϸ�����뵱ǰ·����֮��ľ����Ƿ�С��0.1����ʾ�ӽ�·���㣩
        {
            currentWaypointIndex ++;//����
            // �����ǰ·��������������·��������ĳ��ȣ�����Ϊ��һ��·����������ѭ���ƶ���
            if (currentWaypointIndex >= waypoints.Length)//����ĩβ
            {
                currentWaypointIndex = 0;//�ص����
            }
            
        }
        // �ƶ���Ϸ��������һ��·����λ�� speed �ٶ�
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
