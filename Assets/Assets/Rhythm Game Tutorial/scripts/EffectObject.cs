using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{

    public float Lifetime = 1f;



    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Lifetime);
    }

    // Update is called once per frame
    void Update()
    {
      //  Destroy(gameObject, Lifetime);
    }
}
