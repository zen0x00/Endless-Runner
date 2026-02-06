using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuperRun : MonoBehaviour
{
    public Player player;
    [SerializeField]float SpeedMultiplier=2f;
    [SerializeField]float Duration=5f;
    public float fadeAmount=0.5f;
    float Original;
    Material mat;
    
    void Start()
    {
        mat=GetComponent<Renderer>().material;
        Original=mat.color.a;
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "RunPower")
        {
            StartCoroutine(superrun());
            Destroy(collision.gameObject);
        }
    }
    IEnumerator superrun()
    {
        player.speed*=SpeedMultiplier;
        Color c=mat.color;
        c.a = fadeAmount;
        mat.color = c;
        
        yield return new WaitForSeconds(Duration);
        player.speed/=SpeedMultiplier;
        c.a=Original;
        mat.color=c;
    } 
    
}
