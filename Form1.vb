Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Text
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
                    m = New Map

                    m.EMAP = f.GetRegions("EMAP")(0).ToEMAPc

                    Button1.BackColor = m.EMAP.col : Button1.FlatAppearance.MouseOverBackColor = m.EMAP.col : Button1.FlatAppearance.MouseDownBackColor = m.EMAP.col
                    DarkTextBox1.Text = m.EMAP.s1
                    DarkTextBox2.Text = m.EMAP.s2
                    DarkTextBox3.Text = m.EMAP.s3
                    DarkCheckBox1.Checked = m.EMAP.il

                    m.EME2 = (From x In f.GetRegions("EME2") Select x.ToEME2c).ToArray

                    m.EMEP = (From x In f.GetRegions("EMEP") Select x.ToEMEPc).ToArray

                    m.ECAM = f.GetRegions("ECAM")(0).ToECAMc

                    m.Triggers = f.GetTriggers

                    m.EPTH = (From x In f.GetRegions("EPTH") Select x.ToEPTHc).ToArray

                    m.EMSD = (From x In f.GetRegions("EMSD") Select x.ToEMSDc).ToArray()

                    m.EMNP = f.GetRegions("EMNP")(0)

                    m.EMEF = (From x In f.GetRegions("EMEF") Select x.ToEMEFc).ToArray()

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

        'For Each EME2 In m.EME2
        '    t.AddRange(EME2.ToEME2b)
        'Next

        For Each EMEP In m.EMEP
            t.AddRange(EMEP.ToEMEPb)
        Next

        t.AddRange(m.ECAM.ToECAMb)

        If m.Triggers IsNot Nothing Then
            For Each tr In m.Triggers
                t.AddRange(tr.EMTR.ToEMTRb)
                t.AddRange(tr.ExTR.ToExTRb)
            Next
        End If

        If m.EPTH IsNot Nothing Then
            For Each EPTH In m.EPTH
                t.AddRange(EPTH.ToEPTHb)
            Next
        End If

        Dim tEMSD = f.GetRegions("EMSD")
        MsgBox(tEMSD.Count)
        For Each EMSD In tEMSD
            t.AddRange(EMSD.ToEMSDc.ToEMSDb())
        Next

        t.AddRange(m.EMNP)

        Dim tEMEF = f.GetRegions("EMEF")
        MsgBox(tEMEF.Count)
        For Each EMEF In tEMEF
            t.AddRange(EMEF.ToEMEFc.ToEMEFb())
        Next

        IO.File.WriteAllBytes("C:\Games\F3\Override\test.map", t.ToArray)
    End Sub
End Class
#Region "Filetype Classes"
' Classes containing the headers used by that file type, in the order they should be put back into a new file.
Public Class Map
    Property EMAP As EMAPc
    Property EME2 As EME2c()
    Property EMEP As EMEPc()
    Property ECAM As ECAMc
    Property Triggers As Trigger()
    Property EPTH As EPTHc()
    Property EMSD As EMSDc()
    Property EMNP As Byte() ' EMNP never changes, doesn't need unique class.
    Property EMEF As EMEFc()
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
    Property name As String
    Property l As Point4
    Property EEOV As EEOVc
End Class
Public Class EEOVc
    Property s1 As String
    Property s2 As String
    Property s3 As String
    Property s4 As String
    Property s5 As String
    Property inv As String()
End Class
Public Class EMEPc
    Property index As Integer
    Property p As Point4
End Class
Public Class ECAMc
    Property p As Point4
End Class
Public Class EMEFc
    Property s1 As String
    Property s2 As String
    Property l As Point4
    Property b1 As Integer
    Property b2 As Integer
End Class
Public Class EMSDc
    Property s1 As String
    Property l As Point3
    Property s2 As String
End Class
Public Class EPTHc
    Property name As String
    Property p As List(Of Point6)
End Class
Public Class EMTRc
    Property n As Integer
    Property r As List(Of Point3)
End Class

Public Class ExTRc ' Called ExTR instead of E(T/S/B)TR for easier handling within triggers
    Property type As String ' So we know which file is being created, T, S, or B. (or M, but it's ignored if that happens)
    Property s As String ' used for types T and S
    Property index As Integer ' used for type B
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
Public Class Point6
    Property x As Single
    Property z As Single
    Property y As Single
    Property r As Single
    Property u1 As Single
    Property u2 As Single
    Sub New(x As Single, z As Single, y As Single, r As Single, u1 As Single, u2 As Single)
        Me.x = x
        Me.z = z
        Me.y = y
        Me.r = r
        Me.u1 = u1
        Me.u2 = u2
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
            .n = b(12),
            .r = l
        }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToExTRc(b As Byte()) As ExTRc
        Return New ExTRc With {
            .type = Encoding.ASCII.GetString(b.Skip(1).Take(1).ToArray()),
            .s = Encoding.ASCII.GetString(b.Skip(14).Take(b(12)).ToArray()),
            .index = b(12)
        }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToECAMc(b As Byte()) As ECAMc
        Return New ECAMc With {
            .p = New Point4(BitConverter.ToSingle(b, 12), BitConverter.ToSingle(b, 16), BitConverter.ToSingle(b, 20), BitConverter.ToSingle(b, 24))
        }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMEPc(b As Byte()) As EMEPc
        Return New EMEPc With {
            .index = b(12),
            .p = New Point4(BitConverter.ToSingle(b, 73), BitConverter.ToSingle(b, 77), BitConverter.ToSingle(b, 81), BitConverter.ToSingle(b, 105))
        }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMEFc(b As Byte()) As EMEFc
        Return New EMEFc With {
            .s1 = Encoding.ASCII.GetString(b.Skip(14).Take(b(12)).ToArray()),
            .l = New Point4(BitConverter.ToSingle(b, 14 + b(12)), BitConverter.ToSingle(b, 18 + b(12)), BitConverter.ToSingle(b, 22 + b(12)), BitConverter.ToSingle(b, 26 + b(12))),
            .s2 = Encoding.ASCII.GetString(b.Skip(41 + b(12)).Take(b(39 + b(12))).ToArray()),
            .b1 = b(38 + b(12)),
            .b2 = b.Last
            }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMSDc(b As Byte()) As EMSDc
        Return New EMSDc With {
            .s1 = Encoding.ASCII.GetString(b.Skip(14).Take(b(12)).ToArray()),
                   .s2 = Encoding.ASCII.GetString(b.Skip(28 + b(12)).Take(b(26 + b(12))).ToArray()),
            .l = New Point3(BitConverter.ToSingle(b, 14 + b(12)), BitConverter.ToSingle(b, 18 + b(12)), BitConverter.ToSingle(b, 22 + b(12)))
        }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEPTHc(b As Byte()) As EPTHc
        Dim l As New List(Of Point6)
        For i = 18 + b(12) To b.Length - 1 Step 24
            l.Add(New Point6(BitConverter.ToSingle(b, i), BitConverter.ToSingle(b, i + 4), BitConverter.ToSingle(b, i + 8), BitConverter.ToSingle(b, i + 12), BitConverter.ToSingle(b, i + 16), BitConverter.ToSingle(b, i + 20)))
        Next
        Return New EPTHc With {
            .name = Encoding.ASCII.GetString(b.Skip(14).Take(b(12)).ToArray()),
            .p = l
        }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEME2c(b As Byte()) As EME2c
        Dim cl = b.Locate(Encoding.ASCII.GetBytes("EEOV"))(0)
        Return New EME2c With {
            .name = Encoding.ASCII.GetString(b.Skip(14).Take(b(12)).ToArray()),
            .l = New Point4(BitConverter.ToSingle(b, 14 + b(12)), BitConverter.ToSingle(b, 18 + b(12)), BitConverter.ToSingle(b, 22 + b(12)), BitConverter.ToSingle(b, 26 + b(12))),
            .EEOV = b.Skip(cl).Take(b(cl + 8)).ToArray().ToEEOVc
        }
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEEOVc(b As Byte()) As EEOVc
        Dim s1o = 12 + 2 : Dim s1l = b(s1o - 2)
        Dim s2o = s1o + s1l + 13 : Dim s2l = b(s2o - 2)
        Dim s3o = s2o + s2l + 2 : Dim s3l = b(s3o - 2)
        Dim s4o = s3o + s3l + 11 : Dim s4l = b(s4o - 2)
        Dim s5o = s4o + s4l + 3

        Dim ps4 = b(s4o + s4l)

        If ps4 = 2 Then
            s5o += 2
        End If

        Dim s5l = b(s5o - 2)

        Dim inv = New List(Of String)
        Dim io = s5o + s5l + 6
        Dim ao = 0
        For i = 0 To b(io - 6) - 1
            io += ao
            Dim itemN = Encoding.ASCII.GetString(b.Skip(io).Take(b(io - 2)).ToArray())
            If itemN.Length > 0 Then inv.Add(itemN)
            ao = b(io - 2) + 2
        Next
        Return New EEOVc With {
            .s1 = Encoding.ASCII.GetString(b.Skip(s1o).Take(s1l).ToArray()),
            .s2 = Encoding.ASCII.GetString(b.Skip(s2o).Take(s2l).ToArray()),
            .s3 = Encoding.ASCII.GetString(b.Skip(s3o).Take(s3l).ToArray()),
            .s4 = Encoding.ASCII.GetString(b.Skip(s4o).Take(s4l).ToArray()),
            .s5 = If(ps4 > 0, Encoding.ASCII.GetString(b.Skip(s5o).Take(s5l).ToArray()), ""),
            .inv = inv.ToArray()
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
        out.OverwriteBytes(32 + c.s1.Length + c.s2.Length + c.s3.Length, New Byte() {1})
        Return out
    End Function
    ' convert EMEP to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMEPb(c As EMEPc) As Byte()
        Dim out = New Byte(108) {}
        out.OverwriteBytes(0, Encoding.ASCII.GetBytes("EMEP"))
        out.OverwriteBytes(8, New Byte() {109})
        out.OverwriteBytes(12, New Byte() {c.index})
        out.OverwriteBytes(73, BitConverter.GetBytes(c.p.x))
        out.OverwriteBytes(77, BitConverter.GetBytes(c.p.z))
        out.OverwriteBytes(81, BitConverter.GetBytes(c.p.y))
        out.OverwriteBytes(105, BitConverter.GetBytes(c.p.r))
        Return out
    End Function
    ' convert ECAM to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToECAMb(c As ECAMc) As Byte()
        Dim out = New Byte(27) {}
        out.OverwriteBytes(0, Encoding.ASCII.GetBytes("ECAM"))
        out.OverwriteBytes(8, New Byte() {28})
        out.OverwriteBytes(12, BitConverter.GetBytes(c.p.x))
        out.OverwriteBytes(16, BitConverter.GetBytes(c.p.y))
        out.OverwriteBytes(20, BitConverter.GetBytes(c.p.z))
        out.OverwriteBytes(24, BitConverter.GetBytes(c.p.r))
        Return out
    End Function
    ' convert EPTH to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEPTHb(c As EPTHc) As Byte()
        Dim out = New Byte(17 + (c.p.Count * 24) + c.name.Length) {}
        out.OverwriteBytes(0, Encoding.ASCII.GetBytes("EPTH"))
        out.OverwriteBytes(8, New Byte() {18 + (c.p.Count * 24) + c.name.Length})
        out.OverwriteBytes(12, New Byte() {c.name.Length})
        out.OverwriteBytes(14, Encoding.ASCII.GetBytes(c.name))
        out.OverwriteBytes(14 + c.name.Length, New Byte() {c.p.Count})
        Dim i = 0
        For Each p In c.p
            out.OverwriteBytes(18 + c.name.Length + i, BitConverter.GetBytes(p.x))
            out.OverwriteBytes(22 + c.name.Length + i, BitConverter.GetBytes(p.z))
            out.OverwriteBytes(26 + c.name.Length + i, BitConverter.GetBytes(p.y))
            out.OverwriteBytes(30 + c.name.Length + i, BitConverter.GetBytes(p.r))
            out.OverwriteBytes(34 + c.name.Length + i, BitConverter.GetBytes(p.u1))
            out.OverwriteBytes(38 + c.name.Length + i, BitConverter.GetBytes(p.u2))
            i += 24
        Next
        Return out
    End Function
    ' convert EMTR to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMTRb(c As EMTRc) As Byte()
        Dim out = New Byte(19 + (c.r.Count * 12)) {}
        out.OverwriteBytes(0, Encoding.ASCII.GetBytes("EMTR"))
        out.OverwriteBytes(8, BitConverter.GetBytes(20 + (c.r.Count * 12)))
        out.OverwriteBytes(12, New Byte() {c.n})
        out.OverwriteBytes(16, New Byte() {c.r.Count})
        Dim i = 0
        For Each r In c.r
            out.OverwriteBytes(20 + i, BitConverter.GetBytes(r.x))
            out.OverwriteBytes(24 + i, BitConverter.GetBytes(r.z))
            out.OverwriteBytes(28 + i, BitConverter.GetBytes(r.y))
            i += 12
        Next
        Return out
    End Function
    ' convert ExTR to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToExTRb(c As ExTRc) As Byte()
        Select Case c.type
            Case "B"
                Dim out = New Byte(18) {}
                out.OverwriteBytes(0, Encoding.ASCII.GetBytes("EBTR"))
                out.OverwriteBytes(8, New Byte() {19})
                out.OverwriteBytes(12, New Byte() {c.index})
                out.OverwriteBytes(16, Encoding.ASCII.GetBytes("FFF"))
                Return out
            Case "S"
                Dim out = New Byte(17 + c.s.Length) {}
                out.OverwriteBytes(0, Encoding.ASCII.GetBytes("ESTR"))
                out.OverwriteBytes(8, New Byte() {18 + c.s.Length})
                out.OverwriteBytes(12, New Byte() {c.s.Length})
                out.OverwriteBytes(14, Encoding.ASCII.GetBytes(c.s))
                Return out
            Case "T"
                Dim out = New Byte(15 + c.s.Length) {}
                out.OverwriteBytes(0, Encoding.ASCII.GetBytes("ETTR"))
                out.OverwriteBytes(8, New Byte() {16 + c.s.Length})
                out.OverwriteBytes(12, New Byte() {c.s.Length})
                out.OverwriteBytes(14, Encoding.ASCII.GetBytes(c.s))
                out.OverwriteBytes(14 + c.s.Length, New Byte() {1, 1})
                Return out
            Case Else ' in case of an EMTR following another EMTR, which is known to happen at least once
                Return Array.Empty(Of Byte)
        End Select
    End Function
    ' convert EMSD to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMSDb(c As EMSDc) As Byte()
        Dim out = New Byte(29 + c.s1.Length + c.s2.Length) {}
        out.OverwriteBytes(0, Encoding.ASCII.GetBytes("EMSD"))
        out.OverwriteBytes(8, New Byte() {30 + c.s1.Length + c.s2.Length})
        out.OverwriteBytes(12, New Byte() {c.s1.Length})
        out.OverwriteBytes(14, Encoding.ASCII.GetBytes(c.s1))
        out.OverwriteBytes(14 + c.s1.Length, BitConverter.GetBytes(c.l.x))
        out.OverwriteBytes(18 + c.s1.Length, BitConverter.GetBytes(c.l.z))
        out.OverwriteBytes(22 + c.s1.Length, BitConverter.GetBytes(c.l.y))
        out.OverwriteBytes(26 + c.s1.Length, New Byte() {c.s2.Length})
        out.OverwriteBytes(28 + c.s1.Length, Encoding.ASCII.GetBytes(c.s2))
        out.OverwriteBytes(28 + c.s1.Length + c.s2.Length, New Byte() {1, 1})
        Return out
    End Function
    ' convert EMEF to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEMEFb(c As EMEFc) As Byte()
        Dim out = New Byte(41 + c.s1.Length + c.s2.Length) {}
        out.OverwriteBytes(0, Encoding.ASCII.GetBytes("EMEF"))
        out.OverwriteBytes(8, New Byte() {42 + c.s1.Length + c.s2.Length})
        out.OverwriteBytes(12, New Byte() {c.s1.Length})
        out.OverwriteBytes(14, Encoding.ASCII.GetBytes(c.s1))
        out.OverwriteBytes(14 + c.s1.Length, BitConverter.GetBytes(c.l.x))
        out.OverwriteBytes(18 + c.s1.Length, BitConverter.GetBytes(c.l.z))
        out.OverwriteBytes(22 + c.s1.Length, BitConverter.GetBytes(c.l.y))
        out.OverwriteBytes(26 + c.s1.Length, BitConverter.GetBytes(c.l.r))
        out.OverwriteBytes(38 + c.s1.Length, New Byte() {c.b1})
        out.OverwriteBytes(39 + c.s1.Length, New Byte() {c.s2.Length})
        out.OverwriteBytes(41 + c.s1.Length, Encoding.ASCII.GetBytes(c.s2))
        out.OverwriteBytes(41 + c.s1.Length + c.s2.Length, New Byte() {c.b2})
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
    Public Function GetTriggers(f As String) As Trigger()
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
        Return hl.ToArray
    End Function
    ' Writes from "newBytes" into "b", starting at the given index
    <System.Runtime.CompilerServices.Extension>
    Public Sub OverwriteBytes(ByRef b As Byte(), startIndex As Integer, newBytes As Byte())
        For i = startIndex To startIndex + newBytes.Length - 1
            b(i) = newBytes(i - startIndex)
        Next
    End Sub
End Module

