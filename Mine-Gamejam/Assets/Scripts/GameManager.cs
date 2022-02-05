using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isHiding = false;
    public GameObject hideSpot;

    public void Awake()
    {
        instance = this;
    }
}
