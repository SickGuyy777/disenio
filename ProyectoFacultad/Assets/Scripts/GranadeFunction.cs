using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeFunction : MonoBehaviour
{
    public float explosionTime;
    float _explosionMoment;

    private void Start()
    {
        _explosionMoment = Time.time + explosionTime;
    }

    private void Update()
    {
        if(Time.time > _explosionMoment)
        {
            Explote();
        }
    }

    void Explote()
    {
        Destroy(gameObject);

        //agregar particulas
    }
}
