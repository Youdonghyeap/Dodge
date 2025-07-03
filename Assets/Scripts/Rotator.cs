using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f; // 회전 속도
    private bool isClockwise = true; // 시계 방향 여부
    private float changeInterval; // 방향이 바뀌는 간격
    private float timeSinceChange = 0f;

    void Start()
    {
        SetRandomInterval();
    }

    void Update()
    {
        timeSinceChange += Time.deltaTime;
        if (timeSinceChange >= changeInterval)
        {
            isClockwise = Random.value > 0.5f;
            SetRandomInterval();
            timeSinceChange = 0f;
        }
        float direction = isClockwise ? 1f : -1f;
        transform.Rotate(0f, rotationSpeed * direction * Time.deltaTime, 0f);
    }

    void SetRandomInterval()
    {
        changeInterval = Random.Range(1f, 3f); // 1~3초 사이 랜덤
    }
}
