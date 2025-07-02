using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float minSpeed = 4f; // 총알 최소 속도
    public float maxSpeed = 8f; // 총알 최대 속도
    public float speed; // 총알 속도 (기본값)
    private Rigidbody bulletRigidbody; // 총알의 리지드바디 컴포넌트

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>(); // 총알의 리지드바디 컴포넌트를 가져옴
        speed = Random.Range(minSpeed, maxSpeed); // 속도를 랜덤으로 지정
        bulletRigidbody.linearVelocity = transform.forward * speed; // 총알을 발사 방향으로 초기 속도 설정
        Destroy(gameObject, 3f); // 3초 후에 총알 오브젝트를 파괴
    }

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트를 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if (playerController != null)
            {
                //상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
