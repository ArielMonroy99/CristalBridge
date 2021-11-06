using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private float fallMultiplier = 10f;
    [SerializeField] private float lowJumpMultiplier = 2f;
   

    //[SerializeField] private GameObject initiGlassPane;
    private GameObject[] glassPanes;
    private int counter; 
    

    private bool leap; 
    // Start is called before the first frame update
    void Start()
    {
        leap = false;
        rb = GetComponent<Rigidbody>();
        glassPanes = GameObject.FindGameObjectsWithTag("GlassPane");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (leap)
        {
            if (Input.GetKey(KeyCode.Space))
            {
   
                rb.AddForce(new Vector3(0,jumpForce, 0),ForceMode.Impulse);
                

                leap = false;

               
            } 
        }
        Debug.Log(rb.velocity.y);
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }

   

    public void OnCollisionEnter(Collision other)
    {
        leap = true;
        GameObject pane = other.gameObject;

        if (pane != null)
        {
            if (pane.CompareTag("GlassPane"))
            {
                if (pane.GetComponent<GlassPaneCharacteristics>().isFragile())
                {
                    
                    leap = false;
                }
            }
            
        }
    }
}
