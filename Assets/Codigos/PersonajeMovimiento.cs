using UnityEngine;
public class PersonajeMovimiento : MonoBehaviour
{
    /*
    //Con esta linea puedo utilizar la variable desde otro codigo.
    public Vector2 DireccionMovimiento
    {
        get
        {
            return _direccionMovimiento;
        }
    }
    */
    public Vector2 DireccionMovimiento => _direccionMovimiento;
    public bool EnMovimiento => _direccionMovimiento.magnitude > 0f;
    //------------- VARIABLES ---------------------------------------------------
    //SerializeField sirver para no modificarlo en otro codigo y causar errores.
    [SerializeField] private float velocidad;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direccionMovimiento;
    private Vector2 _input;
  
    //----------   Manera Antigua de poder utilizar variables globales.   -----------
     
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //--- X ---
        if(_input.x > 0.1f)
        {
            _direccionMovimiento.x = 1f;
        }else if (_input.x < 0f)
        {
            _direccionMovimiento.x = -1f;
        }
        else
        {
            _direccionMovimiento.x = 0f;
        }
        //--- Y ---
        if (_input.y > 0.1f)
        {
            _direccionMovimiento.y = 1f;
        }
        else if (_input.y < 0f)
        {
            _direccionMovimiento.y = -1f;
        }
        else
        {
            _direccionMovimiento.y = 0f;
        }
    }
    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direccionMovimiento * velocidad * Time.fixedDeltaTime);
    }
}
