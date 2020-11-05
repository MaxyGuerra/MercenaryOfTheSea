using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 1;

    public float timeToDestroy = 5;

    static public Rigidbody rb;

    static public int damage = 1;

    static public int bossDamage = 3;

    public float m_timeToReach = 2; //Es el tiempo que demora en llegar la bala de un punto a otro en segundos, 
    //esto puede ser equivalente a la distancia, asi haces que mientras mas lejos, mas se demore.
    public float m_verticalMultiplier = 2f; //Que tan alto llega la bala independiente de la distancia.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   

    public void SetVelocity(Vector3 startPoint, Vector3 endPoint)
    {

        StartCoroutine(VelocityAnimation(startPoint, endPoint));
    }

    private IEnumerator VelocityAnimation(Vector3 startPoint, Vector3 endPoint)
    {

        float m_horizontalAngle = Mathf.Atan2(endPoint.z - startPoint.z, endPoint.x - startPoint.x);
        float m_horizontalMultiplier = Vector3.Distance(startPoint, endPoint);

        for (float i = 0; i < m_timeToReach; i += Time.deltaTime)
        {

            float m_verticalAngle = Mathf.Lerp(0, 180, i / m_timeToReach);

            //Calculo matematico que encierra un arco vertical dependiendo de el angulo actual.
            float m_y = (Mathf.Sin(m_verticalAngle * Mathf.Deg2Rad) * m_verticalMultiplier);

            //Calculo matematico que representa la horizontalidad dependiendo de la verticalidad.
            float m_x = ((Mathf.Cos(m_horizontalAngle)) * m_horizontalMultiplier) * Mathf.Cos(m_verticalAngle * Mathf.Deg2Rad);
            float m_z = ((Mathf.Sin(m_horizontalAngle)) * m_horizontalMultiplier) * Mathf.Cos(m_verticalAngle * Mathf.Deg2Rad);

            transform.position = startPoint + new Vector3(m_x, m_y, m_z);

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, timeToDestroy);
    }
}
