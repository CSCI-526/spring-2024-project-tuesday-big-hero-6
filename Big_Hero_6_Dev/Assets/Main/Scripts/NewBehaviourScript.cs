using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 控制移动速度
    private Rigidbody2D rb; // 角色的Rigidbody2D组件
    private Vector2 movement; // 存储移动方向
    public TextMeshProUGUI winGameText; // 确保在Unity编辑器中设置这个引用


    // 在Start方法中获取Rigidbody2D组件
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 在Update方法中处理输入
    void Update()
    {
        // 获取水平和垂直输入（使用默认的“Horizontal”和“Vertical”输入轴）
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 检查是否满足过关条件
        CheckIfLevelCompleted();
    }

    // 在FixedUpdate中应用移动，以保证与物理更新同步
    void FixedUpdate()
    {
        // 移动角色
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void CheckIfLevelCompleted()
    {
        // 假设过关的位置条件是 x 接近 3.65，y 大于 3.6
        if (Mathf.Abs(transform.position.x - 4.8f) < 0.1f && transform.position.y > 3.6f)
        {
            // 检查是否拥有两个钥匙
            if (Global.yellowKey && Global.redKey)
            {
                Debug.Log("过关成功！");
                // 这里可以添加更多的过关逻辑，比如加载下一个关卡等
                // 例如：SceneManager.LoadScene("NextLevelName");
                // 暂停游戏
                Time.timeScale = 0;
                // 显示过关文本
                winGameText.enabled = true;
            }
        }
    }
}
