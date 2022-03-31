using UnityEditor;
using UnityEngine;

public class SelectObjects : MonoBehaviour
{
    void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetButtonDown("Fire1")) {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos,Vector2.zero);
                if (hit.transform != null) 
                {
                    if (hit.collider != null)
                    {
                        if( hit.collider.GetComponent<ObjectAction>() != null) 
                            hit.collider.GetComponent<ObjectAction>().Action();
                    }
                }
            }
        }else
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            RaycastHit2D hit = Physics2D.Raycast(touchPos,Vector2.zero);
            if (hit.transform != null) 
            {
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<ObjectAction>().Action();
                }
            }
        }
       
    }
    
}