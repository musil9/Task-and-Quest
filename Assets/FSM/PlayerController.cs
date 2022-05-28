using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// if 문 FSM

public enum PlayerState { Idle,Walk,Run,Attack}
public class PlayerController : MonoBehaviour
{
    private PlayerState playerState;

    private bool isChanged = false;
    private void Awake()
    {
        ChangeState(PlayerState.Idle);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeState(PlayerState.Idle);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            ChangeState(PlayerState.Walk);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeState(PlayerState.Run);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(PlayerState.Attack);
        }

        //UpdateState();
    }

    private void UpdateState()
    {
        if(playerState == PlayerState.Idle)
        {
            if(isChanged)
            {
                Debug.Log("비전투");
                Debug.Log("체력/마력 회복");

                isChanged = false;

            }
            Debug.Log("대기");
        }
        else if (playerState == PlayerState.Walk)
        {
            if (isChanged)
            {
                Debug.Log("이동속도 변경 2");
          

                isChanged = false;

            }
            Debug.Log("걷기");
        }
        else if (playerState == PlayerState.Run)
        {
            if (isChanged)
            {
          
                Debug.Log("이동 속도 변경 5");

                isChanged = false;

            }
            Debug.Log("달리기");
        }
        else if (playerState == PlayerState.Attack)
        {
            if (isChanged)
            {
                Debug.Log("전투");
                Debug.Log("자동 회복 중지");

                isChanged = false;

            }
            Debug.Log("공격");
        }

        switch(playerState)
        {
            case PlayerState.Idle:
                Debug.Log("대기");
                break;
            case PlayerState.Walk:
                Debug.Log("걷기");
                break;
            case PlayerState.Run:
                Debug.Log("달리기");
                break;
            case PlayerState.Attack:
                Debug.Log("공격");
                break;
        }
    }

    private void ChangeState(PlayerState newState)
    {
        //playerState = newState;
        //isChanged = true;

        StopCoroutine(playerState.ToString());

        playerState = newState;

        StartCoroutine(playerState.ToString());
    }

    private IEnumerator Idle()
    {
        // 1회 호출
        Debug.Log("비전투");
        Debug.Log("체력/마력 회복");

        // 매 프레임 호출
        while(true)
        {
            Debug.Log("대기");
            yield return null;
        }
    }

    private IEnumerator Walk()
    {    // 1회 호출
        Debug.Log("이동속도 변경 2");

        // 매 프레임 호출
        while (true)
        {
            Debug.Log("플레이어 이동 구현");
            yield return null;
        }
    }

    private IEnumerator Run()
    {    
        // 1회 호출
        Debug.Log("이동속도 변경 5");

        // 매 프레임 호출
        while (true)
        {
            Debug.Log("플레이어 달리기 구현");
            yield return null;
        }
    }

    private IEnumerator Attack()
    {    // 1회 호출
        Debug.Log("전투 모드 변경");
        Debug.Log("체력/마력 회복 중지");

        // 매 프레임 호출
        while (true)
        {
            Debug.Log("공격 구현");
            yield return null;
        }
    }
}
