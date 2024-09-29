using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{

  public GameObject sampleObject;
  static int max_balls = 20;
  public int num_balls;
  
  // Start is called before the first frame update
  void Start()
  {
    num_balls = 1;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void AddBall()
  {
    if (num_balls >= max_balls)
    {
      print("TOO MANY BALLS: " + num_balls);
      return;
    }
    GameObject g = GameObject.Instantiate(sampleObject);
    SpriteRenderer m_SpriteRenderer;

    m_SpriteRenderer = g.GetComponent<SpriteRenderer>();

    m_SpriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    Transform t = g.transform;
    var position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-3.0f, 3.0f), 0);

    t.position = position;
    num_balls++;
    print("ADDED BALLS: " + num_balls);

  }

  public void RemoveBall()
  {
    num_balls -= 1;
    print("DESTROYED BALL");
    print("num balls: " + num_balls);
  }
}
