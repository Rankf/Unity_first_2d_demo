using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatforms : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����ײ����Ϸ�����Ƿ�����ң�ͨ������ƥ�䣩
        if (collision.gameObject.name == "Player")
        {
            // ����Ҷ�������Ϊ��ƽ̨���Ӷ���ʵ������Ч����
            collision.gameObject.transform.SetParent(transform);
        }
    }
    // ������Collider2D����Ϸ�����뿪��ƽ̨�Ĵ���������ʱ����
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ����뿪��ײ����Ϸ�����Ƿ�����ң�ͨ������ƥ�䣩
        if (collision.gameObject.name == "Player")
        {
            // ����Ҷ����ƽ̨���Ӷ������Ƴ����������Ч����
            collision.gameObject.transform.SetParent(null);
        }
    }
}
