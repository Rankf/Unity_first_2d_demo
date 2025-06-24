using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate : MonoBehaviour
{
    // [SerializeField]����������Inspector�������ʾ˽�б���speed
    [SerializeField] private float speed = 2f; // ����һ����ʼֵΪ2��˽��float����speed�����ڿ�����ת�ٶ�

    // Start()�����ڽű���һ�α�����ʱִ�У����ڳ�ʼ������
    void Start()
    {

    }

    // Update()������ÿһ֡������һ�Σ����ڳ����ԵĲ����͸���
    void Update()
    {
        // ����transform.Rotate()����ʹ����Χ����z�������ת ��Ϊ��2d
        // 0��ʾx����ת�Ƕȣ�0��ʾy����ת�Ƕȣ�360 * speed * Time.deltaTime��ʾz����ת�Ƕ�
        // Time.deltaTime��ȡ֡��֮֡���ʱ��ȷ����ת�ٶ���֡���޹�
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
