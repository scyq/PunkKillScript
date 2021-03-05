using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SinglePlayerMovement : MonoBehaviourPun
{

    public float moveSpeed = 10f;
    
    private Rigidbody _rb;
    private float _inputHorizontal;
    private float _inputVertical;
    private Vector3 _mousePos;
    private Vector3 _mousePos3D;
    private Vector3 _movement;
    private float _angle;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _movement = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        // 如果没连上服务器就滚蛋
        if (!(photonView.IsMine && PhotonNetwork.IsConnected))
            return;
        
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        _inputVertical = Input.GetAxisRaw("Vertical");
        
        // 获取鼠标在3维空间下的坐标
        _mousePos = Input.mousePosition;
        _mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        _mousePos3D = Camera.main.ScreenToWorldPoint(_mousePos);
        _mousePos3D.y = 0;

    }

    private void FixedUpdate()
    { 
        // 如果没连上服务器就滚蛋
        if (!(photonView.IsMine && PhotonNetwork.IsConnected))
            return;
        
        _movement.Set(_inputHorizontal, 0, _inputVertical);
        _rb.velocity = _movement.normalized * moveSpeed;
        
        // 看向鼠标位置
        transform.forward = _mousePos3D - transform.position;
    }
    
}
