using UnityEngine;
using UnityEngine.Events; // Necesario para poder usar UnityEvent

/// <summary>
/// Componente que funciona como un interruptor binario (ON/OFF).
/// Invoca diferentes UnityEvents dependiendo de si se activa o desactiva.
/// Puede ser llamado desde botones de UI, triggers de colisión, animaciones, etc.
/// </summary>
public class BinaryEventToggle : MonoBehaviour
{
    [Header("Configuración del Interruptor")]
    [Tooltip("El estado inicial del interruptor cuando el juego comienza. 'false' es OFF, 'true' es ON.")]
    [SerializeField] private bool isToggledOn = false;

    [Header("Eventos")]
    [Tooltip("Eventos que se ejecutarán cuando el estado cambie a ON (activado).")]
    public UnityEvent OnActivate;

    [Tooltip("Eventos que se ejecutarán cuando el estado cambie a OFF (desactivado).")]
    public UnityEvent OnDeactivate;

    /// <summary>
    /// Cambia el estado del interruptor y ejecuta el evento correspondiente.
    /// Este es el método principal que debes llamar desde tus botones o triggers.
    /// </summary>
    public void Toggle()
    {
        // Invierte el estado actual. Si era true, ahora es false, y viceversa.
        isToggledOn = !isToggledOn;

        // Comprueba el nuevo estado y ejecuta el evento apropiado.
        if (isToggledOn)
        {
            Debug.Log(gameObject.name + " ha sido ACTIVADO.", gameObject);
            OnActivate.Invoke();
        }
        else
        {
            Debug.Log(gameObject.name + " ha sido DESACTIVADO.", gameObject);
            OnDeactivate.Invoke();
        }
    }

    /// <summary>
    /// Opcional: Establece el interruptor a un estado específico sin ejecutar los eventos.
    /// Útil para inicializar estados sin disparar la lógica.
    /// </summary>
    public void SetStateWithoutNotify(bool newState)
    {
        isToggledOn = newState;
    }
}
