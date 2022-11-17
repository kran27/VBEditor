#Region "Filetype Classes"
' Classes containing the headers used by that file type, in the order they should be put back into a new file.
Public Class Map
    Property EMAP As EMAPc
    Property EME2 As List(Of EME2c)
    Property EMEP As List(Of EMEPc)
    Property ECAM As ECAMc
    Property Triggers As List(Of Trigger)
    Property EPTH As List(Of EPTHc)
    Property EMSD As List(Of EMSDc)
    Property EMNP As Byte() ' EMNP never changes, doesn't need unique class.
    Property EMEF As List(Of EMEFc)
End Class
Public Class CRT
    Property EEN2 As EEN2c
    Property GENT As GENTc
    Property GCRE As GCREc
    Property GCHR As GCHRc
End Class
#End Region
#Region "Header Classes"
' Classes to hold the data in easily manipulatable format
Public Class Trigger
    ' Triggers are made of 3 different headers (separate, unlike EME2 and EEOV), so there is a class to hold both types so they aren't separated.
    Property EMTR As EMTRc
    Property ExTR As ExTRc
    Sub New()
        EMTR = New EMTRc()
        ExTR = New ExTRc()
    End Sub
End Class
Public Class EMAPc
    Property s1 As String
    Property s2 As String
    Property s3 As String
    Property col As Color
    Property il As Boolean
    Property le As Integer
    Sub New()
        s1 = ""
        s2 = ""
        s3 = ""
        col = Color.Black
        il = False
        le = 0
    End Sub
End Class
Public Class EME2c
    Property name As String
    Property l As Point4
    Property EEOV As EEOVc
    Sub New()
        name = ""
        l = New Point4(0, 0, 0, 0)
        EEOV = New EEOVc()
    End Sub
End Class
Public Class EEOVc
    Property s1 As String
    Property s2 As String
    Property s3 As String
    Property s4 As String
    Property ps4 As Integer
    Property s5 As String
    Property inv As String()
    Sub New()
        s1 = ""
        s2 = ""
        s3 = ""
        s4 = ""
        ps4 = 0
        s5 = ""
        inv = New String() {}
    End Sub
End Class
Public Class EMEPc
    Property index As Integer
    Property p As Point4
    Sub New()
        index = 0
        p = New Point4(0, 0, 0, 0)
    End Sub
End Class
Public Class ECAMc
    Property p As Point4
    Sub New()
        p = New Point4(0, 0, 0, 0)
    End Sub
End Class
Public Class EMEFc
    Property s1 As String
    Property s2 As String
    Property l As Point4
    Sub New()
        s1 = ""
        s2 = ""
        l = New Point4(0, 0, 0, 0)
    End Sub
End Class
Public Class EMSDc
    Property s1 As String
    Property l As Point3
    Property s2 As String
    Sub New()
        s1 = ""
        l = New Point3(0, 0, 0)
        s2 = ""
    End Sub
End Class
Public Class EPTHc
    Property name As String
    Property p As List(Of Point4)
    Sub New()
        name = ""
        p = New List(Of Point4) From {New Point4(0, 0, 0, 0)}
    End Sub
End Class
Public Class EMTRc
    Property n As Integer
    Property r As List(Of Point3)
    Sub New()
        n = 0
        r = New List(Of Point3) From {New Point3(0, 0, 0)}
    End Sub
End Class

Public Class ExTRc ' Called ExTR instead of E(T/S/B)TR for easier handling within triggers
    Property type As String ' So we know which file is being created, T, S, or B. (or M, but it's ignored if that happens)
    Property s As String
    Sub New()
        type = "T"
        s = ""
    End Sub
End Class

Public Class EEN2c

End Class
Public Class GENTc
    Property HoverSR As Integer ' String used when moused over
    Property LookSR As Integer ' String used when "Look" option is used
    Property NameSR As Integer ' String of the entities' name
    Property Look2SR As Integer ' String seemingly also
    Property Health As Integer
End Class
Public Class GCREc
    Property Special As Special
    Property Skills As List(Of Skill)
    Property GWAM As List(Of GWAMc)
End Class
Public Class GWAMc
    Property sr As Integer
End Class
Public Class GCHRc
    Property name As String
End Class
#End Region
#Region "Other Classes"
Public Class Point3
    Property x As Single
    Property z As Single
    Property y As Single
    Sub New(x As Single, z As Single, y As Single)
        Me.x = x
        Me.z = z
        Me.y = y
    End Sub
End Class
Public Class Point4
    Property x As Single
    Property z As Single
    Property y As Single
    Property r As Single
    Sub New(x As Single, z As Single, y As Single, r As Single)
        Me.x = x
        Me.z = z
        Me.y = y
        Me.r = r
    End Sub
End Class
Public Class Special
    Property S As Integer
    Property P As Integer
    Property E As Integer
    Property C As Integer
    Property I As Integer
    Property A As Integer
    Property L As Integer
    Sub New(S As Integer, P As Integer, E As Integer, C As Integer, I As Integer, A As Integer, L As Integer)
        Me.S = S
        Me.P = P
        Me.E = E
        Me.C = C
        Me.I = I
        Me.A = A
        Me.L = L
    End Sub
End Class
Public Class Skill
    Property Value As Integer
    Property Index As Integer
    Sub New(Value As Integer, Index As Integer)
        Me.Value = Value
        Me.Index = Index
    End Sub
End Class
#End Region