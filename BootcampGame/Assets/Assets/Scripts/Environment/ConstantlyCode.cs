using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantlyCode : MonoBehaviour
{
    public static ConstantlyCode Instance;
    void Start()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

    }
}
