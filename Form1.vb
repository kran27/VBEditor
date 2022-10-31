Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports AltUI.Controls

Public Class Form1
    Private f As String
    Private ext As String
    Private m As New Map
    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
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
                    'm.EME2 = f.GetRegions("EME2")
                    'm.EMEP = f.GetRegions("EMEP")
                    'm.ECAM = f.GetRegions("ECAM")
                    'm.EMNP = f.GetRegions("EMNP")
                    'm.EMEF = f.GetRegions("EMEF")
                    Button1.BackColor = m.EMAP.col : Button1.FlatAppearance.MouseOverBackColor = m.EMAP.col : Button1.FlatAppearance.MouseDownBackColor = m.EMAP.col
                    DarkTextBox1.Text = m.EMAP.s1
                    DarkTextBox2.Text = m.EMAP.s2
                    DarkTextBox3.Text = m.EMAP.s3
                    DarkCheckBox1.Checked = m.EMAP.il
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
Public Class Map
    Property EMAP As EMAPc
    Property EME2 As EME2c()
    Property EMEP As EMEPc
    Property ECAM As ECAMc
    Property Triggers As Trigger()
    Property EPTH As EPTHc
    Property EMSD As EMSDc
    Property EMNP As EMNPc
    Property EMEF As EMEFc
End Class
Public Class Trigger
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
Public Class EMNPc

    End Class
Public Class EMEFc

End Class
Public Class EMSDc

End Class
Public Class EPTHc

End Class
Public Class EMTRc
    Property r As PointF()
End Class
'use ExTR instead of ESTR/ETTR as layout is identical
Public Class ExTRc
    Property type As String

End Class
Friend Module Functions
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
    <System.Runtime.CompilerServices.Extension>
    Public Sub OverwriteBytes(ByRef b As Byte(), startIndex As Integer, newBytes As Byte())
        For i = startIndex To startIndex + newBytes.Length - 1
            b(i) = newBytes(i - startIndex)
        Next
    End Sub
End Module

