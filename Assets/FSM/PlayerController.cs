using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// if �� FSM

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
                Debug.Log("������");
                Debug.Log("ü��/���� ȸ��");

                isChanged = false;

            }
            Debug.Log("���");
        }
        else if (playerState == PlayerState.Walk)
        {
            if (isChanged)
            {
                Debug.Log("�̵��ӵ� ���� 2");
          

                isChanged = false;

            }
            Debug.Log("�ȱ�");
        }
        else if (playerState == PlayerState.Run)
        {
            if (isChanged)
            {
          
                Debug.Log("�̵� �ӵ� ���� 5");

                isChanged = false;

            }
            Debug.Log("�޸���");
        }
        else if (playerState == PlayerState.Attack)
        {
            if (isChanged)
            {
                Debug.Log("����");
                Debug.Log("�ڵ� ȸ�� ����");

                isChanged = false;

            }
            Debug.Log("����");
        }

        switch(playerState)
        {
            case PlayerState.Idle:
                Debug.Log("���");
                break;
            case PlayerState.Walk:
                Debug.Log("�ȱ�");
                break;
            case PlayerState.Run:
                Debug.Log("�޸���");
                break;
            case PlayerState.Attack:
                Debug.Log("����");
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
        // 1ȸ ȣ��
        Debug.Log("������");
        Debug.Log("ü��/���� ȸ��");

        // �� ������ ȣ��
        while(true)
        {
            Debug.Log("���");
            yield return null;
        }
    }

    private IEnumerator Walk()
    {    // 1ȸ ȣ��
        Debug.Log("�̵��ӵ� ���� 2");

        // �� ������ ȣ��
        while (true)
        {
            Debug.Log("�÷��̾� �̵� ����");
            yield return null;
        }
    }

    private IEnumerator Run()
    {    
        // 1ȸ ȣ��
        Debug.Log("�̵��ӵ� ���� 5");

        // �� ������ ȣ��
        while (true)
        {
            Debug.Log("�÷��̾� �޸��� ����");
            yield return null;
        }
    }

    private IEnumerator Attack()
    {    // 1ȸ ȣ��
        Debug.Log("���� ��� ����");
        Debug.Log("ü��/���� ȸ�� ����");

        // �� ������ ȣ��
        while (true)
        {
            Debug.Log("���� ����");
            yield return null;
        }
    }
}
