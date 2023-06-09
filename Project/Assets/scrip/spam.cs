using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spam : MonoBehaviour
{
    GameObject[] spamPoint;
    public GameObject enemy;


    public float timeBetweenWave = 10f;
    public wave waves;
    private float countdown = 2f;

    public static int wayIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        spamPoint = GameObject.FindGameObjectsWithTag("Respawn");
    }  
    // Update is called once per frame
    void Update()
    {     
        if (countdown <= 0f)
        {
            StartCoroutine(Spamnwave());
            countdown = timeBetweenWave;
        }
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        countdown -= Time.deltaTime;
    }
    IEnumerator Spamnwave()
    {
        wave wave = waves;
       // Debug.LogError("waye:" + wayIndex + "co so luong: "  + wave.enemies.count);

        for (int z = 0; z < wave.enemies.count; z++)
        {
                Spawn(wave.enemies.enemy);
                yield return new WaitForSeconds(1f);
                
        }
        wayIndex++;
        wave.enemies.count++;
    }
    void Spawn(GameObject enemy)
    {
        int point = Random.Range(0, spamPoint.Length);
        Instantiate(enemy, spamPoint[point].transform.position, Quaternion.identity);
    }
}
