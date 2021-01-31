using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoboController : MonoBehaviour
{
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
        if (transform.position.y < -600)
        {
            SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.AddForce(new Vector2(125f, 199f));
        anim.enabled = false;
        isOn = false;
        //Complete Level
        StartCoroutine("Exit");
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(3f);
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync(thisScene);
    }
}
