using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _transform.position += Vector3.left * 10f * Time.deltaTime;
    }
}