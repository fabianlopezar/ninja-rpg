using UnityEngine;
public class PersonajeAnimaciones : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCaminar;

    private Animator _animator;
    private PersonajeMovimiento _personajeMovimiento;
    private readonly int direccionX = Animator.StringToHash("X");
    private readonly int direccionY = Animator.StringToHash("Y");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _personajeMovimiento = GetComponent<PersonajeMovimiento>();
    }

    void Update()
    {
        ActualizarLayers();
        if (!_personajeMovimiento.EnMovimiento)
        {
            return;
        }
        //cambiar direccion del personaje
        _animator.SetFloat(direccionX, _personajeMovimiento.DireccionMovimiento.x);
        _animator.SetFloat(direccionY, _personajeMovimiento.DireccionMovimiento.y);
    }
    private void ActivarLayer(string nombreLayer)
    {   // _animator.layerCount --> me dice cuantos layers tengo actualmente.
        for (int i = 0; i < _animator.layerCount; i++)
        {
            //_animator.SetLayerWeight() --> activa o desactiva  
            //primer parametro indica la posicion, segundo parametro recibe 1 || 0 activar o desactivar.
            _animator.SetLayerWeight(i,0);
        }
        _animator.SetLayerWeight(_animator.GetLayerIndex(nombreLayer),1);
    }
    private void ActualizarLayers()
    {
        if (_personajeMovimiento.EnMovimiento)
        {
            ActivarLayer(layerCaminar);
        }
        else
        {
            ActivarLayer(layerIdle);
        }
    }
}
