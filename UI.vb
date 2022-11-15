Imports System.IO
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports AltUI
Imports AltUI.Config
Imports AltUI.Controls
Imports AltUI.Docking

Public Class UI
    Private f As String
    Private ext As String
    Private m As New Map
    Private lEME2i As Integer = -1
    Private lEMEPi As Integer = -1
    Private lTriggeri As Integer = -1
    Private lTriggerpi As Integer = -1
    Private lEPTHi As Integer = -1
    Private lEPTHpi As Integer = -1
    Private lEMSDi As Integer = -1
    Private lEMEFi As Integer = -1

    Private Sub LoadFile() Handles DarkButton1.Click
        ' Loads all regions of a given file into their respective classes, and from there into the UI
        Dim ofd As New OpenFileDialog With {.Filter = "Van Buren Data File|*.AMO;*.ARM;*.CON;*.CRT;*.DOR;*.INT;*.ITM;*.MAP;*.USE;*.VEG;*.WEA", .Multiselect = False, .ValidateNames = True}
        If ofd.ShowDialog = DialogResult.OK Then
            f = ofd.FileName
            ext = f.Substring(f.LastIndexOf("."), 4).ToLower()
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
#Region ".map"
                Case ".map"
                    SetMaplin1()

                    m = New Map
                    m.EMAP = f.GetRegions("EMAP")(0).ToEMAPc
                    m.EME2 = (From x In f.GetRegions("EME2") Select x.ToEME2c).ToList
                    m.EMEP = (From x In f.GetRegions("EMEP") Select x.ToEMEPc).ToList
                    m.ECAM = f.GetRegions("ECAM")(0).ToECAMc
                    m.Triggers = f.GetTriggers
                    m.EPTH = (From x In f.GetRegions("EPTH") Select x.ToEPTHc).ToList
                    m.EMSD = (From x In f.GetRegions("EMSD") Select x.ToEMSDc).ToList
                    m.EMNP = f.GetRegions("EMNP")(0)
                    m.EMEF = (From x In f.GetRegions("EMEF") Select x.ToEMEFc).ToList

                    MapSetupUI()
#End Region
                Case ".use"
                    MsgBox("Not yet implemented")
                Case ".veg"
                    MsgBox("Not yet implemented")
                Case ".wea"
                    MsgBox("Not yet implemented")
            End Select
        End If
    End Sub
    Private Sub ResetUI()
        For Each c As DarkGroupBox In From con In Controls Where TypeOf con Is DarkGroupBox
            For Each c2 As DarkGroupBox In From con In c.Controls Where TypeOf con Is DarkGroupBox
                For Each c3 In c2.Controls
                    If TypeOf c3 Is DarkTextBox Then
                        c3.Text = ""
                    ElseIf TypeOf c3 Is DarkNumericUpDown Then
                        c3.Value = 0
                    ElseIf TypeOf c3 Is DarkComboBox AndAlso Not c3.name = "Triggertcb" Then
                        c3.Items.Clear
                        c3.Refresh() ' Refresh control so the text region is not transparent
                    ElseIf TypeOf c3 Is DataGridView Then
                        c3.DataSource = Nothing
                    End If
                Next
            Next
        Next
    End Sub
    Private Sub MapSetupUI()
        Mapgb.Show()
        ResetUI()
        SetMaplin1()
        EMAPToUI()
        For Each EME2 In m.EME2
            EME2cb.Items.Add(EME2.name)
        Next
        If m.EME2.Any() Then
            EME2cb.SelectedIndex = 0
            lEME2i = -1
            EME2ToUI()
            For Each c As Control In EME2gb.Controls
                c.Enabled = True
            Next
        Else
            For Each c As Control In EME2gb.Controls
                c.Enabled = False
            Next
            EME2cb.Enabled = True : EME2p.Enabled = True
        End If
        If m.ECAM IsNot Nothing Then ECAMToUI()
        If m.EMEP.Any() Then
            For i = 1 To m.EMEP.Count
                EMEPcb.Items.Add(i)
            Next
            EMEPcb.SelectedIndex = 0
            lEMEPi = -1
            EMEPToUI()
            For Each c As Control In EMEPgb.Controls
                c.Enabled = True
            Next
        Else
            For Each c As Control In EMEPgb.Controls
                c.Enabled = False
            Next
            EMEPcb.Enabled = True : EMEPp.Enabled = True
        End If
        If m.Triggers.Any() Then
            Dim a = ""
            For i = 1 To m.Triggers.Count
                If m.Triggers(i - 1).ExTR.s = "S" Or m.Triggers(i - 1).ExTR.s = "T" Then a = $" ({m.Triggers(i - 1).ExTR.s})"
                Triggercb.Items.Add($"{i}{a}")
                a = ""
            Next
            Triggercb.SelectedIndex = 0
            lTriggeri = -1 : lTriggerpi = -1
            TriggerToUI()
            For Each c As Control In Triggergb.Controls
                c.Enabled = True
            Next
        Else
            For Each c As Control In Triggergb.Controls
                c.Enabled = False
            Next
            Triggercb.Enabled = True : Triggerp.Enabled = True
        End If
        If m.EPTH.Any() Then
            For i = 1 To m.EPTH.Count
                EPTHcb.Items.Add($"{i} ({m.EPTH(i - 1).name})")
            Next
            EPTHcb.SelectedIndex = 0
            lEPTHi = -1 : lEPTHpi = -1
            EPTHToUI()
            For Each c As Control In EPTHGB.Controls
                c.Enabled = True
            Next
        Else
            For Each c As Control In EPTHGB.Controls
                c.Enabled = False
            Next
            EPTHcb.Enabled = True : EPTHp.Enabled = True
        End If
        If m.EMSD.Any() Then
            For i = 1 To m.EMSD.Count
                EMSDcb.Items.Add($"{i} ({m.EMSD(i - 1).s2.Replace(".psf", "")})")
            Next
            EMSDcb.SelectedIndex = 0
            lEMSDi = -1
            EMSDToUI()
            For Each c As Control In EMSDgb.Controls
                c.Enabled = True
            Next
        Else
            For Each c As Control In EMSDgb.Controls
                c.Enabled = False
            Next
            EMSDcb.Enabled = True : EMSDp.Enabled = True
        End If
        If m.EMEF.Any() Then
            For i = 1 To m.EMEF.Count
                EMEFcb.Items.Add($"{i} ({m.EMEF(i - 1).s2.Replace(".veg", "")})")
            Next
            EMEFcb.SelectedIndex = 0
            lEMEFi = -1
            EMEFToUI()
            For Each c As Control In EMEFgb.Controls
                c.Enabled = True
            Next
        Else
            For Each c As Control In EMEFgb.Controls
                c.Enabled = False
            Next
            EMEFcb.Enabled = True : EMEFp.Enabled = True
        End If
    End Sub
#Region "Load classes into ui"
    Private Sub EMAPToUI()
        EMAPslb.BorderColour = m.EMAP.col
        EMAPs1.Text = m.EMAP.s1.Replace(".8", "")
        EMAPs2.Text = m.EMAP.s2.Replace(".rle", "")
        EMAPs3.Text = m.EMAP.s3.Replace(".dds", "")
        EMAPilcb.Checked = m.EMAP.il
    End Sub
    Private Sub EME2ToUI() Handles EME2cb.SelectedIndexChanged
        If lEME2i <> -1 AndAlso lEME2i <= EME2cb.Items.Count - 1 Then UIToEME2(lEME2i)
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
        lEME2i = EME2cb.SelectedIndex
    End Sub
    Private Sub EMEPToUI() Handles EMEPcb.SelectedIndexChanged
        If lEMEPi <> -1 AndAlso lEMEPi <= EMEPcb.Items.Count - 1 Then UIToEMEP(lEMEPi)
        EMEPnud.Value = m.EMEP(EMEPcb.SelectedIndex).index
        EMEPx.Text = m.EMEP(EMEPcb.SelectedIndex).p.x
        EMEPy.Text = m.EMEP(EMEPcb.SelectedIndex).p.y
        EMEPz.Text = m.EMEP(EMEPcb.SelectedIndex).p.z
        EMEPr.Text = m.EMEP(EMEPcb.SelectedIndex).p.r
        lEMEPi = EMEPcb.SelectedIndex
    End Sub
    Private Sub ECAMToUI()
        ECAMx.Text = m.ECAM.p.x
        ECAMy.Text = m.ECAM.p.y
        ECAMz.Text = m.ECAM.p.z
        ECAMr.Text = m.ECAM.p.r
    End Sub
    Private Sub TriggerToUI() Handles Triggercb.SelectedIndexChanged
        If lTriggeri <> -1 AndAlso lEPTHi <= Triggercb.Items.Count - 1 Then
            UIToTrigger(lTriggeri, lTriggerpi)
        End If
        Triggerpcb.Items.Clear()
        For i = 1 To m.Triggers(Triggercb.SelectedIndex).EMTR.r.Count
            Triggerpcb.Items.Add(i)
        Next
        Triggerpcb.SelectedIndex = 0
        Triggertcb.SelectedItem = m.Triggers(Triggercb.SelectedIndex).ExTR.type
        Select Case m.Triggers(Triggercb.SelectedIndex).ExTR.type
            Case "S", "T"
                Triggern.Enabled = True
                Triggern.Text = m.Triggers(Triggercb.SelectedIndex).ExTR.s
            Case "B"
                Triggern.Enabled = True
                Triggern.Text = m.Triggers(Triggercb.SelectedIndex).ExTR.index
        End Select
        lTriggeri = Triggercb.SelectedIndex
    End Sub
    Private Sub Triggerpcb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Triggerpcb.SelectedIndexChanged
        Triggerx.Text = m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggerpcb.SelectedIndex).x
        Triggery.Text = m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggerpcb.SelectedIndex).y
        Triggerz.Text = m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggerpcb.SelectedIndex).z
        lTriggerpi = Triggerpcb.SelectedIndex
    End Sub
    Private Sub EPTHToUI() Handles EPTHcb.SelectedIndexChanged
        If lEPTHi <> -1 AndAlso lEPTHi <= EPTHcb.Items.Count - 1 Then
            UIToEPTH(lEPTHi, lEPTHpi)
        End If
        EPTHpcb.Items.Clear()
        For i = 1 To m.EPTH(EPTHcb.SelectedIndex).p.Count
            EPTHpcb.Items.Add(i)
        Next
        EPTHpcb.SelectedIndex = 0
        EPTHn.Text = m.EPTH(EPTHcb.SelectedIndex).name
        lEPTHi = EPTHcb.SelectedIndex
    End Sub

    Private Sub EPTHpcb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EPTHpcb.SelectedIndexChanged
        EPTHx.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHpcb.SelectedIndex).x
        EPTHy.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHpcb.SelectedIndex).y
        EPTHz.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHpcb.SelectedIndex).z
        EPTHr.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHpcb.SelectedIndex).r
        lEPTHpi = EPTHpcb.SelectedIndex
    End Sub
    Private Sub EMSDToUI() Handles EMSDcb.SelectedIndexChanged
        If lEMSDi <> -1 AndAlso lEMSDi <= EPTHcb.Items.Count - 1 Then UIToEMSD(lEMSDi)
        EMSDs1.Text = m.EMSD(EMSDcb.SelectedIndex).s1
        EMSDs2.Text = m.EMSD(EMSDcb.SelectedIndex).s2.Replace(".psf", "")
        EMSDx.Text = m.EMSD(EMSDcb.SelectedIndex).l.x
        EMSDy.Text = m.EMSD(EMSDcb.SelectedIndex).l.y
        EMSDz.Text = m.EMSD(EMSDcb.SelectedIndex).l.z
        lEMSDi = EMSDcb.SelectedIndex
    End Sub
    Private Sub EMEFToUI() Handles EMEFcb.SelectedIndexChanged
        If lEMEFi <> -1 AndAlso lEMEFi <= EPTHcb.Items.Count - 1 Then UIToEMEF(lEMEFi)
        EMEFs1.Text = m.EMEF(EMEFcb.SelectedIndex).s1
        EMEFs2.Text = m.EMEF(EMEFcb.SelectedIndex).s2.Replace(".veg", "")
        EMEFx.Text = m.EMEF(EMEFcb.SelectedIndex).l.x
        EMEFy.Text = m.EMEF(EMEFcb.SelectedIndex).l.y
        EMEFz.Text = m.EMEF(EMEFcb.SelectedIndex).l.z
        EMEFr.Text = m.EMEF(EMEFcb.SelectedIndex).l.r
        lEMEFi = EMEFcb.SelectedIndex
    End Sub
#End Region
#Region "Load UI into classes"
    Private Sub UIToEMAP()
        m.EMAP.col = EMAPslb.BorderColour
        m.EMAP.s1 = EMAPs1.Text & If(EMAPs1.Text.Length > 0, ".8", "")
        m.EMAP.s2 = EMAPs2.Text & If(EMAPs2.Text.Length > 0, ".rle", "")
        m.EMAP.s3 = EMAPs3.Text & If(EMAPs3.Text.Length > 0, ".dds", "")
        m.EMAP.il = EMAPilcb.Checked
    End Sub
    Private Sub UIToECAM()
        If m.ECAM Is Nothing Then m.ECAM = New ECAMc
        m.ECAM.p = New Point4(ECAMx.Text, ECAMz.Text, ECAMy.Text, ECAMr.Text)
    End Sub
    Private Sub UIToEMEF(i As Integer)
        m.EMEF(i).s1 = EMEFs1.Text
        m.EMEF(i).s2 = EMEFs2.Text & If(EMEFs2.Text.Length > 0, ".veg", "")
        m.EMEF(i).l = New Point4(EMEFx.Text, EMEFz.Text, EMEFy.Text, EMEFr.Text)
    End Sub
    Private Sub UIToEMSD(i As Integer)
        m.EMSD(i).s1 = EMSDs1.Text
        m.EMSD(i).s2 = EMSDs2.Text & If(EMSDs2.Text.Length > 0, ".psf", "")
        m.EMSD(i).l = New Point3(EMSDx.Text, EMSDz.Text, EMSDy.Text)
    End Sub
    Private Sub UIToEPTH(i As Integer, pi As Integer)
        m.EPTH(i).name = EPTHn.Text
        m.EPTH(i).p(pi).x = EPTHx.Text
        m.EPTH(i).p(pi).y = EPTHy.Text
        m.EPTH(i).p(pi).z = EPTHz.Text
        m.EPTH(i).p(pi).r = EPTHr.Text
    End Sub
    Private Sub UIToTrigger(i As Integer, pi As Integer)
        m.Triggers(i).ExTR.s = Triggern.Text
        m.Triggers(i).EMTR.r(pi) = New Point3(Triggerx.Text, Triggerz.Text, Triggery.Text)
    End Sub
    Private Sub UIToEMEP(i As Integer)
        m.EMEP(i).index = EMEPnud.Value
        m.EMEP(i).p = New Point4(EMEPx.Text, EMEPz.Text, EMEPy.Text, EMEPr.Text)
    End Sub
    Private Sub UIToEME2(i As Integer)
        m.EME2(i).name = EME2n.Text
        m.EME2(i).EEOV.s1 = EME2s1.Text
        m.EME2(i).EEOV.s2 = EME2s2.Text
        m.EME2(i).EEOV.s3 = EME2s3.Text & If(EME2s3.Text.Length > 0, ".amx", "")
        m.EME2(i).EEOV.s4 = EME2s4.Text & If(EME2s4.Text.Length > 0, ".dds", "")
        m.EME2(i).EEOV.s5 = EME2s5.Text & If(EME2s5.Text.Length > 0, ".veg", "")
        If EME2s5.Text.Length > 0 AndAlso Not m.EME2(EME2cb.SelectedIndex).EEOV.ps4 = 2 Then m.EME2(EME2cb.SelectedIndex).EEOV.ps4 = 1
        m.EME2(i).l = New Point4(EME2x.Text, EME2z.Text, EME2y.Text, EME2r.Text)
        Dim s = (From row As DataGridViewRow In EME2dgv.Rows Where TypeOf row.Cells.Item(0).Value Is String Select row.Cells.Item(0).Value).Cast(Of String)().ToList()
        m.EME2(i).EEOV.inv = s.ToArray()
    End Sub
#End Region
    Private Sub DataGridView1_ScrollChanged() Handles EME2dgv.Scroll
        EME2dsb.ScrollTo(EME2dgv.FirstDisplayedScrollingRowIndex / (EME2dgv.Rows.Count - EME2dgv.DisplayedRowCount(False)) * EME2dsb.Maximum)
    End Sub
    Private Sub DarkScrollBar1_Click(sender As Object, e As EventArgs) Handles EME2dsb.MouseDown
        Timer1.Start()
    End Sub
    Private Sub DarkScrollBar1_MouseUp(sender As Object, e As EventArgs) Handles EME2dsb.MouseUp
        Timer1.Stop()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        EME2dgv.FirstDisplayedScrollingRowIndex = EME2dsb.Value / EME2dsb.Maximum * (EME2dgv.Rows.Count - EME2dgv.DisplayedRowCount(False))
    End Sub

    Private Sub DarkButton2_Click(sender As Object, e As EventArgs) Handles EMAPslb.Click
        Dim cd As New ColorDialog With {.Color = m.EMAP.col, .FullOpen = True}
        If cd.ShowDialog() = DialogResult.OK Then
            EMAPslb.BorderColour = cd.Color
            m.EMAP.col = cd.Color
        End If
    End Sub

    Private Sub DarkButton3_Click(sender As Object, e As EventArgs) Handles MapSave.Click
        Dim sfd As New SaveFileDialog With {.Filter = $"Van Buren Data File|*{ext}", .ValidateNames = True, .DefaultExt = ext}
        If sfd.ShowDialog = DialogResult.OK Then
            UIToEMAP()
            Dim b As New List(Of Byte) : Dim ECAMb = True
            b.AddRange(m.EMAP.ToEMAPb)
            If m.EME2.Any() Then UIToEME2(EME2cb.SelectedIndex)
            b.AddRange(m.EME2.SelectMany(Function(x) x.ToEME2b()))
            If m.EMEP.Any() Then UIToEMEP(EMEPcb.SelectedIndex)
            b.AddRange(m.EMEP.SelectMany(Function(x) x.ToEMEPb()))
            Try : UIToECAM() : Catch : ECAMb = False : End Try
            If ECAMb Then b.AddRange(m.ECAM.ToECAMb())
            If m.Triggers.Any() Then UIToTrigger(Triggercb.SelectedIndex, Triggerpcb.SelectedIndex)
            b.AddRange(m.Triggers.SelectMany(Function(x) x.ToTriggerB()))
            If m.EPTH.Any() Then UIToEPTH(EPTHcb.SelectedIndex, EPTHpcb.SelectedIndex)
            b.AddRange(m.EPTH.SelectMany(Function(x) x.ToEPTHb()))
            If m.EMSD.Any() Then UIToEMSD(EMSDcb.SelectedIndex)
            b.AddRange(m.EMSD.SelectMany(Function(x) x.ToEMSDb()))
            b.AddRange(m.EMNP)
            If m.EMEF.Any() Then UIToEMEF(EMEFcb.SelectedIndex)
            b.AddRange(m.EMEF.SelectMany(Function(x) x.ToEMEFb()))
            File.WriteAllBytes(sfd.FileName, b.ToArray)
        End If
    End Sub

    Private Sub MyBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mapgb.Hide()
        EMAPslb.CustomColour = True
        EME2dgv.GridColor = ThemeProvider.Theme.Colors.GreySelection
        EME2dgv.BackgroundColor = ThemeProvider.BackgroundColour
        EME2dgv.DefaultCellStyle = New DataGridViewCellStyle With {.BackColor = ThemeProvider.BackgroundColour, .ForeColor = ThemeProvider.Theme.Colors.LightText, .SelectionBackColor = ThemeProvider.Theme.Colors.BlueSelection, .SelectionForeColor = ThemeProvider.Theme.Colors.LightText}
    End Sub

    Private Sub EMEPp_Click(sender As Object, e As EventArgs) Handles EMEPp.Click
        For Each c As Control In EMEPgb.Controls
            c.Enabled = True
        Next
        m.EMEP.Add(New EMEPc())
        EMEPcb.Items.Add(EMEPcb.Items.Count + 1)
        EMEPcb.SelectedIndex = EMEPcb.Items.Count - 1
    End Sub

    Private Sub EMEPm_Click(sender As Object, e As EventArgs) Handles EMEPm.Click
        Dim i = EMEPcb.SelectedIndex
        If m.EMEP.Count = 1 Then
            m.EMEP = New List(Of EMEPc)
            MapSetupUI()
            For Each c As Control In EMEPgb.Controls
                c.Enabled = False
            Next
            EMEPcb.Enabled = True : EMEPp.Enabled = True
        Else
            m.EMEP.RemoveAt(i)
            EMEPcb.Items.RemoveAt(i)
            EMEPcb.SelectedIndex = If(i = 0, 0, i - 1)
        End If
    End Sub
    Private Sub EME2p_Click(sender As Object, e As EventArgs) Handles EME2p.Click
        For Each c As Control In EME2gb.Controls
            c.Enabled = True
        Next
        m.EME2.Add(New EME2c())
        EME2cb.Items.Add(EME2cb.Items.Count + 1)
        EME2cb.SelectedIndex = EME2cb.Items.Count - 1
    End Sub

    Private Sub EME2m_Click(sender As Object, e As EventArgs) Handles EME2m.Click
        Dim i = EME2cb.SelectedIndex
        If m.EME2.Count = 1 Then
            m.EME2 = New List(Of EME2c)
            MapSetupUI()
            For Each c As Control In EME2gb.Controls
                c.Enabled = False
            Next
            EME2cb.Enabled = True : EME2p.Enabled = True
        Else
            m.EME2.RemoveAt(i)
            EME2cb.Items.RemoveAt(i)
            EME2cb.SelectedIndex = If(i = 0, 0, i - 1)
        End If
    End Sub

    Private Sub EMEFm_Click(sender As Object, e As EventArgs) Handles EMEFm.Click
        Dim i = EMEFcb.SelectedIndex
        If m.EMEF.Count = 1 Then
            m.EMEF = New List(Of EMEFc)
            MapSetupUI()
            For Each c As Control In EMEFgb.Controls
                c.Enabled = False
            Next
            EMEFcb.Enabled = True : EMEFp.Enabled = True
        Else
            m.EMEF.RemoveAt(i)
            EMEFcb.Items.RemoveAt(i)
            EMEFcb.SelectedIndex = If(i = 0, 0, i - 1)
        End If
    End Sub

    Private Sub EMEFp_Click(sender As Object, e As EventArgs) Handles EMEFp.Click
        For Each c As Control In EMEFgb.Controls
            c.Enabled = True
        Next
        m.EMEF.Add(New EMEFc())
        EMEFcb.Items.Add(EMEFcb.Items.Count + 1)
        EMEFcb.SelectedIndex = EMEFcb.Items.Count - 1
    End Sub

    Private Sub EMSDm_Click(sender As Object, e As EventArgs) Handles EMSDm.Click
        Dim i = EMSDcb.SelectedIndex
        If m.EMSD.Count = 1 Then
            m.EMSD = New List(Of EMSDc)
            MapSetupUI()
            For Each c As Control In EMSDgb.Controls
                c.Enabled = False
            Next
            EMSDcb.Enabled = True : EMSDp.Enabled = True
        Else
            m.EMSD.RemoveAt(i)
            EMSDcb.Items.RemoveAt(i)
            lEMSDi = -1
            EMSDcb.SelectedIndex = If(i = 0, 0, i - 1)
        End If
    End Sub

    Private Sub EMSDp_Click(sender As Object, e As EventArgs) Handles EMSDp.Click
        For Each c As Control In EMSDgb.Controls
            c.Enabled = True
        Next
        m.EMSD.Add(New EMSDc())
        EMSDcb.Items.Add(EMSDcb.Items.Count + 1)
        EMSDcb.SelectedIndex = EMSDcb.Items.Count - 1
    End Sub

    Private Sub EPTHm_Click(sender As Object, e As EventArgs) Handles EPTHm.Click
        Dim i = EPTHcb.SelectedIndex
        If m.EPTH.Count = 1 Then
            m.EPTH = New List(Of EPTHc)
            MapSetupUI()
            For Each c As Control In EPTHGB.Controls
                c.Enabled = False
            Next
            EPTHcb.Enabled = True : EPTHp.Enabled = True
        Else
            m.EPTH.RemoveAt(i)
            EPTHcb.Items.RemoveAt(i)
            lEPTHi = -1
            EPTHcb.SelectedIndex = If(i = 0, 0, i - 1)
        End If
    End Sub

    Private Sub EPTHp_Click(sender As Object, e As EventArgs) Handles EPTHp.Click
        For Each c As Control In EPTHGB.Controls
            c.Enabled = True
        Next
        m.EPTH.Add(New EPTHc())
        EPTHcb.Items.Add(EPTHcb.Items.Count + 1)
        EPTHcb.SelectedIndex = EPTHcb.Items.Count - 1
    End Sub

    Private Sub Triggerm_Click(sender As Object, e As EventArgs) Handles Triggerm.Click
        Dim i = Triggercb.SelectedIndex
        If m.Triggers.Count = 1 Then
            m.Triggers = New List(Of Trigger)
            MapSetupUI()
            For Each c As Control In Triggergb.Controls
                c.Enabled = False
            Next
            Triggercb.Enabled = True : Triggerp.Enabled = True
        Else
            m.Triggers.RemoveAt(i)
            Triggercb.Items.RemoveAt(i)
            lTriggeri = -1
            Triggercb.SelectedIndex = If(i = 0, 0, i - 1)
        End If
    End Sub

    Private Sub Triggerp_Click(sender As Object, e As EventArgs) Handles Triggerp.Click
        For Each c As Control In Triggergb.Controls
            c.Enabled = True
        Next
        m.Triggers.Add(New Trigger())
        Triggercb.Items.Add(Triggercb.Items.Count + 1)
        Triggercb.SelectedIndex = Triggercb.Items.Count - 1
    End Sub

    Private Sub DarkButton2_Click_1(sender As Object, e As EventArgs) Handles DarkButton2.Click
        Dim type = InputBox("Which file type would you like to create?", "Van Buren Editor", "")
        ext = type.ToLower()
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
#Region ".map"
            Case ".map"
                SetMaplin1()

                m = New Map With ' Initialize file with necessary Chunks
                {
                    .EMAP = New EMAPc(),
                    .EMEP = New List(Of EMEPc),
                    .EME2 = New List(Of EME2c),
                    .EMEF = New List(Of EMEFc),
                    .EMSD = New List(Of EMSDc),
                    .EPTH = New List(Of EPTHc),
                    .Triggers = New List(Of Trigger),
                    .ECAM = Nothing,
                    .EMNP = New Byte() {&H45, &H4D, &H4E, &H50, &H0, &H0, &H0, &H0, &H10, &H0, &H0, &H0, &H0, &H0, &H0, &H0} ' EMNP Never changes, but not having it in addition to missing EMEP causes the map not to render, so I'm adding it here.
                }
                MapSetupUI()
#End Region
            Case ".use"
                MsgBox("Not yet implemented")
            Case ".veg"
                MsgBox("Not yet implemented")
            Case ".wea"
                MsgBox("Not yet implemented")
            Case Else
                MsgBox("Invalid file type")
        End Select
    End Sub

    Private Sub SetMaplin1()
        lEME2i = -1
        lEMEPi = -1
        lTriggeri = -1
        lTriggerpi = -1
        lEPTHi = -1
        lEPTHpi = -1
        lEMSDi = -1
        lEMEFi = -1
    End Sub
#Region ".stf Stuff"
    Private Sub DarkButton3_Click_1(sender As Object, e As EventArgs) Handles DarkButton3.Click
        Dim ofd As New OpenFileDialog With {.Filter = "Van Buren String Table File|*.stf", .Multiselect = False}
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim sfd As New SaveFileDialog With {.Filter = "Text File|*.txt"}
            If sfd.ShowDialog() = DialogResult.OK Then
                File.WriteAllLines(sfd.FileName, STFToTXT(File.ReadAllBytes(ofd.FileName)))
            End If
        End If
    End Sub

    Private Sub DarkButton4_Click(sender As Object, e As EventArgs) Handles DarkButton4.Click
        Dim ofd As New OpenFileDialog With {.Filter = "Text File|*.txt", .Multiselect = False}
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim sfd As New SaveFileDialog With {.Filter = "Van Buren String Table File|*.stf"}
            If sfd.ShowDialog() = DialogResult.OK Then
                File.WriteAllBytes(sfd.FileName, TXTToSTF(IO.File.ReadAllLines(ofd.FileName)))
            End If
        End If
    End Sub
#End Region
End Class