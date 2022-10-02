using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    [SerializeField] int FPS;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS;
    }
}
