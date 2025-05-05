using KinematicCharacterController;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] GameObject charGround;
    [SerializeField] GameObject camGround;
    [SerializeField] GameObject charSky;
    [SerializeField] GameObject camSky;
    [SerializeField] GameObject binocularsImage;
    bool isGroundCharacter = true;
    // if user presses space, switch between characters

    private Rigidbody rbGround;
    private Rigidbody rbSky;
    private KinematicCharacterMotor kinematicGround;
    private KinematicCharacterMotor kinematicSky;
    private bool isZoomed = false;

    private void Start()
    {
        rbGround = charGround.GetComponent<Rigidbody>();
        rbSky = charSky.GetComponent<Rigidbody>();
        kinematicGround = charGround.GetComponent<KinematicCharacterMotor>();
        kinematicSky = charSky.GetComponent<KinematicCharacterMotor>();
    }

        void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isGroundCharacter = !isGroundCharacter;
        }

        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }


        if (isGroundCharacter)
        {
            camGround.SetActive(true);
            camSky.SetActive(false);
            kinematicGround.enabled = true;
            kinematicSky.enabled = false;
            rbSky.isKinematic = true;
            rbGround.isKinematic = false;
        }
        else
        {
            camGround.SetActive(false);
            camSky.SetActive(true);
            kinematicGround.enabled = false;
            kinematicSky.enabled = true;
            rbSky.isKinematic = false;
            rbGround.isKinematic = true;
        }

        if (isZoomed)
        {
            camGround.GetComponent<Camera>().DOFieldOfView(10f, 1f); //.fieldOfView = 10;
            camSky.GetComponent<Camera>().DOFieldOfView(10f, 1f); //.fieldOfView = 10;
            binocularsImage.SetActive(true);
            binocularsImage.GetComponent<Image>().DOFade(1f, 1f);
            // Debug.Log("Binoculars Fade: " + binocularsImage.color.a);
        }
        else
        {
            camGround.GetComponent<Camera>().DOFieldOfView(60f, 1f);// .fieldOfView = 60;
            camSky.GetComponent<Camera>().DOFieldOfView(60f, 1f);// .fieldOfView = 60;
            binocularsImage.GetComponent<Image>().DOFade(0f, 1f).OnComplete(()=> binocularsImage.SetActive(false));
            ;
            // Debug.Log("Binoculars Fade: " + binocularsImage.color.a);
        }
    }        
}
