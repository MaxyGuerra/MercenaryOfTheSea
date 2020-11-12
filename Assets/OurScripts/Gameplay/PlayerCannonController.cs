using System.Collections;
using UnityEngine;
public class PlayerCannonController : MonoBehaviour
{
    Transform playerTransform;
    public Transform firePoint;
    public bool canShoot = false;
    public Rigidbody cannonBallBullet;
    public float shootDistance = 100f;

    //public float m

    /// <summary>
    /// New from rotating cannon
    /// </summary>
    [Header("Cannon settings")]
    public float maxCannonAngleMod = 15;
    public float initialCannonAngleMod = 0f;

    public float baseCannonShootPower = 10;//poder base de lanzamiento de la bala
    public float extraShootPowerByHoldingButton = 10;//el maximo de poder al lanzar la bala.
    //se suma al base dependiendo de que tanto mantenga el boton
    public float cannonHoldSpeed=1;/// <summary>
    /// que tan rapido se demora en subir el cañon
    /// </summary>

    float currentCannonHoldPower = 0;
    public float initialCannonHoldPower = 0f;
    Vector3 mouseWorldPosition;

    /// <summary>
    /// cambio la cadencia de disparo con una corutina y un booleano
    /// </summary>
    public float coolDown = 3;
    public bool bCannonIsInCooldown; 


    [Header("Cursor Settings")]

    private Camera mainCamara;
    public GameObject cursor;
    public LayerMask layer;
    RaycastHit hit;
      
    void Start()
    {
        mainCamara = Camera.main; 
    }

    void FiringPoint()
    {
        Ray camRay = mainCamara.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out hit, shootDistance, layer))
        {
            cursor.transform.position = hit.point + Vector3.up * 1f;

            Vector3 Vo = CalculateVelocity(hit.point, transform.position, 1f);

        }

    }

    public void HoldCannonPower()
    {
        currentCannonHoldPower += Time.deltaTime *  cannonHoldSpeed;
     //   print(currentCannonHoldPower+ "  " + Time.deltaTime * cannonHoldSpeed);

    }
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 10 * currentCannonHoldPower);
    }
    public void TryToShootCannon() 
    {
        if (bCannonIsInCooldown) return;

        bCannonIsInCooldown = true;
        LeanTween.alpha(gameObject,1, coolDown).setOnComplete(OnCooldownCompleted).setOnUpdate(OnCoolDownUpdate);
       // StartCoroutine(CannonCooldown());
        Rigidbody bullet = Instantiate(cannonBallBullet, firePoint.position, Quaternion.identity);
        // bullet.velocity = CalculateVelocity(hit.point, transform.position, 1f);
        bullet.velocity = transform.forward * (extraShootPowerByHoldingButton + baseCannonShootPower);
    }
 
    void OnCoolDownUpdate(float Alpha)
    {
        currentCannonHoldPower = Mathf.Lerp(maxCannonAngleMod, 0, Alpha);
    }
    void OnCooldownCompleted()
    {
        bCannonIsInCooldown = false;
    }
    

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float timeInAir)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        //Float to represent distance  

        float heightY = distance.y;
        float heightXZ = distanceXZ.magnitude;

        // Velocity X

        float Vxz = heightXZ / timeInAir;
        float Vy = heightXZ / timeInAir + 0.5f * Mathf.Abs(Physics.gravity.y) * timeInAir;

        //Velocity Y
        Vector3 result = distanceXZ.normalized * Vxz;
        result.y = Vy;

        return result;

    }
   
    void UpdateCannonRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //el plano de interseccion se eleva dependiendo de que tanto presionas el boton hasta el maximo de maxCannonAngleMod
        float heightOffset = Mathf.Lerp(0, maxCannonAngleMod, currentCannonHoldPower);

        //Create a new plane with normal (0,0,1) at the position away from the camera you define in the Inspector. 
        //This is the plane that you can click so make sure it is reachable.
       
        Plane planeIntersection = new Plane(Vector3.up,  transform.position +  transform.up * heightOffset);
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float enter = 0.0f;

        if (planeIntersection.Raycast(ray, out enter))
        {

            mouseWorldPosition = ray.GetPoint(enter);
            Vector3 lookDirection = mouseWorldPosition -  transform.position;
            transform.rotation = Quaternion.LookRotation(lookDirection);

        }

    }

    public void RestartCannonRotation()
    {
        float initialOffset = Mathf.Lerp(0, initialCannonAngleMod, initialCannonHoldPower);
    }

    void ResetValue()
    {
       
    }
    // Update is called once per frame
    public void UpdateCannon()
    {
       
        UpdateCannonRotation(); 

        FiringPoint();

      
    }
}
