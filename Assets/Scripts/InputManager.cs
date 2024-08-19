using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    string code;
    // Start is called before the first frame update
    void Start()
    {
        code = PatternManager.instance.MakePattern();
        //Debug.Log(code);
    }

    // Update is called once per frame
    void Update()
    {

        //StartCoroutine(GetCode());
    }

    IEnumerator GetCode()
    {
        Debug.Log(PatternManager.instance.MakePattern());
        yield return new WaitForSeconds(1f);
    }
}
