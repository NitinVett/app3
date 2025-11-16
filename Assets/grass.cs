using UnityEngine;

public class GrassScatter : MonoBehaviour
{
    public GameObject grassPrefab;
    public int count = 200;  // number of grass pieces
    public Vector2 areaSize = new Vector2(10, 10);  // X/Z area

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(-areaSize.x / 2, areaSize.x / 2);
            float z = Random.Range(-areaSize.y / 2, areaSize.y / 2);

            Vector3 position = new Vector3(x, 5f, z) + transform.position;

            Instantiate(grassPrefab, position, Quaternion.identity, transform);
        }
    }
}