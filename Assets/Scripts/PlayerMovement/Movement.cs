using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    public float speed=5f;
    
    Rigidbody Rb;
    bool swimInput;
    Material mat;
    float original;
    GameObject CurrentCoin;
    CapsuleCollider capsuleCollider;
    

    bool isDefending = false;
    
    void Start()
    {
        Rb=GetComponent<Rigidbody>();
        mat=GetComponent<Renderer>().material;
        capsuleCollider=GetComponent<CapsuleCollider>();
        
        original=mat.color.a;
    }
    void Update()
    {
        swimInput=Input.GetKey(KeyCode.W);

        if (Input.GetKey(KeyCode.C)&& CurrentCoin!=null)
        {
            CurrentCoin.SetActive(false);
            CurrentCoin.transform.SetParent(transform);
        }
        if(Input.GetKey(KeyCode.E)&& CurrentCoin != null)
        {
            CurrentCoin.transform.SetParent(null);
            CurrentCoin.transform.position=transform.position+transform.forward*2f;
            CurrentCoin.SetActive(true);
        }

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
        capsuleCollider.isTrigger=true;
    }

    void EndDefense()
    {
        isDefending = false;
        capsuleCollider.isTrigger=false;

        Color c = mat.color;
        c.a = original; 
        mat.color = c;                              
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            CurrentCoin=other.gameObject;
        }
        
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            CurrentCoin=null;
        }
    }
    

}
