
Imports System.Text
Imports System.Runtime.InteropServices

Namespace DisplayControl

    Public Class DisplayControl




        Public Function getMonitors() As NativeStructures.PHYSICAL_MONITOR()

            ' Get the right monitor
            Dim right As New NativeStructures.tagPOINT()
            right.x = 2000
            right.y = 0
            'IntPtr hMonitor = NativeMethods.MonitorFromWindow(helper.Handle, NativeConstants.MONITOR_DEFAULTTONULL);
            Dim hMonitor As IntPtr = NativeMethods.MonitorFromPoint(right, NativeConstants.MONITOR_DEFAULTTONULL)
            Dim lastWin32Error As Integer = Marshal.GetLastWin32Error()

            Dim pdwNumberOfPhysicalMonitors As UInteger = 0UI
            Dim numberOfPhysicalMonitorsFromHmonitor As Boolean = NativeMethods.GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, pdwNumberOfPhysicalMonitors)
            lastWin32Error = Marshal.GetLastWin32Error()

            Dim pPhysicalMonitorArray As NativeStructures.PHYSICAL_MONITOR() = New NativeStructures.PHYSICAL_MONITOR(pdwNumberOfPhysicalMonitors - 1) {}
            Dim physicalMonitorsFromHmonitor As Boolean = NativeMethods.GetPhysicalMonitorsFromHMONITOR(hMonitor, pdwNumberOfPhysicalMonitors, pPhysicalMonitorArray)
            lastWin32Error = Marshal.GetLastWin32Error()

            Return pPhysicalMonitorArray
        End Function

        Public Function cleanupMonitors(pdwNumberOfPhysicalMonitors As UInteger, pPhysicalMonitorArray As NativeStructures.PHYSICAL_MONITOR()) As Boolean
            Return NativeMethods.DestroyPhysicalMonitors(pdwNumberOfPhysicalMonitors, pPhysicalMonitorArray)
        End Function

    End Class

    Public Class NativeMethods
        <DllImport("user32.dll", EntryPoint:="MonitorFromWindow", SetLastError:=True)> _
        Public Shared Function MonitorFromWindow(<[In]> hwnd As IntPtr, dwFlags As UInteger) As IntPtr
        End Function

        <DllImport("user32.dll", EntryPoint:="MonitorFromPoint", SetLastError:=True)> _
        Public Shared Function MonitorFromPoint(<[In]> pt As NativeStructures.tagPOINT, dwFlags As UInteger) As IntPtr
        End Function

        <DllImport("dxva2.dll", EntryPoint:="GetNumberOfPhysicalMonitorsFromHMONITOR", SetLastError:=True)> _
        Public Shared Function GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor As IntPtr, ByRef pdwNumberOfPhysicalMonitors As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("dxva2.dll", EntryPoint:="GetPhysicalMonitorsFromHMONITOR", SetLastError:=True)> _
        Public Shared Function GetPhysicalMonitorsFromHMONITOR(hMonitor As IntPtr, dwPhysicalMonitorArraySize As UInteger, <Out> pPhysicalMonitorArray As NativeStructures.PHYSICAL_MONITOR()) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("dxva2.dll", EntryPoint:="DestroyPhysicalMonitors", SetLastError:=True)> _
        Public Shared Function DestroyPhysicalMonitors(dwPhysicalMonitorArraySize As UInteger, <Out> pPhysicalMonitorArray As NativeStructures.PHYSICAL_MONITOR()) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("gdi32.dll", EntryPoint:="DDCCIGetCapabilitiesStringLength", SetLastError:=True)> _
        Public Shared Function DDCCIGetCapabilitiesStringLength(<[In]> hMonitor As IntPtr, ByRef pdwLength As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("gdi32.dll", EntryPoint:="DDCCIGetCapabilitiesString", SetLastError:=True)> _
        Public Shared Function DDCCIGetCapabilitiesString(<[In]> hMonitor As IntPtr, pszString As StringBuilder, dwLength As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function


        <DllImport("gdi32.dll", EntryPoint:="DDCCIGetVCPFeature", SetLastError:=True)> _
        Public Shared Function DDCCIGetVCPFeature(<[In]> hMonitor As IntPtr, <[In]> dwVCPCode As UInteger, pvct As UInteger, ByRef pdwCurrentValue As UInteger, ByRef pdwMaximumValue As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("dxva2.dll", EntryPoint:="GetVCPFeatureAndVCPFeatureReply", SetLastError:=True)> _
        Public Shared Function GetVCPFeatureAndVCPFeatureReply(<[In]> hMonitor As IntPtr, <[In]> dwVCPCode As UInteger, pvct As UInteger, ByRef pdwCurrentValue As UInteger, ByRef pdwMaximumValue As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function


        <DllImport("dxva2.dll", EntryPoint:="SetVCPFeature", SetLastError:=True)> _
        Public Shared Function SetVCPFeature(<[In]> hMonitor As IntPtr, dwVCPCode As UInteger, dwNewValue As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function
    End Class

    Public Class NativeConstants
        Public Const MONITOR_DEFAULTTOPRIMARY As Integer = 1

        Public Const MONITOR_DEFAULTTONEAREST As Integer = 2

        Public Const MONITOR_DEFAULTTONULL As Integer = 0
    End Class

    Public Class NativeStructures
        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
        Public Structure PHYSICAL_MONITOR
            Public hPhysicalMonitor As IntPtr

            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)> _
            Public szPhysicalMonitorDescription As String
        End Structure

        Public Structure tagPOINT
            Public x As Integer
            Public y As Integer
        End Structure
    End Class
End Namespace




