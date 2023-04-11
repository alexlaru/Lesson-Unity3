using UnityEngine;
using UnityEditorInternal;

public class Control_Snake : MonoBehaviour
{
    public float speed = 10;
    public float Impulse = 50;
    private Vector3 _previousMousePosition;
    public float Sensitivity=0.2f;
    public float angle = 0.5f;
    private float MaxAngle = 45;
    private float MinAngle = -45;
    private float CurrentAngle = 0;
    

    //    public GameObject Snake_head = GameObject.Find("Snake_head");
    //  public Rigidbody 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = transform.position;
        Vector3 offset_left = transform.position - new Vector3(1,0,0);
        Vector3 offset_right = transform.position + new Vector3(1, 0, 0);
        Vector3 direction_left = offset_left.normalized;
        Vector3 direction_right = offset_right.normalized;

       
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            transform.position = transform.position + new Vector3(delta.x * Sensitivity, 0, 0);
         

        }
        _previousMousePosition = Input.mousePosition;




        if (Input.GetKey(KeyCode.LeftArrow)) //налево 
        {

           // transform.position = transform.position - new Vector3(0.01f,0,0);

           if(CurrentAngle > MinAngle)
            {
                CurrentAngle -= angle;
                GameObject.Find("Snake_head").transform.Rotate(0, -angle, 0);
            }
            

          
        }

        if (Input.GetKey(KeyCode.RightArrow)) //направо 
        {
            //  transform.position = transform.position + new Vector3(0.01f, 0, 0);
            if (CurrentAngle < MaxAngle)
            {
                CurrentAngle += angle;
                GameObject.Find("Snake_head").transform.Rotate(0, angle, 0);
            }
                
        }
    }

   


}
