using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityCoreBluetoothFramework;

public class HeartRateScript : MonoBehaviour
{

    Text heartRate;

    // Start is called before the first frame update
    void Start()
    {
        heartRate = GetComponent<Text> ();

        UnityCoreBluetooth.CreateSharedInstance();

        UnityCoreBluetooth.Shared.OnUpdateState((string state) =>
        {
            Debug.Log("Bluetooth turned: " + state);
            if (state != "poweredOn") return;
            UnityCoreBluetooth.Shared.StartScan();
        });

        UnityCoreBluetooth.Shared.OnDiscoverPeripheral((UnityCBPeripheral peripheral) =>
        {
            Debug.Log("Discovered peripheral: " + peripheral.name);
            if (peripheral.name == "Polar OH1 72838626")
            {
                UnityCoreBluetooth.Shared.StopScan();
                UnityCoreBluetooth.Shared.Connect(peripheral);
            }
        });

        UnityCoreBluetooth.Shared.OnConnectPeripheral((UnityCBPeripheral peripheral) =>
        {
            Debug.Log("Connected to: " + peripheral.name);
            peripheral.discoverServices();
        });

        UnityCoreBluetooth.Shared.OnDiscoverService((UnityCBService service) =>
        {
            if (service.uuid != "180D") return;
            Debug.Log("Discovered service: " + service.uuid);
            service.discoverCharacteristics();
        });


        UnityCoreBluetooth.Shared.OnDiscoverCharacteristic((UnityCBCharacteristic characteristic) =>
        {
            string uuid = characteristic.uuid;
            string usage = characteristic.propertis[0];
            Debug.Log("Discovered characteristic: " + uuid + ", usage: " + usage);
            if (usage != "notify") return;
            characteristic.setNotifyValue(true);
        });

        UnityCoreBluetooth.Shared.OnUpdateValue((UnityCBPeripheral peripheral, UnityCBCharacteristic characteristic, byte[] data) =>
        {

            Debug.Log("Heart rate: " + data[1] + " from peripheral:" + peripheral.name);
            this.heartRate = data[1];
        });
        UnityCoreBluetooth.Shared.StartCoreBluetooth();
    }

    private byte heartRate = 0;

    // Update is called once per frame
    void Update()
    {
        heartRate.text = "HR: " + Player.heartRate;
    }
}
