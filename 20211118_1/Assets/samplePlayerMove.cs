using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class samplePlayerMove : MonoBehaviour
{
    public int lifeCount;
    public float jumpPower;
    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "deadFloor"){
            lifeCount--;
            if (lifeCount == 0) {/***Game fail***/ }
            else
            {/***restart from startFloor***/
                SceneManager.LoadScene("SampleScene");
            }
        }
        else if (other.tag == "endFloor"){
            /***Game clear***/
        }
    }
}

