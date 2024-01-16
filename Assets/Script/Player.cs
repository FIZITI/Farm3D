using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _plant;
    [SerializeField] private Transform _plantPosition;

    private float _horizontal;
    private float _vertical;
    private Vector3 _direction;

    private void Update()
    {
        Move();
        Plant();
    }

    private void Move()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _direction = new Vector3(_horizontal, 0f, _vertical);
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void Plant()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(_plant, _plantPosition.transform.position, _plantPosition.transform.rotation);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlantGrowUp") && Input.GetKey(KeyCode.R))
        {
            Destroy(other.gameObject);
        }
    }
}