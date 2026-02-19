using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour
{
     [SerializeField]float speed=5f;
    
   
    Rigidbody Rb;
    bool swimInput;
    Material mat;
    float original;
    

    bool isDefending = false;
    
    void Start()
    {
        Rb=GetComponent<Rigidbody>();
        mat=GetComponent<Renderer>().material;
        original=mat.color.a;
    }
    void Update()
    {
        swimInput=Input.GetKey(KeyCode.W);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!isDefending)
                StartDefense();
        }
        else
        {
            if (isDefending)
                EndDefense();
        }
            
        }
    void FixedUpdate()
    {
        if (swimInput)
        {
            Vector3 forwardMove=transform.forward*speed*Time.fixedDeltaTime;
            Rb.MovePosition(Rb.position+forwardMove);
        }
        
    }
    void StartDefense()
    {
        isDefending = true;
        Color c = mat.color;
        c.a = 0.5f; 
        mat.color = c;
    }

    void EndDefense()
    {
        isDefending = false;

        Color c = mat.color;
        c.a = original; 
        mat.color = c;
    }

}
