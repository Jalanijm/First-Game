using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDresser : MonoBehaviour
{
    [Header("OverlapBox parameters")]
    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectorSize = Vector2.one;
    public Vector2 detectorOriginOffset = Vector2.zero;

    public float detectionDelay = 0.2f;

    public LayerMask detectorLayerMask;

    [Header("Gizmo parameters")]
    public Color gizmoIdleColor = Color.green;
    public Color gizmoDetectedColor = Color.red;
    public bool showGizmos = true;
    bool inRange = false;
    bool menuOpen = false;

    public GameObject MenuUI;
    public GameObject DisplayUI;

    public GameObject Special1Locked;
    public GameObject Special1Unlocked;

    public GameObject Special2Locked;
    public GameObject Special2Unlocked;

    public GameObject Special3Locked;
    public GameObject Special3Unlocked;

    public Sprite Opened;
    public Sprite Closed;

    private SpriteRenderer Default;

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        PerformDetection();
        StartCoroutine(DetectionCoroutine());
    }

    public void PerformDetection()
    {
        Collider2D collider = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);

        if (collider != null)
        {
            inRange = true;
            if (menuOpen == false && inRange == true)
            {
                DisplayUI.SetActive(true);

            }
        }
        else if (collider == null)
        {
            inRange = false;
            DisplayUI.SetActive(false);


        }
    }


    private void OnDrawGizmos()
    {
        if (showGizmos && detectorOrigin != null)
        {
            Gizmos.color = gizmoIdleColor;
            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
        }
    }
    void Update()
    {
        Default = GetComponent<SpriteRenderer>();

        if (Input.GetKeyDown(KeyCode.E) && inRange == true && menuOpen == false)
        {
            menuOpen = true;
            Default.sprite = Opened;

        }
        else if (Input.GetKeyDown(KeyCode.E) && inRange == true && menuOpen == true)
        {
            menuOpen = false;
            Default.sprite = Closed;

        }
        else if (inRange == false)
        {
            menuOpen = false;
            Default.sprite = Closed;
            DisplayUI.SetActive(false);

        }

        if (menuOpen == true)
        {
            MenuUI.SetActive(true);
            Cursor.visible = true;
            DisplayUI.SetActive(false);

        }
        else if (menuOpen == false && inRange == true)
        {
            MenuUI.SetActive(false);
            DisplayUI.SetActive(true);
        }
        else if (menuOpen == false)
        {
            MenuUI.SetActive(false);
        }

        //Stage 3 Clear
        if (PlayerPrefs.GetInt("Stage 3") == 1)
        {
            Special1Unlocked.SetActive(true);
            Special1Locked.SetActive(false);

            Special2Unlocked.SetActive(true);
            Special2Locked.SetActive(false);

            Special3Unlocked.SetActive(true);
            Special3Locked.SetActive(false);
        }
        else
        {
            Special1Unlocked.SetActive(false);
            Special1Locked.SetActive(true);

            Special2Unlocked.SetActive(false);
            Special2Locked.SetActive(true);

            Special3Unlocked.SetActive(false);
            Special3Locked.SetActive(true);
        }


    }

    public void ExitGame()
    {
        Application.Quit();
    }

    //Skin
    public void Skin1()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectSkin = 1;
    }

    public void Skin2()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectSkin = 2;
    }

    public void Skin3()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectSkin = 3;
    }

    public void Skin4()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectSkin = 4;
    }

    public void Skin5()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectSkin = 5;
    }

    public void Skin6()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectSkin = 6;
    }

    public void Skin7()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectSkin = 7;
    }

    public void Skin8()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectSkin = 8;
    }

    public void Skin9()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectSkin = 9;
    }

    //Hair
    public void Hair1()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 1;
    }

    public void Hair2()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 2;
    }

    public void Hair3()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 3;
    }

    public void Hair4()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 4;
    }

    public void Hair5()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 5;
    }

    public void Hair6()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 6;
    }

    public void Hair7()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 7;
    }

    public void Hair8()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 8;
    }

    public void Hair9()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 9;
    }

    public void Hair10()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 10;
    }

    public void Hair11()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 11;
    }

    public void Hair12()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 12;
    }

    public void Hair13()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 13;
    }

    public void Hair14()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 14;
    }

    public void Hair15()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 15;
    }

    public void Hair16()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 16;
    }

    public void Hair17()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 17;
    }

    public void Hair18()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 18;
    }

    public void Hair19()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 19;
    }

    public void Hair20()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 20;
    }

    public void Hair21()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 21;
    }

    public void Hair22()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 22;
    }

    public void Hair23()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 23;
    }

    public void Hair24()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 24;
    }

    public void Hair25()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 25;
    }

    public void Hair26()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 26;
    }

    public void Hair27()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 27;
    }

    public void Hair28()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 28;
    }

    public void Hair29()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 29;
    }

    public void Hair30()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 30;
    }

    public void Hair31()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 31;
    }

    public void Hair32()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 32;
    }

    public void Hair33()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 33;
    }

    public void Hair34()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 34;
    }

    public void Hair35()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 35;
    }

    public void Hair36()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 36;
    }
    public void Hair37()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 37;
    }

    public void Hair38()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 38;
    }

    public void Hair39()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 39;
    }

    public void Hair40()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 40;
    }

    public void Hair41()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 41;
    }

    public void Hair42()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 42;
    }

    public void Hair43()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 43;
    }

    public void Hair44()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 44;
    }

    public void Hair45()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 45;
    }

    public void Hair46()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 46;
    }

    public void Hair47()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 47;
    }

    public void Hair48()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 48;
    }

    public void Hair49()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 49;
    }

    public void Hair50()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 50;
    }
    public void Hair51()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 51;
    }
    public void Hair52()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 52;
    }
    public void Hair53()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 53;
    }
    public void Hair54()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 54;
    }
    public void Hair55()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 55;
    }

    public void Hair56()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 56;
    }
    public void Hair57()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 57;
    }
    public void Hair58()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 58;
    }
    public void Hair59()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectHair = 59;
    }

    //Outfits
    public void Outfit1()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 1;
    }

    public void Outfit2()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 2;
    }

    public void Outfit3()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 3;
    }

    public void Outfit4()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 4;
    }

    public void Outfit5()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 5;
    }

    public void Outfit6()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 6;
    }

    public void Outfit7()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 7;
    }

    public void Outfit8()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 8;
    }

    public void Outfit9()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 9;
    }

    public void Outfit10()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 10;
    }

    public void Outfit11()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 11;
    }

    public void Outfit12()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 12;
    }

    public void Outfit13()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 13;
    }

    public void Outfit14()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 14;
    }

    public void Outfit15()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 15;
    }

    public void Outfit16()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 16;
    }

    public void Outfit17()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 17;
    }

    public void Outfit18()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 18;
    }

    public void Outfit19()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 19;
    }

    public void Outfit20()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 20;
    }

    public void Outfit21()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 21;
    }

    public void Outfit22()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 22;
    }

    public void Outfit23()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 23;
    }

    public void Outfit24()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 24;
    }

    public void Outfit25()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 25;
    }

    public void Outfit26()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 26;
    }

    public void Outfit27()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 27;
    }

    public void Outfit29()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectOutfit = 29;
    }

    //Pants
    public void Pants1()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 1;
    }

    public void Pants2()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 2;
    }

    public void Pants3()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 3;
    }

    public void Pants4()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 4;
    }

    public void Pants5()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 5;
    }

    public void Pants6()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 6;
    }

    public void Pants7()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 7;
    }

    public void Pants8()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 8;
    }

    public void Pants9()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 9;
    }

    public void Pants10()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 10;
    }

    public void Pants11()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 11;
    }

    public void Pants12()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 12;
    }

    public void Pants13()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 13;
    }

    public void Pants14()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 14;
    }

    public void Pants15()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 15;
    }

    public void Pants16()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 16;
    }

    public void Pants17()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 17;
    }

    public void Pants18()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 18;
    }

    public void Pants19()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 19;
    }

    public void Pants20()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 20;
    }

    public void Pants21()
    {
        GameObject Body = GameObject.FindWithTag("PlayerFullBody");
        Body.GetComponent<PlayerMovement>().SelectPants = 21;
    }

    public void MenuExit()
    {
        menuOpen = false;
    }
}
