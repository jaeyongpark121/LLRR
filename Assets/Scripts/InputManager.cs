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

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(code);
    }

    // Update is called once per frame
    void Update()
    {
        if (!onPattern)
        {
            onPattern = true;
            StartCoroutine(GetCode());
        }
    }

    IEnumerator GetCode()
    {
        code = PatternManager.instance.MakePattern();

        Debug.Log(code);

        for(int i = 0; i < code.Length/2; i ++)
        {
            subCode[i] = code.Substring(i * 2, 2);
        }

        yield return new WaitForSeconds(10f);

        onPattern = false;
    }
}
