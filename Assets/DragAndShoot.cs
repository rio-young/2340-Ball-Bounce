using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Looked at tutorial here for some parts: https://www.youtube.com/watch?v=Tsha7rp58LI&t=4s&ab_channel=MuddyWolf
public class DragAndShoot : MonoBehaviour
{
  public float power = 10f;
  public Rigidbody2D rb;

  // To ensure that larger screen size does not sway game
  public Vector2 minPower;
  public Vector2 maxPower;

  public TrajectoryLine tl;

  // need to convert screen position ot world position
  public Camera cam;
  Vector2 force;
  Vector3 startPoint;
  Vector3 endPoint;


  // Start is called before the first frame update
  void Start()
  {
    cam = Camera.main;
    tl = GetComponent<TrajectoryLine>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
      startPoint.z = 15;
      // print("start position: " + startPoint);
    }

    // if mouse button is held
    if (Input.GetMouseButton(0))
    {
      Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
      currentPoint.z = 15;
      tl.RenderLine(startPoint, currentPoint);
    }

    if (Input.GetMouseButtonUp(0))
    {
      endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
      endPoint.z = 15;

      force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
      rb.AddForce(force * power, ForceMode2D.Impulse);

      // print("end position: " + endPoint);
      tl.EndLine();
    }
  }
}
