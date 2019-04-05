using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class DvizenjeBratu : MonoBehaviour
{
    Controller controller;
    float HandPalmPitch;
    float HandPalmYaw;
    float HandPalmRoll_1;
    float HandPalmRoll_2;
    float HandWristRot;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller = new Controller();
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;

        if (frame.Hands.Count > 0)
        {
            Hand firsthand = hands[0];
        }

        HandPalmPitch = hands[0].PalmNormal.Pitch;
        HandPalmRoll_1 = hands[0].PalmNormal.Roll;
        HandPalmYaw = hands[0].PalmNormal.Yaw;
        HandPalmRoll_2 = hands[1].PalmNormal.Roll;
        HandWristRot = hands[0].WristPosition.Pitch;

        //ova ide nagore
        
        if (HandPalmYaw > -2f && HandPalmYaw < 3.5f)
        {
            transform.Translate(new Vector3(0, 0, 0.5f * Time.deltaTime));

        }
        //ova ide nadole
        else if (HandPalmYaw < -2.8f)
        {
            transform.Translate(new Vector3(0, 0, -0.5f * Time.deltaTime));
        }
        
        //ova ide na desno ama rakata na levo navalena
         if(HandPalmRoll_1 > 0.5f && HandPalmRoll_1 < 1.8f)
        {
            transform.Translate(new Vector3(-0.5f * Time.deltaTime, 0, 0));
        }
        //ova ide na levo ama rakata navalena na desno
        else if(HandPalmRoll_2 < -0.5f && HandPalmRoll_2 > -1.8f)
        {
            transform.Translate(new Vector3(0.5f * Time.deltaTime, 0, 0));
        }

        Debug.Log("Pithc:" + HandPalmPitch);
        Debug.Log("Yaw:" + HandPalmYaw);
        

    }
}
