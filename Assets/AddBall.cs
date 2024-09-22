using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
  public GameObject sampleObject;

  public void AddObject()
  {

    print("BUTTON PRESS ADDING GAME OBJECT");
    GameObject g = GameObject.Instantiate(sampleObject);
    SpriteRenderer m_SpriteRenderer;

    m_SpriteRenderer = g.GetComponent<SpriteRenderer>();

    m_SpriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    Transform t = g.transform;
    var position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-3.0f, 3.0f), 0);

    t.position = position;

  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
