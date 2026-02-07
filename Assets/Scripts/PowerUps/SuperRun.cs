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
            collision.gameObject.SetActive(false);
        }
    }
    IEnumerator superrun()
    {
        player.speed*=SpeedMultiplier;
        Color c=mat.color;
        c.a = fadeAmount;
        mat.color = c;
        
        yield return new WaitForSeconds(Duration-2f);
        mat.color=Color.red;
        yield return new WaitForSeconds(0.2f);
        mat.color=c;
        yield return new WaitForSeconds(0.2f);
        mat.color=Color.red;
        yield return new WaitForSeconds(0.2f);
        mat.color=c;
        yield return new WaitForSeconds(0.2f);
        mat.color=Color.red;
        yield return new WaitForSeconds(0.2f);
        mat.color=c;
        player.speed/=SpeedMultiplier;
        c.a=Original;
        mat.color=c;
    } 
    
}
