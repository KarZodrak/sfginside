using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ColorMachine : MonoBehaviour
{

    public GameObject gate;
    public GameObject bucketR;
    public GameObject bucketG;
    public GameObject bucketB;
    public GameObject smoke;
    public GameObject qGeber2;
    public GameObject qGeber3;

    public PostProcessingBehaviour ppBehav;
    public PostProcessingProfile pp_R;
    public PostProcessingProfile pp_G;
    public PostProcessingProfile pp_B;
    public PostProcessingProfile pp_RG;
    public PostProcessingProfile pp_RB;
    public PostProcessingProfile pp_GB;
    public PostProcessingProfile pp_RGB;

    private bool machnieEnabled = false;
    private int colorIndex = 0;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (!machnieEnabled)
        {
            if (colorIndex == 0)
            {
                if (bucketR.activeSelf)
                {
                    ppBehav.profile = pp_R;
                    colorIndex = 1;
                }
                else if (bucketG.activeSelf)
                {
                    ppBehav.profile = pp_G;
                    colorIndex = 1;
                }
                else if (bucketB.activeSelf)
                {
                    ppBehav.profile = pp_B;
                    colorIndex = 1;
                }
            }

            if (colorIndex == 1)
            {
                if (bucketR.activeSelf && bucketG.activeSelf)
                {
                    ppBehav.profile = pp_RG;
                    colorIndex = 2;
                }
                else if (bucketR.activeSelf && bucketB.activeSelf)
                {
                    ppBehav.profile = pp_RB;
                    colorIndex = 2;
                }
                else if (bucketG.activeSelf && bucketB.activeSelf)
                {
                    ppBehav.profile = pp_GB;
                    colorIndex = 2;
                }
            }

            if (bucketR.activeSelf && bucketG.activeSelf && bucketB.activeSelf)
            {
                ppBehav.profile = pp_RGB;
                smoke.SetActive(true);
                qGeber2.SetActive(false);
                qGeber3.SetActive(true);
                gate.SetActive(false);
                machnieEnabled = true;
            }
        }
	}
}
