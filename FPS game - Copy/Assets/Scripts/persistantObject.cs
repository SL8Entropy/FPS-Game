using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistantObject : MonoBehaviour
{
    public float sensitivity = 30;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
