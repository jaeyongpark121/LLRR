using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool onPattern = false;

    string code = "abcd";
    string[] subCode = new string[4];
    bool[] pass = new bool[4];
    bool onGame = true;
    // Start is called before the first frame update
    void Start()
    {
        onGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �ʱ�ȭ
        if (!onPattern)
        {
            onPattern = true;
            StartCoroutine(GetCode());
            for (int i = 0; i < pass.Length; i++)
            {
                pass[i] = false;
                Debug.Log(subCode[i]);
            }
        }
        
        // ���� üũ
        if (onPattern)
        {
            if (!pass[0])
            {
                Debug.Log("checking " + subCode[0]);
                Check(subCode[0], ref pass[0]);
            }
            else if (!pass[1])
            {
                Debug.Log("checking " + subCode[1]);
                Check(subCode[1], ref pass[1]);
            }
            else if (!pass[2])
            {
                Debug.Log("checking " + subCode[2]);
                Check(subCode[2], ref pass[2]);
            }
            else if (!pass[3])
            {
                Debug.Log("checking " + subCode[3]);
                Check(subCode[3], ref pass[3]);
            }
        }
    }

    //���� üũ �Լ�
    void Check(string subCode, ref bool pass)
    {
        if(subCode == "LR")
        {
            if(Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log(subCode + " clear!");
                pass = true;
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                GameOver();
            }
        }
        else if(subCode == "LL")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log(subCode + " clear!");
                pass = true;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                GameOver();
            }
        }
        else if (subCode == "RL")
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log(subCode + " clear!");
                pass = true;
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                GameOver();
            }
        }
        else if (subCode == "RR")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log(subCode + " clear!");
                pass = true;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                GameOver();
            }
        }
    }

    // ���ӿ��� �Լ�
    void GameOver()
    {
       
        onGame = false;
        StopCoroutine(GetCode());
        Debug.Log("GameOver");
    }

    // �ڵ带 �޾ƿ� �ڸ��� �ڷ�ƾ
    IEnumerator GetCode()
    {
        code = PatternManager.instance.MakePattern();

        Debug.Log(code);

        for(int i = 0; i < code.Length/2; i ++)
        {
            subCode[i] = code.Substring(i * 2, 2);
        }

        yield return new WaitForSeconds(10f);

        //�� ������ üũ
        if (pass[pass.Length - 1])
        {
            Debug.Log("clear!");
            onPattern = false;
        }
        else
        {
            GameOver();
        }
    }
}
