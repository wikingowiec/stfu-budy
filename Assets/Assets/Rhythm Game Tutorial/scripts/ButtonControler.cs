using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour {

    private SpriteRenderer theSR; 
    public Sprite defulteImagine; 
    public Sprite pressedImagine; 

    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start() {
        theSR = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(keyToPress)) 
        {
            theSR.sprite = pressedImagine;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defulteImagine;
        }
    }
}