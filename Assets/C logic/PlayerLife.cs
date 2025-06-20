using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D player; // ��ҵĸ�������������������
    private Animator anim; // ��ҵĶ������

    // Start ��������Ϸ��ʼǰ����һ��
    void Start()
    {
        player = GetComponent<Rigidbody2D>(); // ��ȡ��ҵ� Rigidbody2D ���
        anim = GetComponent<Animator>();     // ��ȡ��ҵ� Animator ���
    }

    // Update ����ÿ֡����һ��
    void Update()
    {

    }

    // ��ײ��ⷽ�������ڴ������֮�����ײ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����ײ�������Ƿ���� "Trap"�����壩��ǩ
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die(); // ������������
        }
    }

    // ��������
    private void Die()
    {
        player.bodyType = RigidbodyType2D.Static; // ����ҵĸ���������Ϊ��̬��ֹͣ�����˶���
        anim.SetTrigger("death"); // ���������е� "death" ��������������������
    }

    // ���¼��عؿ��ķ���
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
