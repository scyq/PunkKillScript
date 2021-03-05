using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    public GameObject effectPrefeb;

    public int particleNum = 10;

    public float boomForce = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < particleNum; i++)
        {
            GameObject effect = Instantiate(effectPrefeb, transform.position, Quaternion.identity);
            float scaleFactor = Random.Range(0.2f, 0.3f);
            effect.transform.localScale = Vector3.one * scaleFactor; // 每个方块大小不一样
            Rigidbody rigid = effect.GetComponent<Rigidbody>();
            if (rigid)
            {
                Vector3 explosionDir = new Vector3(Random.Range(-1f, 1f), Random.Range(0, 1), Random.Range(-1f, 1f));
                rigid.AddForce(explosionDir.normalized * boomForce, ForceMode.Impulse);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
