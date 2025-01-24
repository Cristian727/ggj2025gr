using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float xBound = 6f;

    ParticleSystem particles;
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if(transform.position.x >= xBound)
        {
            particles.Stop();
            transform.position = new Vector3(-xBound, 0, 0);
            particles.Play();
        }
    }
}
