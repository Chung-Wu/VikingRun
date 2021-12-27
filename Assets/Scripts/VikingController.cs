using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class VikingController : MonoBehaviour
{

    public Vector3 MovingDirection;
    private float movingSpeed = 10f;
    public float JumpingForce = 500f;
    Rigidbody rb;
    Animator animator;
    bool run = false, onground = false;
    private string heading_dir;
    private void Awake()
    {
        Debug.Log("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localPosition = new Vector3(0, 0, 0);
        animator = GetComponent<Animator>();
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        run = false;
       
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movingSpeed;
            
            run = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0.0f, -90.0f, 0.0f);
            run = true;

        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0.0f, 90.0f, 0.0f);

            run = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (onground  && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(JumpingForce * Vector3.up);
            onground = false;
        }

        animator.SetBool("Run", run);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent.name == "Normal_land1" || collision.transform.parent.name == "Normal_land2")
        {
            onground = true;
        }
    }
}
