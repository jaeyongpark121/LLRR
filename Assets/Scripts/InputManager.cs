using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool onPattern = false;
    string code = "abcd";
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

        int count = code.Length - 1;

        for (int i = 0; i < code.Length; i++)
        {
            //count--;
            if (count % 2 == 0)
            {
                code = code.Insert(count, " ");
            }
        }

        Debug.Log(code);
        yield return new WaitForSeconds(1f);

        onPattern = false;
    }
}
