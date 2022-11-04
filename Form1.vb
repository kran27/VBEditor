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
                    m.EME2 = (From x In f.GetRegions("EME2") Select x.ToEME2c).ToArray
                    m.EMEP = (From x In f.GetRegions("EMEP") Select x.ToEMEPc).ToArray
                    m.ECAM = f.GetRegions("ECAM")(0).ToECAMc
                    m.Triggers = f.GetTriggers
                    m.EPTH = (From x In f.GetRegions("EPTH") Select x.ToEPTHc).ToArray
                    m.EMSD = (From x In f.GetRegions("EMSD") Select x.ToEMSDc).ToArray()
                    m.EMNP = f.GetRegions("EMNP")(0)
                    m.EMEF = (From x In f.GetRegions("EMEF") Select x.ToEMEFc).ToArray()

                    EMAPToUI()
                    EME2cb.Items.Clear()
                    For Each EME2 In m.EME2
                        EME2cb.Items.Add(EME2.name)
                    Next
                    EME2cb.SelectedIndex = 0
                    EME2ToUI()
                    ECAMToUI()
                    EMEPcb.Items.Clear()
                    For i = 1 To m.EMEP.Length
                        EMEPcb.Items.Add(i)
                    Next
                    EMEPcb.SelectedIndex = 0
                    EMEPToUI()
                Case ".use"
                    MsgBox("Not yet implemented")
                Case ".veg"
                    MsgBox("Not yet implemented")
                Case ".wea"
                    MsgBox("Not yet implemented")
            End Select
        End If
    End Sub
#Region "Load classes into UI"
    Private Sub EMAPToUI()
        EMAPcolp.BackColor = m.EMAP.col : EMAPcolp.FlatAppearance.MouseOverBackColor = m.EMAP.col : EMAPcolp.FlatAppearance.MouseDownBackColor = m.EMAP.col
        EMAPs1.Text = m.EMAP.s1.Replace(".8", "")
        EMAPs2.Text = m.EMAP.s2.Replace(".rle", "")
        EMAPs3.Text = m.EMAP.s3.Replace(".dds", "")
        EMAPilcb.Checked = m.EMAP.il
    End Sub
    Private Sub EME2ToUI() Handles EME2cb.SelectedIndexChanged
        EME2n.Text = m.EME2(EME2cb.SelectedIndex).name
        EME2s1.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s1
        EME2s2.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s2
        EME2s3.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s3.Replace(".amx", "")
        EME2s4.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s4.Replace(".dds", "")
        EME2s5.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s5.Replace(".veg", "")
        EME2x.Text = m.EME2(EME2cb.SelectedIndex).l.x
        EME2y.Text = m.EME2(EME2cb.SelectedIndex).l.y
        EME2z.Text = m.EME2(EME2cb.SelectedIndex).l.z
        EME2r.Text = m.EME2(EME2cb.SelectedIndex).l.r
        Dim dt As New DataTable
        dt.Columns.Add("item name", GetType(String))
        For Each item In m.EME2(EME2cb.SelectedIndex).EEOV.inv
            dt.Rows.Add(item)
        Next
        EME2dgv.DataSource = dt
        For Each col As DataGridViewColumn In EME2dgv.Columns
            col.MinimumWidth = EME2dgv.Width - 18
            col.Width = EME2dgv.Width - 18
        Next
    End Sub
    Private Sub EMEPToUI() Handles EMEPcb.SelectedIndexChanged
        EMEPnud.Value = m.EMEP(EMEPcb.SelectedIndex).index
        EMEPx.Text = m.EMEP(EMEPcb.SelectedIndex).p.x
        EMEPy.Text = m.EMEP(EMEPcb.SelectedIndex).p.y
        EMEPz.Text = m.EMEP(EMEPcb.SelectedIndex).p.z
        EMEPr.Text = m.EMEP(EMEPcb.SelectedIndex).p.r
    End Sub
    Private Sub ECAMToUI()
        ECAMx.Text = m.ECAM.p.x
        ECAMy.Text = m.ECAM.p.y
        ECAMz.Text = m.ECAM.p.z
        ECAMr.Text = m.ECAM.p.r
    End Sub
#End Region
    Private Sub DataGridView1_ScrollChanged() Handles EME2dgv.Scroll
        EME2dsb.ScrollTo((EME2dgv.FirstDisplayedScrollingRowIndex / (EME2dgv.Rows.Count - EME2dgv.DisplayedRowCount(False))) * EME2dsb.Maximum)
    End Sub
    Private Sub DarkScrollBar1_Click(sender As Object, e As EventArgs) Handles EME2dsb.MouseDown
        Timer1.Start()
    End Sub
    Private Sub DarkScrollBar1_MouseUp(sender As Object, e As EventArgs) Handles EME2dsb.MouseUp
        Timer1.Stop()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        EME2dgv.FirstDisplayedScrollingRowIndex = (EME2dsb.Value / (EME2dsb.Maximum)) * (EME2dgv.Rows.Count - EME2dgv.DisplayedRowCount(False))
    End Sub

    Private Sub DarkButton2_Click(sender As Object, e As EventArgs) Handles EMAPslb.Click
        Dim cd As New ColorDialog With {.Color = m.EMAP.col, .FullOpen = True}
        If cd.ShowDialog() = DialogResult.OK Then
            EMAPcolp.BackColor = cd.Color : EMAPcolp.FlatAppearance.MouseDownBackColor = cd.Color : EMAPcolp.FlatAppearance.MouseOverBackColor = cd.Color
            m.EMAP.col = cd.Color
        End If
    End Sub

    Private Sub DarkButton3_Click(sender As Object, e As EventArgs) Handles MapSave.Click
        Dim sfd As New SaveFileDialog With {.Filter = $"Van Buren Data File|*{ext}", .ValidateNames = True, .DefaultExt = ext}
        If sfd.ShowDialog = DialogResult.OK Then
            m.EMAP.s1 = EMAPs1.Text
            m.EMAP.s2 = EMAPs2.Text
            m.EMAP.s3 = EMAPs3.Text
            m.EMAP.il = EMAPilcb.Checked
            m.EMAP.col = EMAPcolp.BackColor

            Dim b As New List(Of Byte)
            b.AddRange(m.EMAP.ToEMAPb)
            b.AddRange(m.EME2.SelectMany(Function(x) x.ToEME2b()))
            b.AddRange(m.EMEP.SelectMany(Function(x) x.ToEMEPb()))
            b.AddRange(m.ECAM.ToECAMb())
            b.AddRange(m.Triggers.SelectMany(Function(x) x.ToTriggerB()))
            b.AddRange(m.EPTH.SelectMany(Function(x) x.ToEPTHb()))
            b.AddRange(m.EMSD.SelectMany(Function(x) x.ToEMSDb()))
            b.AddRange(m.EMNP)
            b.AddRange(m.EMEF.SelectMany(Function(x) x.ToEMEFb()))
            IO.File.WriteAllBytes(sfd.FileName, b.ToArray)
        End If
    End Sub

    Private Sub MyBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EME2dgv.GridColor = AltUI.Config.ThemeProvider.Theme.Colors.GreySelection
        EME2dgv.BackgroundColor = AltUI.Config.ThemeProvider.BackgroundColour
        EME2dgv.DefaultCellStyle = New DataGridViewCellStyle With {.BackColor = AltUI.Config.ThemeProvider.BackgroundColour, .ForeColor = AltUI.Config.ThemeProvider.Theme.Colors.LightText, .SelectionBackColor = AltUI.Config.ThemeProvider.Theme.Colors.BlueSelection, .SelectionForeColor = AltUI.Config.ThemeProvider.Theme.Colors.LightText}
    End Sub

    Private Sub EMEPgb_Enter(sender As Object, e As EventArgs) Handles EMEPgb.Enter

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
    Property b As Integer
    Property EEOV As EEOVc
End Class
Public Class EEOVc
    Property s1 As String
    Property s2 As String
    Property s3 As String
    Property s4 As String
    Property ps4 As Integer
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
            .b = b(cl - 1),
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
        If s5l = 1 Then s5l = 0

        Dim inv = New List(Of String)
        Dim io = s5o + s5l + 6
        Dim itemN = ""
        For i = io To b.Length - 1
            Try : itemN = Encoding.ASCII.GetString(b.Skip(io).Take(b(io - 2)).ToArray()) : Catch : Exit For : End Try
            If Not itemN.Length = 0 Then inv.Add(itemN)
            io += b(io - 2) + 2
        Next

        Return New EEOVc With {
            .s1 = Encoding.ASCII.GetString(b.Skip(s1o).Take(s1l).ToArray()),
            .s2 = Encoding.ASCII.GetString(b.Skip(s2o).Take(s2l).ToArray()),
            .s3 = Encoding.ASCII.GetString(b.Skip(s3o).Take(s3l).ToArray()),
            .s4 = Encoding.ASCII.GetString(b.Skip(s4o).Take(s4l).ToArray()),
            .s5 = If(ps4 > 0, Encoding.ASCII.GetString(b.Skip(s5o).Take(s5l).ToArray()), ""),
                   .ps4 = ps4,
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
    ' convert EME2 to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEME2b(c As EME2c) As Byte()
        Dim EEOV = c.EEOV.ToEEOVb
        Dim out = New Byte(38 + c.name.Length + EEOV.Length) {}
        out.OverwriteBytes(0, Encoding.ASCII.GetBytes("EME2"))
        out.OverwriteBytes(8, BitConverter.GetBytes(39 + c.name.Length + EEOV.Length))
        out.OverwriteBytes(12, New Byte() {c.name.Length})
        out.OverwriteBytes(14, Encoding.ASCII.GetBytes(c.name))
        out.OverwriteBytes(14 + c.name.Length, BitConverter.GetBytes(c.l.x))
        out.OverwriteBytes(18 + c.name.Length, BitConverter.GetBytes(c.l.z))
        out.OverwriteBytes(22 + c.name.Length, BitConverter.GetBytes(c.l.y))
        out.OverwriteBytes(26 + c.name.Length, BitConverter.GetBytes(c.l.r))
        out.OverwriteBytes(38 + c.name.Length, New Byte() {c.b})
        out.OverwriteBytes(39 + c.name.Length, EEOV)
        Return out
    End Function
    ' convert EEOV to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToEEOVb(c As EEOVc) As Byte()
        Dim invl = c.inv.Sum(Function(e) e.Length + 2)
        Dim a = If(c.ps4 = 2, 2, 0)
        Dim out = New Byte(46 + c.s1.Length + c.s2.Length + c.s3.Length + c.s4.Length + c.s5.Length + invl + a) {}
        out.OverwriteBytes(0, Encoding.ASCII.GetBytes("EEOV"))
        out.OverwriteBytes(8, New Byte() {47 + c.s1.Length + c.s2.Length + c.s3.Length + c.s4.Length + c.s5.Length + invl + a})
        out.OverwriteBytes(12, New Byte() {c.s1.Length})
        out.OverwriteBytes(14, Encoding.ASCII.GetBytes(c.s1))
        out.OverwriteBytes(25 + c.s1.Length, New Byte() {c.s2.Length})
        out.OverwriteBytes(27 + c.s1.Length, Encoding.ASCII.GetBytes(c.s2))
        out.OverwriteBytes(27 + c.s1.Length + c.s2.Length, New Byte() {c.s3.Length})
        out.OverwriteBytes(29 + c.s1.Length + c.s2.Length, Encoding.ASCII.GetBytes(c.s3))
        out.OverwriteBytes(36 + c.s1.Length + c.s2.Length + c.s3.Length, New Byte() {&H80, &H3F})
        out.OverwriteBytes(38 + c.s1.Length + c.s2.Length + c.s3.Length, New Byte() {c.s4.Length})
        out.OverwriteBytes(40 + c.s1.Length + c.s2.Length + c.s3.Length, Encoding.ASCII.GetBytes(c.s4))
        out.OverwriteBytes(40 + c.s1.Length + c.s2.Length + c.s3.Length + c.s4.Length, New Byte() {c.ps4})
        out.OverwriteBytes(41 + c.s1.Length + c.s2.Length + c.s3.Length + c.s4.Length + a, New Byte() {c.s5.Length})
        out.OverwriteBytes(43 + c.s1.Length + c.s2.Length + c.s3.Length + c.s4.Length + a, Encoding.ASCII.GetBytes(c.s5))
        Dim i = 0
        For Each inv In c.inv
            out.OverwriteBytes(47 + c.s1.Length + c.s2.Length + c.s3.Length + c.s4.Length + c.s5.Length + a + i, New Byte() {inv.Length})
            out.OverwriteBytes(49 + c.s1.Length + c.s2.Length + c.s3.Length + c.s4.Length + c.s5.Length + a + i, Encoding.ASCII.GetBytes(inv))
            i += inv.Length + 2
        Next
        Return out
    End Function
    ' convert Trigger to a byte array
    <System.Runtime.CompilerServices.Extension>
    Public Function ToTriggerB(c as Trigger) As Byte()
        Dim b As New List(Of Byte)
        b.AddRange(c.EMTR.ToEMTRb())
        b.AddRange(c.ExTR.ToExTRb())
        Return b.ToArray()
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
    ' Finds all triggers for .map files, and the subsequent trigger info chunk
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

