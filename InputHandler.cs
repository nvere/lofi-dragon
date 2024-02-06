using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
//using UnityEngine.InputSystem.EnhancedTouch;
using System; 

public class InputHandler : MonoBehaviour
{
   private Camera _mainCamera;

   private void Awake()
   {
    _mainCamera = Camera.main;
   EventManager.OnTimerUpdate(0);
   //EnhancedTouchSupport.Enable();

   //TouchSimulation.Enable();

   EventManager.OnTimerStart();

   }
   public float jumpAmount = 2000;
   public Rigidbody2D rb;
   public void OnClick(InputAction.CallbackContext context){
        if (!context.started) return;
         
    
            Debug.Log("Touch");
            UnityEngine.Touch touch = Input.GetTouch(0);
            var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Touchscreen.current.primaryTouch.position.ReadValue()));
            if (!rayHit.collider) return;
            
      
            var touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = touchWorldPos;
            Vector3 star_position = rayHit.collider.gameObject.transform.position;

            Vector2 star_click = new Vector2(star_position.x -transform.position.x, Math.Abs(star_position.y-transform.position.y));


                if(GameObject.Find(rayHit.collider.gameObject.name).GetComponent<Rigidbody2D>() != null){
                     rb = GameObject.Find(rayHit.collider.gameObject.name).GetComponent<Rigidbody2D>();

                     rb.AddForce(star_click*jumpAmount, ForceMode2D.Impulse);

                  }
                  
         }


         // else if(Input.GetMouseButtonDown(0))
         // {
         //    Debug.Log("mouse_click");

         //    var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
         //    if (!rayHit.collider) return;

         //    //rb = GameObject.Find("Star").GetComponent<Rigidbody2D>();

         //       if(Input.GetMouseButton(0))
         //          {

         //          var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         //          mouseWorldPos.z = 0f; // zero z
         //          transform.position = mouseWorldPos;
         //          //Vector2 movement = new Vector2(transform.position.x,transform.position.y);
         //          Vector3 star_position = rayHit.collider.gameObject.transform.position;
         //       // Vector2 star_movement = new Vector2(star_position.x,star_position.y);
         //          Vector2 star_click = new Vector2(star_position.x -transform.position.x, star_position.y-transform.position.y);
         //          //Debug.Log(transform.position);
         //          //Debug.Log(star_position);

         //          //Debug.Log(star_click);
         //          //Debug.Log(rb.name);
         //           if(GameObject.Find(rayHit.collider.gameObject.name).GetComponent<Rigidbody2D>() != null){
         //                rb = GameObject.Find(rayHit.collider.gameObject.name).GetComponent<Rigidbody2D>();

         //                rb.AddForce(star_click*jumpAmount, ForceMode2D.Impulse);

         //          }


         // }
      


         // }

         
   }

