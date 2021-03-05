using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bullet;
    public Transform shootPos;
    public float _shootingInterval = 0.2f;

    private float _currentInterval = 0f;
    private Vector3 _angle;
    private Quaternion _constraintRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentInterval > 0)
        {
            _currentInterval -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0) && _currentInterval <= 0)
        {
            _angle = transform.rotation.eulerAngles;
            _angle.x = 0;
            _angle.z = 0;
            _constraintRotation = Quaternion.Euler(_angle);
            Instantiate(bullet, shootPos.position, _constraintRotation);
            _currentInterval = _shootingInterval;
        }
            
    }
}
