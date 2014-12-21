Module Program
    Declare Function AttachConsole Lib "kernel32.dll" (ByVal dwProcessId As Int32) As Boolean
    Declare Function FreeConsole Lib "kernel32.dll" () As Boolean

    Public Sub Main()
        Core.EnsureInitialized()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MainForm()) ''//Use your main form here
    End Sub
End Module
