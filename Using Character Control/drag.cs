using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class drag : MonoBehaviour
{
  private Vector3 doffset;
  private Camera cam;
  [SerializeField] private float speed =10f;
  void Awake(){
    cam= Camera.main;
  }
  void OnMouseDown(){
    doffset=transform.position-GetMousePos();
  }
  void OnMouseDrag(){
    transform.position=Vector3.MoveTowards(transform.position,GetMousePos()+doffset,speed*Time.deltaTime);
  }
  Vector3 GetMousePos(){
    var mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    mousepos.z=0;
    return mousepos;
  }
  
}