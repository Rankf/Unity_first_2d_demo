using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollect : MonoBehaviour
{
    private int bananas = 0;
    [SerializeField] private Text bananasText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Trigger ����������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����ײ�������Ƿ���� "Banana" ��ǩ
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);//�ٻ���ײ��
            bananas++;
            // ���� UI �ı���ʾ��ǰ���㽶����
            bananasText.text = "Bananas:" + bananas;
        }
    }
}
