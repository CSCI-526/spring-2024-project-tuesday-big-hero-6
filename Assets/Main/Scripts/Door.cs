using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool hasMoved = false;

    void Update()
    {
        if (Global.yellowKey && !hasMoved)
        {
            StartCoroutine(MoveDoorDown(1.6f));
            hasMoved = true;
        }
    }

    IEnumerator MoveDoorDown(float distance)
    {
        Vector3 targetPosition = transform.position + new Vector3(0, -distance, 0);
        float timeToMove = 1.0f;
        float elapsedTime = 0;
        Vector3 startPosition = transform.position;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
