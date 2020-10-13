using System.Collections;
using System.Collections.Generic;
using UnityCoreBluetoothFramework;
using UnityEngine;
using UnityEngine.UI;

public class HeartRateScript : MonoBehaviour {

    public static int bpm1;
    public static int bpm2;

    // Start is called before the first frame update
    void Start () {

        UnityCoreBluetooth.CreateSharedInstance ();

        UnityCoreBluetooth.Shared.OnUpdateState ((string state) => {
            Debug.Log ("Bluetooth turned: " + state);
            if (state != "poweredOn") return;
            UnityCoreBluetooth.Shared.StartScan ();
        });

        UnityCoreBluetooth.Shared.OnDiscoverPeripheral ((UnityCBPeripheral peripheral) => {
            Debug.Log ("Discovered peripheral: " + peripheral.name);
            if (peripheral.name == "Polar OH1 72838626" || peripheral.name == "Polar OH1 72852D2D") {
                UnityCoreBluetooth.Shared.StopScan ();
                UnityCoreBluetooth.Shared.Connect (peripheral);
            }
        });

        UnityCoreBluetooth.Shared.OnConnectPeripheral ((UnityCBPeripheral peripheral) => {
            Debug.Log ("Connected to: " + peripheral.name);
            peripheral.discoverServices ();
        });

        UnityCoreBluetooth.Shared.OnDiscoverService ((UnityCBService service) => {
            if (service.uuid != "180D") return;
            Debug.Log ("Discovered service: " + service.uuid);
            service.discoverCharacteristics ();
        });

        UnityCoreBluetooth.Shared.OnDiscoverCharacteristic ((UnityCBCharacteristic characteristic) => {
            string uuid = characteristic.uuid;
            string usage = characteristic.propertis[0];
            Debug.Log ("Discovered characteristic: " + uuid + ", usage: " + usage);
            if (usage != "notify") return;
            characteristic.setNotifyValue (true);
        });

        UnityCoreBluetooth.Shared.OnUpdateValue ((UnityCBPeripheral peripheral, UnityCBCharacteristic characteristic, byte[] data) => {

            if (peripheral.name == "Polar OH1 72852D2D") {
                Debug.Log ("Heart rate: " + data[1] + " from peripheral:" + peripheral.name);
                this.heartRate1 = data[1];
            }

            if (peripheral.name == "Polar OH1 72838626") {
                Debug.Log ("Heart rate: " + data[1] + " from peripheral:" + peripheral.name);
                this.heartRate2 = data[1];
            }

        });
        UnityCoreBluetooth.Shared.StartCoreBluetooth ();
    }

    private byte heartRate1 = 40;
    private byte heartRate2 = 40;

    // Update is called once per frame
    void Update () {
        bpm1 = heartRate1;
        bpm2 = heartRate2;
    }
}