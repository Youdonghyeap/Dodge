using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float survivalTime;
    private bool isGameover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        survivalTime = 0f;
        isGameover = false;
        gameoverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            survivalTime += Time.deltaTime;
            timeText.text = "Time : " + (int)survivalTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // 게임 오버 상태에서 R 키를 누르면 게임을 재시작
                RestartGame();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true); // 게임 오버 텍스트 활성화
        float bestRecord = PlayerPrefs.GetFloat("BestRecord"); // 저장된 최고 기록 불러오기

        if (survivalTime > bestRecord)
        {
            bestRecord = survivalTime;
            PlayerPrefs.SetFloat("BestRecord", bestRecord); // 새로운 최고 기록 저장
        }
        recordText.text = "Best Record : " + (int)bestRecord;
    }
}
