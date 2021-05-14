using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 5;
    public float speed;
    private float X;
    private float Z;
    private int score = 0;
    public Text ScoreText;
    public Text healthText;
    public Text wlText;
    public Image wlimage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        if (health <= 0)
        {
            wlimage.gameObject.SetActive(true);
            wlimage.GetComponent<Image>().color = Color.red;
            wlText.text = "Game Over!";
            wlText.color = Color.white;
            StartCoroutine(LoadScene(3));
        }
    }
    void Move()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(X, 0, Z) * speed;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
        }
        if (other.tag == "Goal")
        {
            wlimage.gameObject.SetActive(true);
            wlimage.GetComponent<Image>().color = Color.green;
            wlText.text = "You Win!";
            wlText.color = Color.black;
            StartCoroutine(LoadScene(3));
        }
    }
    void SetScoreText()
    {
        ScoreText.text = $"Score: {score}";
    }
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
