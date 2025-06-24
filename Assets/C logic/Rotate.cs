using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotate : MonoBehaviour
{
    // [SerializeField]属性用于在Inspector面板中显示私有变量speed
    [SerializeField] private float speed = 2f; // 定义一个初始值为2的私有float变量speed，用于控制旋转速度

    // Start()方法在脚本第一次被调用时执行，用于初始化操作
    void Start()
    {

    }

    // Update()方法在每一帧都调用一次，用于持续性的操作和更新
    void Update()
    {
        // 调用transform.Rotate()方法使物体围绕其z轴进行旋转 因为是2d
        // 0表示x轴旋转角度，0表示y轴旋转角度，360 * speed * Time.deltaTime表示z轴旋转角度
        // Time.deltaTime获取帧与帧之间的时间差，确保旋转速度与帧率无关
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
