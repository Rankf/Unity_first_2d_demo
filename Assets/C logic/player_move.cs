using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    //变量声明 
    private Rigidbody2D player;//人物变量
    private BoxCollider2D coll;//获取碰撞体
    private SpriteRenderer sprite;
    private Animator anim;


    [SerializeField] private LayerMask jumpableGround;//跳跃平面 碰到了才能跳
    private float dirX = 0f;//基础参数
    [SerializeField] private float moveSpeed = 7f;//支持外部参数调整横向移动速率
    [SerializeField] private float jumpSpeed = 7f;

    //状态体 
    private enum MovementState {idle,running,jumping,failing }

    // Start is called before the first frame update //初始化
    void Start()
    {
        player = GetComponent<Rigidbody2D>();//获取绑定对象的Rigidbody2D体
        sprite = GetComponent<SpriteRenderer>();//SpriteRenderer sprite：用于控制角色的精灵渲染器，可以翻转角色的朝向。
        anim = GetComponent<Animator>();//获取动作联系参数
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame //反复更新
    void Update()
    {
        //利用unity edit 的 project Settings 的input Manager 的提前设置好函数 获取移动
        //左右水平移动
        dirX = Input.GetAxisRaw("Horizontal");//获取水平移动操作
        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y); //速度分量
        if (Input.GetButtonDown("Jump") && IsGrounded())//获取内置jump,必须接触地面才能再次跳跃
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        UpdateAnimationState();//每次操作后调用UpdateAnimationState 更新动画状态

    }
    void UpdateAnimationState() 
    {
        //根据状态变化
        MovementState state;
        if(dirX > 0f) 
        {
            state = MovementState.running;
            sprite.flipX = false; // 设置角色朝向右侧
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true; // 设置角色朝向左侧
        }
        else 
        {
            state = MovementState.idle;
        }

        if(player.velocity.y > .1f) // 为何不是大于0 而是大于.1f 超出0界之 防止避免误判 为了使角色的动画过渡更加平滑自然，在角色从静止到跳跃的过程中，可能希望角色的速度达到一定的值后再切换到跳跃动画，
        {
            state = MovementState.jumping;
        }
        else if(player.velocity.y < -.1f)
        {
            state = MovementState.failing;
        }

        anim.SetInteger("state", (int)state);//把赋值传出去
    }

    private bool IsGrounded()
    {
        /*
         * coll.bounds.center：角色的碰撞体（Collider2D）的边界中心点位置，表示检测的起始位置。
            coll.bounds.size：角色的碰撞体边界大小，用于确定检测的矩形区域的大小。
            0f：表示旋转角度，这里为 0 度，即检测方向不进行旋转。
            Vector2.down：表示检测方向为竖直向下方向，这是判断角色是否在地面上的关键方向，因为通常角色在地面上时，其下方会有地面碰撞体。
            .1f：表示射线的长度，即从角色碰撞体边界中心点向下检测的距离为 0.1 单位。
            jumpableGround：这是一个图层遮罩（LayerMask），用于指定哪些图层上的碰撞体可以被认为是可跳跃的地面。只有在这些图层上的碰撞体与检测的矩形区域发生相交时，才会认为角色处于地面状态。
         */
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,jumpableGround);
    }
}