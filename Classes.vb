#Region "Filetype Classes"
' Classes containing the headers used by that file type, in the order they should be put back into a new file.
Public Class Map
    Property EMAP As EMAPc
    Property EME2 As List(Of EME2c)
    Property EMEP As List(Of EMEPc)
    Property ECAM As ECAMc
    ' First Possible 2MWT
    Property _2MWT As _2MWTc
    Property Triggers As List(Of Trigger)
    Property EPTH As List(Of EPTHc)
    Property EMSD As List(Of EMSDc)
    ' Last Possible 2MWT
    ' EMNP
    Property EMEF As List(Of EMEFc)
    Sub New()
        EMAP = New EMAPc()
        EMEP = New List(Of EMEPc)
        EME2 = New List(Of EME2c)
        EMEF = New List(Of EMEFc)
        EMSD = New List(Of EMSDc)
        EPTH = New List(Of EPTHc)
        Triggers = New List(Of Trigger)
        ECAM = Nothing
        _2MWT = New _2MWTc()
    End Sub
End Class
Public Class CRT
    Property EEN2 As EEN2c
    Property GENT As GENTc
    Property GCRE As GCREc
    Property GCHR As GCHRc
    Sub New()
        EEN2 = New EEN2c()
        GENT = New GENTc()
        GCRE = New GCREc()
        GCHR = New GCHRc()
    End Sub
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
    Property skl As String
    Property invtex As String
    Property acttex As String
    Property sel As Boolean
    Property EEOV As EEOVc
    Sub New()
        skl = ""
        invtex = ""
        acttex = ""
        sel = False
        EEOV = New EEOVc()
    End Sub
End Class
Public Class GENTc
    Property HoverSR As Integer ' String used when moused over
    Property LookSR As Integer ' String used when "Look" option is used
    Property NameSR As Integer ' String of the entities' name
    Property UnkwnSR As Integer ' String used ???
    Property MaxHealth As Integer
    Property StartHealth As Integer
    Sub New()
        HoverSR = 0
        LookSR = 0
        NameSR = 0
        UnkwnSR = 0
        MaxHealth = 0
        StartHealth = 0
    End Sub
End Class
Public Class GCREc
    Property Special As Integer()
    Property Age As Integer
    Property Skills As List(Of Skill)
    Property Traits As List(Of Integer)
    Property TagSkills As List(Of Integer)
    Property PortStr As String
    Property Hea As Socket
    Property Hai As Socket
    Property Pon As Socket
    Property Mus As Socket
    Property Bea As Socket
    Property Eye As Socket
    Property Bod As Socket
    Property Han As Socket
    Property Fee As Socket
    Property Bac As Socket
    Property Sho As Socket
    Property Van As Socket
    Property Inventory As String()
    Property GWAM As List(Of GWAMc)
    Sub New()
        Special = New Integer() {0, 0, 0, 0, 0, 0, 0}
        Age = 0
        Skills = New List(Of Skill)
        Traits = New List(Of Integer)
        TagSkills = New List(Of Integer)
        PortStr = ""
        Hea = New Socket("", "")
        Hai = New Socket("", "")
        Pon = New Socket("", "")
        Mus = New Socket("", "")
        Bea = New Socket("", "")
        Eye = New Socket("", "")
        Bod = New Socket("", "")
        Han = New Socket("", "")
        Fee = New Socket("", "")
        Bac = New Socket("", "")
        Sho = New Socket("", "")
        Van = New Socket("", "")
        Inventory = New String() {}
        GWAM = New List(Of GWAMc)
    End Sub
End Class
Public Class GWAMc
    ' Offsets 0x18, 0x20, 0x38, and 0x39 have been observed to have values, none of them appear to affect the function.
    Property Anim As Integer
    Property DmgType As Integer
    Property ShotsFired As Integer
    ' Property u1 As Integer ' Offset 0x18
    Property Range As Integer
    Property MinDmg As Integer
    Property MaxDmg As Integer
    ' Property u2 As Integer ' Offset 0x38
    Property AP As Integer
    Property NameSR As Integer ' Name String Reference
    Property VegName As String
    Sub New()
        Anim = 0
        DmgType = 0
        ShotsFired = 0
        Range = 0
        MinDmg = 0
        MaxDmg = 0
        AP = 0
        NameSR = 0
        VegName = 0
    End Sub
End Class
Public Class GCHRc
    Property name As String
    Sub New()
        name = ""
    End Sub
End Class
Public Class _2MWTc
    Property mpf as String
    Property frozen As Boolean
    Property dark As boolean
    Property chunks As List(Of _2MWTChunk)
    Sub New()
        mpf = ""
        chunks = new List(Of _2MWTChunk)
    End Sub
End Class
#End Region
#Region "Other Classes"
Public Class Point2
    Property x As Single
    Property y As Single
    Sub New(x As Single, y As Single)
        Me.x = x
        Me.y = y
    End Sub
End Class
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
Public Class Skill
    Property Index As Integer
    Property Value As Integer
    Sub New(Index As Integer, Value As Integer)
        Me.Index = Index
        Me.Value = Value
    End Sub
End Class
Public Class Socket
    Property Model As String
    Property Tex As String
    Sub New(Model As String, Tex As String)
        Me.Model = Model
        Me.Tex = Tex
    End Sub
End Class
Public Class _2MWTChunk
    Property tex As String
    Property loc As point3
    Property texloc as Point2
    Sub New(tex As String, loc As point3, texloc As Point2)
        Me.tex = tex
        Me.loc = loc
        Me.texloc = texloc
    End Sub
End Class
#End Region