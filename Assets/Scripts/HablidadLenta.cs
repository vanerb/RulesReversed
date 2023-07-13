using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HablidadLenta : MonoBehaviour
{
    public float timeToObtain;
    private float time;
    public static bool isActive = false;
    public Animator anim;
    public Image imgHab;
    private RectTransform rectTransform;

    private Vector2 tamanoInicial;
    private Vector2 tamanoFinal;
    public float duracionAnimacion = 3f;
    // Start is called before the first frame update
    void Start()
    {
        time = timeToObtain;
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
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                StartCoroutine(Restaurar());
                StartCoroutine(AnimarCambioTamano());

            }
        }
    }

    IEnumerator Restaurar()
    {
        isActive = true;
        Time.timeScale = 0.5f;
        GetComponent<GravityControl>().gravityScalePos = 0.5f;
        GetComponent<GravityControl>().gravityScaleNeg = -0.5f;
        rectTransform.sizeDelta = new Vector2(0, 0);

        yield return new WaitForSeconds(3f);
        time = timeToObtain;
        GetComponent<GravityControl>().gravityScalePos = 1;
        GetComponent<GravityControl>().gravityScaleNeg = -1;
        Time.timeScale =1f;
        isActive = false;
        StartCoroutine(AnimarAumento());
    }

    private IEnumerator AnimarAumento()
    {
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionAnimacion)
        {
            // Calcular el factor de progreso de la animación
            float progreso = tiempoPasado / duracionAnimacion;

            // Calcular el tamaño actual interpolando entre el tamaño inicial y final
            Vector2 tamañoActual = Vector2.Lerp(tamanoInicial, tamanoFinal, progreso);

            // Actualizar el tamaño de la imagen
            rectTransform.sizeDelta = tamañoActual;

            // Incrementar el tiempo transcurrido
            tiempoPasado += Time.deltaTime;

            yield return null;
        }

        // Asegurarse de establecer el tamaño final exacto después de la animación
        rectTransform.sizeDelta = tamanoFinal;

        Debug.Log("Animación completada");
    }


    private IEnumerator AnimarCambioTamano()
    {
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionAnimacion)
        {
            // Calcular el factor de progreso de la animación
            float progreso = tiempoPasado / duracionAnimacion;

            // Calcular el tamaño actual interpolando entre el tamaño inicial y final
            Vector2 tamañoActual = Vector2.Lerp(tamanoFinal, tamanoInicial, progreso);

            // Actualizar el tamaño de la imagen
            rectTransform.sizeDelta = tamañoActual;

            // Incrementar el tiempo transcurrido
            tiempoPasado += Time.deltaTime;

            yield return null;
        }

        // Asegurarse de establecer el tamaño final exacto después de la animación
        rectTransform.sizeDelta = tamanoInicial;

        Debug.Log("Animación completada");
    }
}
