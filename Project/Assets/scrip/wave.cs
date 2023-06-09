using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{

    public WaveGroup enemies;
    [System.Serializable]
    public class WaveGroup
    {
        public GameObject enemy;
        public int count;
    }
}
