using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Looked at tutorial here https://gruman.co/2d-pool-unity
public class BallManager : MonoBehaviour
{
  AudioSource audioSource;
  // Start is called before the first frame update
  void Start()
  {
    audioSource = GetComponent<AudioSource>();
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
    if (gameObject != null)
    {
      Destroy(gameObject);
    }
  }
}
