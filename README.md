# 日志记录


## 6.18
	1.利用Tag 和刚体增加 Trigger选项进行碰撞检测
	private void OnTriggerEnter2D(Collider2D collision) :unity自己自带，定义了一个名为 OnTriggerEnter2D 的方法，当有物体进入该触发器的范围时会被调用
	if (collision.gameObject.CompareTag("Banana")): 判断进入触发器的物体是否带有 “Banana” 标签
	记得刚体属性勾上trigger 就变成了触发检测

	2. 死亡重生和转化
	if (collision.gameObject.CompareTag("Trap"))：判断碰撞的物体是否带有 “Trap”（陷阱）标签。如果是，则执行死亡逻辑。
	Die();：调用 Die 方法，处理角色的死亡行为。
		player.bodyType = RigidbodyType2D.Static;：将玩家的刚体类型设置为静态，使玩家不再受物理模拟的影响，停止运动。
		anim.SetTrigger("death");：触发动画控制器中的 “death” 触发器，播放死亡动画。
	
	SceneManager.LoadScene(SceneManager.GetActiveScene().name);：使用 SceneManager 加载当前活动场景。通常在角色死亡后经过一段时间调用这个方法来重新开始当前关卡。
	
	动画联系上记得anystate转化到death状态 添加Trigger 触发

	3.  1 人物贴边角落会旋转 2 人物贴墙侧面没法正常掉落 会因为摩擦卡住
	1. 锁住人物Z轴即可（Z轴管旋转）
	2。通过添加组件platform effector 2d 选上 Use one way (含义:只允许单方向碰撞 做跳跃平台必选) 再再Box Collider 2D Used By Effector (选上带入影响) 这样只有单方向上面有碰撞 出现摩擦

## 6.19
	1.通过create empty objects （空结构体） 管理同类预制体 例如banana  spike

	2.通过创建路径点，再设计C#逻辑根据路径点往复循环移动 赋予platform 实现platform往返移动：
		1.路近点如何构造：通过创建empty object(空物体) 右上角赋予颜色改成路径点(游戏里看不到 因为空 )  和 把C#逻辑赋予 	platform 外部接受int[] points 数组 通过增加Element 把empty object 赋予 给与points 位置

	3. 如何让player 跟着踏板一起移动
		类似carmera 绑定player 在player 碰到踏板时候 让player 成为踏板子类 同步移动 离开时候 在解除子类绑定 
	因为是Tigger判断 所以要再添加一个box Collider 2D 进行tigger(为什么要2个box Collider 因为先前 box Cllider Used one way  作为碰撞体 和 trigger冲突，再添加一个相当于2个独立判断？可以解决冲突)
		触发器与碰撞检测的区别 ：在 Unity 中，“Is Trigger”选项决定了 Collider 组件是用于触发事件还是用于物理碰撞检测。
	当“Is Trigger”被勾选时，Collider 会用于触发事件（如 OnTriggerEnter2D、OnTriggerExit2D 等），而不是用于物理碰撞检测。
	而 PlatformEffector2D组件是设计用来与物理碰撞系统交互的，它依赖于 Collider 进行正常的碰撞检测来实现其功能，例如对平台上	  的角色施加力等效果。
