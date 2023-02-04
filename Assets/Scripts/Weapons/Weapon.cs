using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    private Vector3 rest = new Vector3(0, 0, 0);
    private Vector3 swung = new Vector3(0, 0, 90);
    private bool isSwinging = false;


    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
       gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetButtonUp("Jump") || isSwinging)
        {
            isSwinging = true;
            Swing();
        }
    }

    void Swing() {

       gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Quaternion currentRotation = transform.rotation;
        Quaternion wantedRotation = Quaternion.Euler(0,0,90);

        if(transform.rotation.z == 90){

            isSwinging = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            transform.Rotate(new Vector3(0, 0, 0));
            return;

        }

        if(isSwinging) {

            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime*750f);    

        }
        
        Debug.Log("true");
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
