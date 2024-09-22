using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class SimulatorDisabler : MonoBehaviour
{
  private XRDeviceSimulator simulator;

  private void Awake()
  {
    simulator = GetComponentInChildren<XRDeviceSimulator>();
  }

  void Start()
  {
    var inputDevices = new List<UnityEngine.XR.InputDevice>();
    UnityEngine.XR.InputDevices.GetDevices(inputDevices);

    if (inputDevices.Count > 0)
    {
      simulator.enabled = false;
      print($"XR Device detected; disabling XR Simulator");
    }
  }

}
