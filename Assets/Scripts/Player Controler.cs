using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float noSpeed = 0f;
    [SerializeField] ParticleSystem dustParticles;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }
    public void DisableControls()
    {
        canMove = false;
    }
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = slowSpeed;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = noSpeed;
            dustParticles.Stop();
        }
        else if (Input.GetKeyUp(KeyCode.Space) && FindObjectOfType<DustTrail>().isGrounded)
        {
            dustParticles.Play();
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}