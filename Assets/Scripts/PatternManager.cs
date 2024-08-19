using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PatternManager instance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 랜덤 패턴 생성기
    public string MakePattern()
    {
        string code = string.Empty;
        for (int i = 0; i<8; i++)
        {
            if (Random.Range(0, 2) == 0)
                code += "L";
            else
                code += "R";
        }
        return code;
    }
}
