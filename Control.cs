using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Control : MonoBehaviour
{
    public float speed;
    public float dashSpeed;

    public float bulletSpeed;
    public float fireRate;
    private float nextFire = 0.0f;

    public GameObject crosshair;
    public GameObject bulletPrefab;

    private void Start()
    {
    }

    void Update()
    {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * speed * Time.deltaTime;

        Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
        transform.position = transform.position + vertical * speed * Time.deltaTime;

        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        AimAndShoot();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = transform.position + horizontal * dashSpeed * Time.deltaTime;
            transform.position = transform.position + vertical * dashSpeed * Time.deltaTime;

        }

    }

    private void AimAndShoot()
    {
        Vector3 aim = Input.mousePosition;
        aim = Camera.main.ScreenToWorldPoint(aim);
        crosshair.transform.position = Vector2.Lerp(crosshair.transform.position, aim, 0.5f);

        Vector2 aim2D = Input.mousePosition;
        aim2D = Camera.main.ScreenToWorldPoint(aim2D);
        Vector2 currentPostion = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = aim2D - currentPostion;
        direction.Normalize();

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            //bullet.transform.position = transform.position + transform.up * 1f;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
            Destroy(bullet, 2.0f);
        }
    }
}
