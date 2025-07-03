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
        // 수평과 수직 축 입력 값을 감지
        float xInput = Input.GetAxis("Horizontal"); // 좌우 입력
        float zInput = Input.GetAxis("Vertical"); // 상하 입력

        // 실제 이동 속도를 입력 값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed; // x축 이동 속도
        float zSpeed = zInput * speed; // z축 이동 속도

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity를 할당
        playerRigidbody.linearVelocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false); // 플레이어 오브젝트를 비활성화
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.EndGame();
        }
    }
    }
