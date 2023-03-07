using UnityEngine;

public class Control_Snake : MonoBehaviour
{
    public float speed = 10;
    public float Impulse = 50;
    private Vector3 _previousMousePosition;
    public float Sensitivity=0.1f;

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
        
        Move_Forward();


        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            transform.position = transform.position + new Vector3(delta.x * Sensitivity, 0, 0);
         

        }
        _previousMousePosition = Input.mousePosition;




        if (Input.GetKey(KeyCode.LeftArrow)) //налево 
        {

            transform.position = transform.position - new Vector3(0.01f,0,0);

            //   GetComponent<Rigidbody>().AddForce(direction_left * Impulse, ForceMode.Impulse); 
            //   Debug.Log(Impulse);
        }

        if (Input.GetKey(KeyCode.RightArrow)) //направо 
        {
            transform.position = transform.position + new Vector3(0.01f, 0, 0);
            //    GetComponent<Rigidbody>().AddForce(direction_right * Impulse, ForceMode.Impulse);
            //   Debug.Log(Impulse);
        }
    }

    private void Move_Forward()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
