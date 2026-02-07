using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
   public GameObject SuperRun;
   public GameObject Magnet;
   public Transform player;
   public float SpawnInterval=15f;
   public float SpawnDistance=30f;
   float timer;
   bool Power=true;
   float[] lanes = {-2.5f,0f,2.5f};
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer> SpawnInterval)
        {
            SuperPowerInterval();
            timer=0f;
        }
    
    }
    void SuperPowerInterval()
    {
        float RandomLanex=lanes[Random.Range(0,lanes.Length)];
        Vector3 spawnpos=new Vector3(RandomLanex,0.5f,player.position.z+SpawnDistance);
        if (Power)
        {
            Instantiate(SuperRun,spawnpos,Quaternion.identity);
            Power=false;
        }
        else
        {
            Instantiate(Magnet,spawnpos,Quaternion.identity);
            Power=true;
        }
    }
}
