using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riser : MonoBehaviour
{
    private float noiseValue;
    private float originalHeight;

    // Start is called before the first frame update
    void Start()
    {
        originalHeight = Random.Range(0, 2f);
        transform.position =
            new Vector3(transform.position.x, transform.position.y + originalHeight, transform.position.z);
        noiseValue = Mathf.PerlinNoise(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, Mathf.Sin(10 * Time.time * noiseValue) * 0.3f + 2f, 1);
    }
}
