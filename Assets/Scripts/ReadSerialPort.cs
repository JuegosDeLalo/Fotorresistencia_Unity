using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class ReadSerialPort : MonoBehaviour
{
    SerialPort SP1 = new SerialPort();
    // [SerializeField] string serialPort;

    [SerializeField] Light iluminación;
    void Awake()
    {

        SP1.PortName = "COM3";
        SP1.BaudRate = 9600;
        SP1.ReadTimeout = 100;

    }
    // Start is called before the first frame update
    void Start()
    {
        SP1.Open(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        var iluminacionArduino = float.Parse( SP1.ReadLine());
        var iluminacionTotal = 1 - ((1*iluminacionArduino)/1024);
        iluminación.intensity = iluminacionTotal;

        print(iluminacionTotal);
    }
}
