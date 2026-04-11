using UnityEngine;

public class GilbertSpawner : MonoBehaviour
{
    public GameObject myGillbert;
    public GameObject gillbertsparent;
    public void SpawnGilbert()
    {
        float spawnPointX = Random.Range(-10f, 10f);
        float spawnPointY = Random.Range(-5f, 5f);
        Vector2 spawnPosition = new Vector2(spawnPointX, spawnPointY);
        Vector3 scaleX = new Vector3(Random.Range(0.5f, 20f ), Random.Range(0.5f, 20f ), Random.Range(0.5f, 8f ));
        //Transform scalePos = new Transform(scaleX);
        if ((int)Random.Range(0, 2) < 1)
        {
            scaleX =new Vector3(-scaleX.x,scaleX.y,scaleX.z);
        }
        GameObject gill = Instantiate(myGillbert, spawnPosition, Quaternion.identity);
       // gill.transform.parent=gillbertsparent;
       gill.name = "Gillbert";
       gill.transform.parent = gillbertsparent.transform;
     gill.transform.localScale=scaleX;
     
    }
}
