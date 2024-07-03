using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    public GameObject[] prefabs;
    public int spawnpos = 0;
    // Start is called before the first frame update
    void Start()
    {
        Spawn(0);
        Spawn(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn(int index)
    {
        Instantiate(prefabs[index], transform.forward * spawnpos, transform.rotation);
        spawnpos += 155;
    }
}
