using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] Vector3[] Positions;
    [SerializeField] Material NewMaterial;
    void Start()
    {
       
    }


    void Update()
    {
       
    }

    public void Race(Player player, int id) 
    {
        for (int i = 0; i < Positions.Length; i++)        
            if (id == i)
            {
                player.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                player.gameObject.transform.position = Positions[i];
                player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
            
    }
   public IEnumerator Countdown(Player[] player)
    {
        FindObjectOfType<ControlCamera>().Follow = true;
        FindObjectOfType<ControlCamera>().SetCam();
        yield return new WaitForSeconds(3);
        for (int i = 0; i < player.Length; i++)
        player[i].gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        this.GetComponent<MeshRenderer>().material = NewMaterial;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 
}
