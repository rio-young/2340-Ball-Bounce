using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Looked at tutorial here https://gruman.co/2d-pool-unity
public class BallManager : MonoBehaviour
{
  AudioSource audioSource;
  public LogicScript logic;
  bool calledStart = false; 

  
  // Start is called before the first frame update
  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    logic = GameObject.FindGameObjectWithTag("GameController").GetComponent<LogicScript>();
    calledStart = true;
  }

  // Update is called once per frame
  void Update()
  {

  }
  void OnCollisionEnter2D(Collision2D collision)
  {
    // print("BALL NOISE");
    if (audioSource != null)
    {
      audioSource.Play();
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (gameObject != null && calledStart)
    {
      Destroy(gameObject);
      logic.RemoveBall();
      
    }
  }
}
