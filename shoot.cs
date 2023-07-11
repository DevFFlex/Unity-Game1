using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] GameObject box;
    [SerializeField] GameObject box_start_position;
    [SerializeField] Transform cam;
    void Start()
    {
        
    }

    GameObject bullet_obj;
    Rigidbody bullet_rb;
    Vector3 bullet_size = new Vector3(0f,0f,0f);
    float offset_y = 0f;
    float bullet_force = 1;
    float bullet_mass = 1;
    bool status_click = false;
    void Update()
    {
        if (status_click)
        {

            bullet_size.x += 0.1f;
            bullet_size.y += 0.1f;
            bullet_size.z += 0.1f;
            bullet_obj.transform.localScale = bullet_size;
            bullet_obj.transform.position = box_start_position.transform.position + new Vector3(0f,offset_y,0f);
            bullet_rb.mass = bullet_mass;
            bullet_force += 1500f;
            bullet_mass += 1;
            offset_y += 0.08f;
        }
 
        if (Input.GetMouseButtonDown(0))
        {
            box_start_position.SetActive(true);
            bullet_size = new Vector3(0f,0f,0f);
            bullet_force = 0f;
            bullet_mass = 1f;
            offset_y = 0f;
            status_click = true;
            bullet_obj = Instantiate(box);
            bullet_obj.transform.position = box_start_position.transform.position;
            bullet_rb = bullet_obj.GetComponent<Rigidbody>();
            bullet_rb.useGravity = false;
            
            
        }


        if (Input.GetMouseButtonUp(0))
        {
            box_start_position.SetActive(false);
            status_click = false;

            Debug.Log("Shoot");

            var input = new Vector3();
            input += transform.forward;
            Debug.Log("input before = " + input);

            input.y = -cam.rotation.x;

            Debug.Log(cam.rotation.x);
            Debug.Log("input after = " + input);

            input *= bullet_force;
            bullet_rb.AddForce(input);



            Destroy(bullet_obj, 20f);
        }


        if (Input.GetMouseButtonDown(1))
        {
            bullet_rb.useGravity = true;
        }
    }
}
