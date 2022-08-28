using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    public static float distanceFromTarget; //etkileşime geçecegimiz nesnelerin uzaklıgı
    public float toTarget; //baktıgımız her nesnenin uzaklıgı 

    

    void Update()
    {
        RaycastHit hit; //ışın demeti oluşturduk

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) //physics bizim görmedigimiz fiziki bir alan/nesne oluşturur.Bizim oluşturdugumuz nesneye çarpıp çarpmadıgını kontrol eder  
        {                                       //transform position karekterin pozyonundan çıkacagını belirtiyoruz ışının
                                                //transform.TransformDirection karekterin yönüne dogru 3 boyutlu dünyada ileriye dogru gitsin
                                                //out ise çıktı olarak ışın demeti olsun diyoruz
                                                //distance uzunluk 

            toTarget = hit.distance;
            distanceFromTarget = toTarget;

        }
    }
}
