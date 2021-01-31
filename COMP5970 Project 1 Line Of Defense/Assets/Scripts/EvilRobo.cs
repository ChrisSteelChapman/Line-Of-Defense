using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilRobo : MonoBehaviour
{
    //This would be much better handled with Inheritance, but I'm going for FAST over GOOD on this project.
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    public bool isOn;

    public void Awake()
    {
        anim.enabled = false;
    }
    public void ActivateRobot()
    {
        anim.enabled = true;
        rb.AddForce(new Vector2(1f, 2.5f));
        isOn = true;
    }

    private void Update()
    {
        if (isOn)
        {
            transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.AddForce(new Vector2(125f, 199f));
        anim.enabled = false;
        isOn = false;
        //Fail Level
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
    }
}
