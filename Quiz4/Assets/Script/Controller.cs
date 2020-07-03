using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject plane;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject ColorSliders;
    [SerializeField] GameObject BlurBtns;
    [SerializeField] Material SinWave;
    [SerializeField] Material ChangeColor;

    [SerializeField] Material BaseScale;
    [SerializeField] Material GrayScale;
    [SerializeField] Material NegativeScale;
    [SerializeField] Material BlendImage;

    [SerializeField] BlurEffect Blur;
    Renderer planeRender, cubeRender;

    float speed;
    // Start is called before the first frame update
    void Start()
    {
        plane.SetActive(true);
        cube.SetActive(false);
        ColorSliders.SetActive(false);
        BlurBtns.SetActive(false);
        planeRender = plane.GetComponent<Renderer>();
        cubeRender = cube.GetComponent<Renderer>();
        planeRender.material = SinWave;
        ChangeColor.color = new Color(1, 1, 1, 1);
        speed = 1;
        Blur.enabled = false;
    }

    IEnumerator CorcoutineColorChange()
    {
        while (true)
        {
            Color newColor;
            int R, G, B;
            R = (int)(ChangeColor.color.r * 255);
            G = (int)(ChangeColor.color.g * 255);
            B = (int)(ChangeColor.color.b * 255);

            float r, g, b;
            r = ((R + 3) % 255) / 255f;
            g = ((G + 5) % 255) / 255f;
            b = ((B + 7) % 255) / 255f;
            
            newColor = new Color(r, g, b, 1);
            ChangeColor.color = newColor;
            float waitTime = (2.5f - speed) * 0.2f;
            yield return new WaitForSeconds(waitTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectState(int index)
    {
        plane.SetActive(false);
        cube.SetActive(false);
        ColorSliders.SetActive(false);
        BlurBtns.SetActive(false);
        planeRender.material = BaseScale;
        cubeRender.material = BaseScale;
        Blur.enabled = false;
        StopAllCoroutines();
        switch (index)
        {
            case 0:
                plane.SetActive(true);
                planeRender.material = SinWave;
                break;
            case 1:
                plane.SetActive(true);
                ColorSliders.SetActive(true);
                planeRender.material = ChangeColor;
                StartCoroutine(CorcoutineColorChange());
                break;
            case 2:
                cube.SetActive(true);
                cubeRender.material = NegativeScale;
                break;
            case 3:
                cube.SetActive(true);
                cubeRender.material = GrayScale;
                break;
            case 4:
                plane.SetActive(true);
                cube.SetActive(true);
                BlurBtns.SetActive(true);
                break;
            case 5:
                cube.SetActive(true);
                cubeRender.material = BlendImage;
                break;
            default:
                break;
        }
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void BlurOn()
    {
        Blur.enabled = true;
    }

    public void BlurOff()
    {
        Blur.enabled = false;
    }
}
