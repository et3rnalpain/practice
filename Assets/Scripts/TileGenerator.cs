using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    public GameObject[] prefabs;
    public GameObject pl;
    public GameObject player;
    public int startcount = 2;
    private List<GameObject> tiles = new List<GameObject>();
    public int spawnpos = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = pl.transform.GetChild(0).gameObject;
        for(int i = 0; i < startcount; i++)
        {
            Spawn(Random.Range(0,prefabs.Length));

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.transform.position.z > spawnpos - (startcount*70))
        {
            Spawn(Random.Range(0,prefabs.Length));
            Delete();
        }
    }

    private void Spawn(int index)
    {
        Vector3 newpos = gameObject.transform.position;
        newpos.z+=spawnpos;
        GameObject obj = Instantiate(prefabs[index],newpos, gameObject.transform.rotation);
        tiles.Add(obj);
        spawnpos += 154;
    }

    private void Delete()
    {
        Destroy(tiles[0]);
        tiles.RemoveAt(0);
    }
}
