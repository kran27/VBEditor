Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports AltUI.Controls

Public Class Form1
    Private f As String
    Private ext As String
    Private m As New Map
    Private Sub LoadFile(sender As Object, e As EventArgs) Handles DarkButton1.Click
        ' Loads all regions of a given file into their respective classes, and from there into the UI
        Dim ofd As New OpenFileDialog With {.Filter = "Van Buren Data File|*.AMO;*.ARM;*.CON;*.CRT;*.DOR;*.INT;*.ITM;*.MAP;*.USE;*.VEG;*.WEA", .Multiselect = False, .ValidateNames = True}
        If ofd.ShowDialog = DialogResult.OK Then
            f = ofd.FileName
            ext = f.Substring(f.LastIndexOf("."), 4)
            Select Case ext
                Case ".amo"
                    MsgBox("Not yet implemented")
                Case ".arm"
                    MsgBox("Not yet implemented")
                Case ".con"
                    MsgBox("Not yet implemented")
                Case ".crt"
                    MsgBox("Not yet implemented")
                Case ".dor"
                    MsgBox("Not yet implemented")
                Case ".int"
                    MsgBox("Not yet implemented")
                Case ".itm"
                    MsgBox("Not yet implemented")
                Case ".map"
                    m.EMAP = f.GetRegions("EMAP")(0).ToEMAPc
                    Button1.BackColor = m.EMAP.col : Button1.FlatAppearance.MouseOverBackColor = m.EMAP.col : Button1.FlatAppearance.MouseDownBackColor = m.EMAP.col
                    DarkTextBox1.Text = m.EMAP.s1
                    DarkTextBox2.Text = m.EMAP.s2
                    DarkTextBox3.Text = m.EMAP.s3
                    DarkCheckBox1.Checked = m.EMAP.il

                    'm.EME2 = f.GetRegions("EME2")

                    'm.EMEP = f.GetRegions("EMEP")

                    'm.ECAM = f.GetRegions("ECAM")

                    Dim triggers = f.GetTriggers

                    'm.EPTH = f.GetRegions("EPTH")

                    'm.EMSD = f.GetRegions("EMSD")

                    m.EMNP = f.GetRegions("EMNP")(0)

                    'm.EMEF = f.GetRegions("EMEF")

                Case ".use"
                    MsgBox("Not yet implemented")
                Case ".veg"
                    MsgBox("Not yet implemented")
                Case ".wea"
                    MsgBox("Not yet implemented")
            End Select
        End If
    End Sub

    Private Sub DarkButton2_Click(sender As Object, e As EventArgs) Handles DarkButton2.Click
        Dim cd As New ColorDialog With {.Color = m.EMAP.col, .FullOpen = True}
        If cd.ShowDialog() = DialogResult.OK Then
            Button1.BackColor = cd.Color : Button1.FlatAppearance.MouseDownBackColor = cd.Color : Button1.FlatAppearance.MouseOverBackColor = cd.Color
            m.EMAP.col = cd.Color
        End If
    End Sub

    Private Sub DarkButton3_Click(sender As Object, e As EventArgs) Handles DarkButton3.Click
        m.EMAP.s1 = DarkTextBox1.Text
        m.EMAP.s2 = DarkTextBox2.Text
        m.EMAP.s3 = DarkTextBox3.Text
        m.EMAP.il = DarkCheckBox1.Checked
        Dim t As New List(Of Byte)
        t.AddRange(m.EMAP.ToEMAPb)
        'For Each b In m.EME2.ToEME2b
        't.AddRange(b)
        'Next
        '    t.AddRange(m.EMEP.ToEMEPb)
        '    t.AddRange(m.ECAM.ToECAMb)
        '    t.AddRange(m.EMNP.ToEMNPb)
        '    t.AddRange(m.EMEF.ToEMEFb)
        IO.File.WriteAllBytes("out.map", t.ToArray)
    End Sub
End Class
#Region "Filetype Classes"
' Classes containing the headers used by that file type, in the order they should be put back into a new file.
Public Class Map
    Property EMAP As EMAPc
    Property EME2 As EME2c()
    Property EMEP As EMEPc
    Property ECAM As ECAMc
    Property Triggers As Trigger()
    Property EPTH As EPTHc
    Property EMSD As EMSDc
    ' EMNP never changes, doesn't need unique class.
    Property EMNP As Byte()
    Property EMEF As EMEFc
End Class
#End Region
#Region "Header Classes"
' Classes to hold the data in easily manipulatable format
Public Class Trigger
    ' Triggers are made of 3 different headers (separate, unlike EME2 and EEOV), so there is a class to hold both types so they aren't separated.
    Property EMTR As EMTRc
    Property ExTR As ExTRc
End Class
Public Class EMAPc
    Property s1 As String
    Property s2 As String
    Property s3 As String
    Property col As Color
    Property il As Boolean
    Property le As Integer
End Class
Public Class EME2c
    Property inv As String()
End Class
Public Class EMEPc

End Class
Public Class ECAMc

End Class
Public Class EMEFc

End Class
Public Class EMSDc

End Class
Public Class EPTHc

End Class
Public Class EMTRc
    ' first Int32 after chunk size, unknown usage
    Property n1 As Integer
    ' second Int32 after chunk size, # of coordinate groups
    Property n2 As Integer
    Property r As List(Of Point3)
End Class
' Called ExTR instead of E(T/S/B)TR for easier handling within triggers
Public Class ExTRc
    Property type As String ' T, S, or B
    Property s As String
End Class
#End Region
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
Friend Module Functions
#Region "Byte array to Class"
    ' Functions to convert from F3-readable byte arrays extracted from files, into easily-manipulatable custom classes
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMAPc(b As Byte()) As EMAPc
        Dim s1o = 16 + 2 : Dim s1l = b(s1o - 2)
        Dim s2o = s1o + s1l + 2 : Dim s2l = b(s2o - 2)
        Dim s3o = s2o + s2l + 2 : Dim s3l = b(s3o - 2)
        Return New EMAPc With {
            .s1 = Encoding.ASCII.GetString(b.Skip(s1o).Take(s1l).ToArray()),
            .s2 = Encoding.ASCII.GetString(b.Skip(s2o).Take(s2l).ToArray()),
            .s3 = Encoding.ASCII.GetString(b.Skip(s3o).Take(s3l).ToArray()),
            .col = Color.FromArgb(b(s3o + s3l + 2), b(s3o + s3l + 3), b(s3o + s3l + 4)),
            .il = b(4) = 0,
            .le = b(s3o + s3l)
        }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMTRc(b As Byte()) As EMTRc
        Dim l As New List(Of Point3)
        For i = 20 To b.Length - 1 Step 12
            l.Add(New Point3(BitConverter.ToSingle(b, i), BitConverter.ToSingle(b, i + 4), BitConverter.ToSingle(b, i + 8)))
        Next
        Return New EMTRc With {
            .n1 = b(12),
            .n2 = b(16),
            .r = l
        }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToExTRc(b As Byte()) As ExTRc
        If Not Encoding.ASCII.GetString(New Byte() {b(1)}) = "B" Then MsgBox(Encoding.ASCII.GetString(b.Skip(14).Take(b(8)).ToArray()))
        Return New ExTRc With {
            .type = Encoding.ASCII.GetString(b.Skip(1).Take(1).ToArray()),
            .s = Encoding.ASCII.GetString(b.Skip(14).Take(b(8)).ToArray())
        }
    End Function
#End Region
#Region "Class to byte array"
    ' Functions that read from internal classes and rebuild chunks that F3 can read
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMAPb(c As EMAPc) As Byte()
        Dim s = 49 + c.s1.Length + c.s2.Length + c.s3.Length
        Dim out = New Byte(s - 1) {}
        out.OverwriteBytes(0, Encoding.ASCII.GetBytes("EMAP"))
        out.OverwriteBytes(4, New Byte() {If(c.il, 0, 5)})
        out.OverwriteBytes(8, New Byte() {s})
        out.OverwriteBytes(16, New Byte() {c.s1.Length})
        out.OverwriteBytes(18, Encoding.ASCII.GetBytes(c.s1))
        out.OverwriteBytes(18 + c.s1.Length, New Byte() {c.s2.Length})
        out.OverwriteBytes(20 + c.s1.Length, Encoding.ASCII.GetBytes(c.s2))
        out.OverwriteBytes(20 + c.s1.Length + c.s2.Length, New Byte() {c.s3.Length})
        out.OverwriteBytes(22 + c.s1.Length + c.s2.Length, Encoding.ASCII.GetBytes(c.s3))
        out.OverwriteBytes(22 + c.s1.Length + c.s2.Length + c.s3.Length, New Byte() {c.le})
        out.OverwriteBytes(24 + c.s1.Length + c.s2.Length + c.s3.Length, New Byte() {c.col.R})
        out.OverwriteBytes(25 + c.s1.Length + c.s2.Length + c.s3.Length, New Byte() {c.col.G})
        out.OverwriteBytes(26 + c.s1.Length + c.s2.Length + c.s3.Length, New Byte() {c.col.B})
        IO.File.WriteAllBytes("out.bin", out)
        Return out
    End Function
#End Region
#Region "Byte array search"
    ' Code for finding location of given byte array within another
    Private ReadOnly Empty(-1) As Integer
    <System.Runtime.CompilerServices.Extension>
    Public Function Locate(ByVal self() As Byte, ByVal candidate() As Byte) As Integer()
        If IsEmptyLocate(self, candidate) Then
            Return Empty
        End If
        Dim list As New List(Of Integer)()
        Dim i As Integer = 0
        Do While i < self.Length
            If Not IsMatch(self, i, candidate) Then
                i += 1
                Continue Do
            End If
            list.Add(i)
            i += 1
        Loop
        Return If(list.Count = 0, Empty, list.ToArray())
    End Function
    Private Function IsMatch(ByVal array() As Byte, ByVal position As Integer, ByVal candidate() As Byte) As Boolean
        If candidate.Length > (array.Length - position) Then
            Return False
        End If
        For i As Integer = 0 To candidate.Length - 1
            If array(position + i) <> candidate(i) Then
                Return False
            End If
        Next i
        Return True
    End Function
    Private Function IsEmptyLocate(ByVal array() As Byte, ByVal candidate() As Byte) As Boolean
        Return array Is Nothing OrElse candidate Is Nothing OrElse array.Length = 0 OrElse candidate.Length = 0 OrElse candidate.Length > array.Length
    End Function
#End Region
    ' Finds all locations of a given header, reads size, copies that section into byte array, puts array in list.
    <System.Runtime.CompilerServices.Extension>
    Public Function GetRegions(f As String, hs As String) As List(Of Byte())
        Dim hl As New List(Of Byte())
        Dim file = IO.File.ReadAllBytes(f)
        Dim hn = Encoding.ASCII.GetBytes(hs)
        Dim hc = file.Locate(hn)
        For Each l In hc
            Dim tb = file.Skip(l + 8).Take(4).ToArray()
            Dim tl = BitConverter.ToInt32(tb, 0)
            Dim h1 = file.Skip(l).Take(tl).ToArray()
            hl.Add(h1)
        Next
        Return hl
    End Function
    ' Finds all triggers for .map files, and the subsequest trigger info chunk
    <System.Runtime.CompilerServices.Extension>
    Public Function GetTriggers(f As String) As List(Of Trigger)
        Dim hl As New List(Of Trigger)
        Dim file = IO.File.ReadAllBytes(f)
        Dim hc = file.Locate(Encoding.ASCII.GetBytes("EMTR"))
        For Each l In hc
            Dim tb = file.Skip(l + 8).Take(4).ToArray()
            Dim tl = BitConverter.ToInt32(tb, 0)
            Dim h1 = file.Skip(l).Take(tl).ToArray()
            Dim h2 = file.Skip(l + tl).Take(file(l + tl + 8)).ToArray
            hl.Add(New Trigger With {.EMTR = h1.ToEMTRc, .ExTR = h2.ToExTRc})
        Next
        Return hl
    End Function
    ' Writes from "newBytes" into "b", starting at the given index
    <System.Runtime.CompilerServices.Extension>
    Public Sub OverwriteBytes(ByRef b As Byte(), startIndex As Integer, newBytes As Byte())
        For i = startIndex To startIndex + newBytes.Length - 1
            b(i) = newBytes(i - startIndex)
        Next
    End Sub
End Module

