using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomParticle : MonoBehaviour
{
    public float effectLastTime = 2f;
    
    private MeshRenderer _mesh;
    private float _currentLastTIme;
    private float _r;
    private float _g;
    private float _b;
    // Start is called before the first frame update
    void Start()
    {
        _currentLastTIme = effectLastTime;
        _mesh = GetComponent<MeshRenderer>();
        _mesh.material.SetColor("_EmissionColor", Utils.GetRandomLightColor());
        Color materialColor = _mesh.material.GetColor("_EmissionColor");
        _r = materialColor.r;
        _g = materialColor.g;
        _b = materialColor.b;
    }

    // Update is called once per frame
    void Update()
    {
        _currentLastTIme -= Time.deltaTime;
        _mesh.material.SetColor( "_EmissionColor",
            new Color(_r, _g, _b,_currentLastTIme / effectLastTime)
        );
        if (_currentLastTIme < 0)
            Destroy(gameObject);
    }
}
