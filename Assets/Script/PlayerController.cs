using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	private int score = 0;
	public float speed = 1000f;
	public int health = 5;
	public Text scoreText;
	public Text healthText;
	public Text winLoseText;
	public Image winLoseImage;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
    // Renamed in FixedUpdate
    void FixedUpdate()
    {

		if (Input.GetKey("z"))
		{
			rb.AddForce(0, 0, 500 * Time.deltaTime);
		}

		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -500 * Time.deltaTime);
		}

		if (Input.GetKey("d"))
		{
			rb.AddForce(500 * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("q"))
		{
			rb.AddForce(-500 * Time.deltaTime, 0, 0);
		}
		
		if (Input.GetKey("escape"))
		{
			SceneManager.LoadScene(0);
		}
    }

	// Function that ++ when player get a coin
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			score++;
			SetScoreText();
			other.gameObject.SetActive(false);
		}
		else if (other.CompareTag("Trap"))
		{
			health--;
			SetHealthText();
		}
		else if (other.CompareTag("Goal"))
		{
			winLoseImage.gameObject.SetActive(true);
			winLoseImage.color = Color.green;
			winLoseText.color = Color.black;
			winLoseText.text = "You Win!";
			StartCoroutine(LoadScene(3));
		}
	}

	// Function that show Game Over if health equal 0
	void Update()
	{
		if (health == 0)
		{
			winLoseImage.gameObject.SetActive(true);
			winLoseImage.color = Color.red;
			winLoseText.color = Color.white;
			winLoseText.text = "Game Over!";
			StartCoroutine(LoadScene(3));
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	void SetHealthText()
	{
		healthText.text = "Health: " + health;
	}

	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}