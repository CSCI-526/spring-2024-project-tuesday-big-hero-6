using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThronController : MonoBehaviour, ITriggerable
{
    public float moveDistance = -20f; // 移动距离
    public float moveSpeed = 3f; // 移动速度
    private Vector3 originalPosition; // 原始位置
    private Vector3 targetPosition; // 目标位置
    public bool isOpening = false; // 是否正在打开
    public GameObject visibleFloor;
    public GameObject[] traps;

    void Start()
    {
        originalPosition = transform.position; // 保存原始位置
        targetPosition = originalPosition + new Vector3(0, moveDistance, 0); // 计算目标位置
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(3);
        transform.position = originalPosition;
        isOpening = false;
        visibleFloor.SetActive(true);
        foreach (var trap in traps)
        {
            trap.SetActive(false);
        }
    }

    void Update()
    {
        if (isOpening)
        {
            // 移动门到目标位置
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            StartCoroutine(ResetPosition());
        }
    }

    public void Trigger()
    {
        Debug.Log("Door trigger called.");
        isOpening = true; // 触发打开门
    }
}
