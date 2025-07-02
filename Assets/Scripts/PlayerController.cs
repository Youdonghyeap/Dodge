using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour // 이동에 사용할 리지드바디 컴포넌트
{
public Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
public float speed = 8f; // 이동 속도 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveZ += 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveZ -= 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX -= 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX += 1f;
        }
        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized * speed;
        playerRigidbody.linearVelocity = new Vector3(move.x, playerRigidbody.linearVelocity.y, move.z);
    }
}
