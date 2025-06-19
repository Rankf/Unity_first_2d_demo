using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    //�������� 
    private Rigidbody2D player;//�������
    private BoxCollider2D coll;//��ȡ��ײ��
    private SpriteRenderer sprite;
    private Animator anim;


    [SerializeField] private LayerMask jumpableGround;//��Ծƽ�� �����˲�����
    private float dirX = 0f;//��������
    [SerializeField] private float moveSpeed = 7f;//֧���ⲿ�������������ƶ�����
    [SerializeField] private float jumpSpeed = 7f;

    //״̬�� 
    private enum MovementState {idle,running,jumping,failing }

    // Start is called before the first frame update //��ʼ��
    void Start()
    {
        player = GetComponent<Rigidbody2D>();//��ȡ�󶨶����Rigidbody2D��
        sprite = GetComponent<SpriteRenderer>();//SpriteRenderer sprite�����ڿ��ƽ�ɫ�ľ�����Ⱦ�������Է�ת��ɫ�ĳ���
        anim = GetComponent<Animator>();//��ȡ������ϵ����
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame //��������
    void Update()
    {
        //����unity edit �� project Settings ��input Manager ����ǰ���úú��� ��ȡ�ƶ�
        //����ˮƽ�ƶ�
        dirX = Input.GetAxisRaw("Horizontal");//��ȡˮƽ�ƶ�����
        player.velocity = new Vector2(dirX * moveSpeed, player.velocity.y); //�ٶȷ���
        if (Input.GetButtonDown("Jump") && IsGrounded())//��ȡ����jump,����Ӵ���������ٴ���Ծ
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        UpdateAnimationState();//ÿ�β��������UpdateAnimationState ���¶���״̬

    }
    void UpdateAnimationState() 
    {
        //����״̬�仯
        MovementState state;
        if(dirX > 0f) 
        {
            state = MovementState.running;
            sprite.flipX = false; // ���ý�ɫ�����Ҳ�
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true; // ���ý�ɫ�������
        }
        else 
        {
            state = MovementState.idle;
        }

        if(player.velocity.y > .1f) // Ϊ�β��Ǵ���0 ���Ǵ���.1f ����0��֮ ��ֹ�������� Ϊ��ʹ��ɫ�Ķ������ɸ���ƽ����Ȼ���ڽ�ɫ�Ӿ�ֹ����Ծ�Ĺ����У�����ϣ����ɫ���ٶȴﵽһ����ֵ�����л�����Ծ������
        {
            state = MovementState.jumping;
        }
        else if(player.velocity.y < -.1f)
        {
            state = MovementState.failing;
        }

        anim.SetInteger("state", (int)state);//�Ѹ�ֵ����ȥ
    }

    private bool IsGrounded()
    {
        /*
         * coll.bounds.center����ɫ����ײ�壨Collider2D���ı߽����ĵ�λ�ã���ʾ������ʼλ�á�
            coll.bounds.size����ɫ����ײ��߽��С������ȷ�����ľ�������Ĵ�С��
            0f����ʾ��ת�Ƕȣ�����Ϊ 0 �ȣ�����ⷽ�򲻽�����ת��
            Vector2.down����ʾ��ⷽ��Ϊ��ֱ���·��������жϽ�ɫ�Ƿ��ڵ����ϵĹؼ�������Ϊͨ����ɫ�ڵ�����ʱ�����·����е�����ײ�塣
            .1f����ʾ���ߵĳ��ȣ����ӽ�ɫ��ײ��߽����ĵ����¼��ľ���Ϊ 0.1 ��λ��
            jumpableGround������һ��ͼ�����֣�LayerMask��������ָ����Щͼ���ϵ���ײ����Ա���Ϊ�ǿ���Ծ�ĵ��档ֻ������Щͼ���ϵ���ײ������ľ����������ཻʱ���Ż���Ϊ��ɫ���ڵ���״̬��
         */
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,jumpableGround);
    }
}