using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscudoProtector : MonoBehaviour
{
    private float time;

    public float timeToEscudo;
    public Image imgHab;
    private RectTransform rectTransform;

    private Vector2 tamanoInicial;
    private Vector2 tamanoFinal;
    public float duracionAnimacion = 5f;

    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        time = timeToEscudo;
        rectTransform = imgHab.GetComponent<RectTransform>();

        tamanoInicial = rectTransform.sizeDelta;
        tamanoFinal = new Vector2(52.9972f, 52.9972f);
        StartCoroutine(AnimarAumento());

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            time = 0;
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                StartCoroutine(Habilidad());
                StartCoroutine(AnimarCambioTamano());

            }
        }
    }

    private IEnumerator Habilidad()
    {

        isActive = true;
        

        yield return new WaitForSeconds(5);
        time = timeToEscudo;
        isActive = false;
        StartCoroutine(AnimarAumento());
    }


    private IEnumerator AnimarAumento()
    {
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionAnimacion)
        {
            // Calcular el factor de progreso de la animaci�n
            float progreso = tiempoPasado / duracionAnimacion;

            // Calcular el tama�o actual interpolando entre el tama�o inicial y final
            Vector2 tama�oActual = Vector2.Lerp(tamanoInicial, tamanoFinal, progreso);

            // Actualizar el tama�o de la imagen
            rectTransform.sizeDelta = tama�oActual;

            // Incrementar el tiempo transcurrido
            tiempoPasado += Time.deltaTime;

            yield return null;
        }

        // Asegurarse de establecer el tama�o final exacto despu�s de la animaci�n
        rectTransform.sizeDelta = tamanoFinal;

        Debug.Log("Animaci�n completada");
    }


    private IEnumerator AnimarCambioTamano()
    {
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionAnimacion)
        {
            // Calcular el factor de progreso de la animaci�n
            float progreso = tiempoPasado / duracionAnimacion;

            // Calcular el tama�o actual interpolando entre el tama�o inicial y final
            Vector2 tama�oActual = Vector2.Lerp(tamanoFinal, tamanoInicial, progreso);

            // Actualizar el tama�o de la imagen
            rectTransform.sizeDelta = tama�oActual;

            // Incrementar el tiempo transcurrido
            tiempoPasado += Time.deltaTime;

            yield return null;
        }

        // Asegurarse de establecer el tama�o final exacto despu�s de la animaci�n
        rectTransform.sizeDelta = tamanoInicial;

        Debug.Log("Animaci�n completada");
    }
}
