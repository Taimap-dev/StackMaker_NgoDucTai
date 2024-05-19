using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DashPick")
        {
            other.gameObject.tag = "normal";
            Player.instance.PickDash(other.gameObject);
           // other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;      
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<Stack>();
            Destroy(this);
            GameManager.instance.AddScore();
        }
        
        if (other.tag == "Bridge")
        {
            
            Debug.Log("cau duong");
            Player.instance.ThrowDash();
            GameObject childBridge = other.transform.GetChild(0).gameObject;
            if (childBridge != null)
            {
                childBridge.SetActive(true);
            }
            other.tag = "Untagged";
            other.isTrigger = false;
        }
        if (other.tag == "FinalWall")
        {
            Debug.Log("Final Wall");

            GameManager.instance.SetFinal(true);
        }
    }
    
}
