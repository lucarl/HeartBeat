using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCoreBluetoothFramework;


namespace PolarConnection
{
    public class BluetoothScript : MonoBehaviour {
        private static string player1PolarBand = "Polar OH1 72838626";
        private static string player2PolarBand = "Polar OH1 72852D2D";

        public static bool player1Connected = false;
        public static bool player2Connected = false;

        public static byte player1HR = 0;
        public static byte player2HR = 0;

        public static void disconnectFromPolar()
        {
            UnityCoreBluetooth.ReleaseSharedInstance();
        }

        public static void connectToPolar()
        {
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
                if (peripheral.name == player1PolarBand || peripheral.name == player2PolarBand)
                {
                    if (peripheral.name == player1PolarBand && player2Connected ||
                        peripheral.name == player2PolarBand && player1Connected)
                    {
                        UnityCoreBluetooth.Shared.StopScan();
                    }
                    UnityCoreBluetooth.Shared.Connect(peripheral);
                }
            });

            UnityCoreBluetooth.Shared.OnConnectPeripheral((UnityCBPeripheral peripheral) =>
            {
                if (peripheral.name == player1PolarBand)
                {
                    player1Connected = true;
                }
                else if (peripheral.name == player2PolarBand)
                {
                    player2Connected = true;
                }

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
                if (peripheral.name == player1PolarBand)
                {
                    player1HR = data[1];
                }
                else if (peripheral.name == player2PolarBand)
                {
                    player2HR = data[1];
                }


            });
            UnityCoreBluetooth.Shared.StartCoreBluetooth();
        }
    }
}

