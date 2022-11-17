Imports System.IO
Imports AltUI.Config
Imports AltUI.Controls

Public Class UI
    Private f As String
    Private ext As String
    Private m As New Map

    Private Sub OpenFile() Handles OpenToolStripMenuItem.Click
        ' Loads all regions of a given file into their respective classes, and from there into the UI
        Dim ofd As New OpenFileDialog With {.Filter = "Van Buren Data File|*.amo;*.arm;*.con;*.crt;*.dor;*.int;*.itm;*.map;*.use;*.veg;*.wea", .Multiselect = False, .ValidateNames = True}
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
                    m = New Map
                    m.EMAP = f.GetRegions("EMAP")(0).ToEMAPc
                    m.EME2 = (From x In f.GetRegions("EME2") Select x.ToEME2c).ToList
                    m.EMEP = (From x In f.GetRegions("EMEP") Select x.ToEMEPc).ToList
                    Try : m.ECAM = f.GetRegions("ECAM")(0).ToECAMc : Catch : End Try
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
        Dim en As Boolean
        For Each c As DarkGroupBox In From con In Controls Where TypeOf con Is DarkGroupBox
            For Each c2 As DarkGroupBox In From con In c.Controls Where TypeOf con Is DarkGroupBox
                For Each c3 In c2.Controls
                    en = c3.Enabled
                    c3.enabled = False
                    If TypeOf c3 Is DarkTextBox Then
                        c3.Text = ""
                    ElseIf TypeOf c3 Is DarkNumericUpDown Then
                        Try : c3.Value = c3.Minimum : Catch : End Try
                    ElseIf TypeOf c3 Is DarkComboBox AndAlso Not c3.name = "Triggertcb" Then
                        c3.Items.Clear
                        c3.Refresh() ' Refresh control so the text region is not transparent
                    ElseIf TypeOf c3 Is DataGridView Then
                        c3.DataSource = Nothing
                    End If
                    c3.enabled = en
                Next
            Next
        Next
    End Sub
    Private Sub MapSetupUI()
        Mapgb.Show()
        ResetUI()
        EMAPToUI()
        For Each EME2 In m.EME2
            EME2cb.Items.Add(EME2.name)
        Next
        If m.EME2.Any() Then
            EME2cb.SelectedIndex = 0
            For Each c As Control In EME2gb.Controls
                c.Enabled = True
            Next
            EME2ToUI()
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
            For Each c As Control In EMEPgb.Controls
                c.Enabled = True
            Next
            EMEPToUI()
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
            For Each c As Control In Triggergb.Controls
                c.Enabled = True
            Next
            TriggerToUI()
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
            For Each c As Control In EPTHGB.Controls
                c.Enabled = True
            Next
            EPTHToUI()
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
            For Each c As Control In EMSDgb.Controls
                c.Enabled = True
            Next
            EMSDToUI()
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
            For Each c As Control In EMEFgb.Controls
                c.Enabled = True
            Next
            EMEFToUI()
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
    Private Sub TriggerToUI() Handles Triggercb.SelectedIndexChanged
        Triggernud.Value = 1
        Triggertcb.SelectedItem = m.Triggers(Triggercb.SelectedIndex).ExTR.type
        Triggern.Enabled = True
        Triggern.Text = m.Triggers(Triggercb.SelectedIndex).ExTR.s
        Triggernud_ValueChanged()
    End Sub
    Private Sub Triggernud_ValueChanged() Handles Triggernud.ValueChanged
        If Triggernud.Enabled Then
            If Triggernud.Value > m.Triggers(Triggercb.SelectedIndex).EMTR.r.Count Then
                m.Triggers(Triggercb.SelectedIndex).EMTR.r.Add(New Point3(0, 0, 0))
            End If
            Triggerx.Text = m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggernud.Value - 1).x
            Triggery.Text = m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggernud.Value - 1).y
            Triggerz.Text = m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggernud.Value - 1).z
        End If
    End Sub
    Private Sub EPTHToUI() Handles EPTHcb.SelectedIndexChanged
        EPTHnud.Value = 1
        EPTHn.Text = m.EPTH(EPTHcb.SelectedIndex).name
        EPTHnud_ValueChanged()
    End Sub
    Private Sub EPTHnud_ValueChanged() Handles EPTHnud.ValueChanged
        If EPTHnud.Enabled Then
            If EPTHnud.Value > m.EPTH(EPTHcb.SelectedIndex).p.Count Then
                m.EPTH(EPTHcb.SelectedIndex).p.Add(New Point4(0, 0, 0, 0))
            End If
            EPTHx.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHnud.Value - 1).x
            EPTHy.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHnud.Value - 1).y
            EPTHz.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHnud.Value - 1).z
            EPTHr.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHnud.Value - 1).r
        End If
    End Sub
    Private Sub Triggerpm_Click() Handles Triggerpm.Click
        Dim i = Triggernud.Value - 1
        If m.Triggers(Triggercb.SelectedIndex).EMTR.r.Count <> 1 Then
            m.Triggers(Triggercb.SelectedIndex).EMTR.r.RemoveAt(i)
            Triggernud.Value = i
        End If
    End Sub
    Private Sub EPTHpm_Click() Handles EPTHpm.Click
        Dim i = EPTHnud.Value - 1
        If m.EPTH(EPTHcb.SelectedIndex).p.Count <> 1 Then
            m.EPTH(EPTHcb.SelectedIndex).p.RemoveAt(i)
            EPTHnud.Value = i
        End If
    End Sub
    Private Sub EMSDToUI() Handles EMSDcb.SelectedIndexChanged
        EMSDs1.Text = m.EMSD(EMSDcb.SelectedIndex).s1
        EMSDs2.Text = m.EMSD(EMSDcb.SelectedIndex).s2.Replace(".psf", "")
        EMSDx.Text = m.EMSD(EMSDcb.SelectedIndex).l.x
        EMSDy.Text = m.EMSD(EMSDcb.SelectedIndex).l.y
        EMSDz.Text = m.EMSD(EMSDcb.SelectedIndex).l.z
    End Sub
    Private Sub EMEFToUI() Handles EMEFcb.SelectedIndexChanged
        EMEFs1.Text = m.EMEF(EMEFcb.SelectedIndex).s1
        EMEFs2.Text = m.EMEF(EMEFcb.SelectedIndex).s2.Replace(".veg", "")
        EMEFx.Text = m.EMEF(EMEFcb.SelectedIndex).l.x
        EMEFy.Text = m.EMEF(EMEFcb.SelectedIndex).l.y
        EMEFz.Text = m.EMEF(EMEFcb.SelectedIndex).l.z
        EMEFr.Text = m.EMEF(EMEFcb.SelectedIndex).l.r
    End Sub
#End Region
#Region "Load UI into classes"
    Private Sub PickLightingColour(sender As Object, e As EventArgs) Handles EMAPslb.Click
        Dim cd As New ColorDialog With {.Color = m.EMAP.col, .FullOpen = True}
        If cd.ShowDialog() = DialogResult.OK Then
            EMAPslb.BorderColour = cd.Color
            m.EMAP.col = cd.Color
        End If
    End Sub
    Private Sub EMAPilcb_CheckedChanged(sender As Object, e As EventArgs) Handles EMAPilcb.CheckedChanged
        If sender.Enabled Then m.EMAP.il = EMAPilcb.Checked
    End Sub
    Private Sub EMAPs1_TextChanged(sender As Object, e As EventArgs) Handles EMAPs1.TextChanged
        If sender.Enabled Then m.EMAP.s1 = EMAPs1.Text & If(String.IsNullOrWhiteSpace(EMAPs1.Text), "", ".8")
    End Sub
    Private Sub EMAPs2_TextChanged(sender As Object, e As EventArgs) Handles EMAPs2.TextChanged
        If sender.Enabled Then m.EMAP.s2 = EMAPs2.Text & If(String.IsNullOrWhiteSpace(EMAPs2.Text), "", ".rle")
    End Sub
    Private Sub EMAPs3_TextChanged(sender As Object, e As EventArgs) Handles EMAPs3.TextChanged
        If sender.Enabled Then m.EMAP.s3 = EMAPs3.Text & If(String.IsNullOrWhiteSpace(EMAPs3.Text), "", ".dds")
    End Sub
    Private Sub ECAMx_TextChanged(sender As Object, e As EventArgs) Handles ECAMx.TextChanged
        If m.ECAM Is Nothing Then m.ECAM = New ECAMc()
        If sender.Enabled Then m.ECAM.p.x = (0 & ECAMx.Text).Replace("0-", "-0")
    End Sub
    Private Sub ECAMy_TextChanged(sender As Object, e As EventArgs) Handles ECAMy.TextChanged
        If m.ECAM Is Nothing Then m.ECAM = New ECAMc()
        If sender.Enabled Then m.ECAM.p.y = (0 & ECAMy.Text).Replace("0-", "-0")
    End Sub
    Private Sub ECAMz_TextChanged(sender As Object, e As EventArgs) Handles ECAMz.TextChanged
        If m.ECAM Is Nothing Then m.ECAM = New ECAMc()
        If sender.Enabled Then m.ECAM.p.z = (0 & ECAMz.Text).Replace("0-", "-0")
    End Sub
    Private Sub ECAMr_TextChanged(sender As Object, e As EventArgs) Handles ECAMr.TextChanged
        If m.ECAM Is Nothing Then m.ECAM = New ECAMc()
        If sender.Enabled Then m.ECAM.p.r = (0 & ECAMr.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMEFs1_TextChanged(sender As Object, e As EventArgs) Handles EMEFs1.TextChanged
        If sender.Enabled Then m.EMEF(EMEFcb.SelectedIndex).s1 = EMEFs1.Text
    End Sub
    Private Sub EMEFs2_TextChanged(sender As Object, e As EventArgs) Handles EMEFs2.TextChanged
        If sender.Enabled Then m.EMEF(EMEFcb.SelectedIndex).s2 = EMEFs2.Text & If(String.IsNullOrWhiteSpace(EMEFs2.Text), "", ".veg")
    End Sub
    Private Sub EMEFx_TextChanged(sender As Object, e As EventArgs) Handles EMEFx.TextChanged
        If sender.Enabled Then m.EMEF(EMEFcb.SelectedIndex).l.x = (0 & EMEFx.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMEFy_TextChanged(sender As Object, e As EventArgs) Handles EMEFy.TextChanged
        If sender.Enabled Then m.EMEF(EMEFcb.SelectedIndex).l.y = (0 & EMEFy.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMEFz_TextChanged(sender As Object, e As EventArgs) Handles EMEFz.TextChanged
        If sender.Enabled Then m.EMEF(EMEFcb.SelectedIndex).l.z = (0 & EMEFz.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMEFr_TextChanged(sender As Object, e As EventArgs) Handles EMEFr.TextChanged
        If sender.Enabled Then m.EMEF(EMEFcb.SelectedIndex).l.r = (0 & EMEFr.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMEPnud_ValueChanged(sender As Object, e As EventArgs) Handles EMEPnud.ValueChanged
        If sender.Enabled Then m.EMEP(EMEPcb.SelectedIndex).index = EMEPnud.Value
    End Sub
    Private Sub EMEPx_TextChanged(sender As Object, e As EventArgs) Handles EMEPx.TextChanged
        If sender.Enabled Then m.EMEP(EMEPcb.SelectedIndex).p.x = (0 & EMEPx.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMEPy_TextChanged(sender As Object, e As EventArgs) Handles EMEPy.TextChanged
        If sender.Enabled Then m.EMEP(EMEPcb.SelectedIndex).p.y = (0 & EMEPy.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMEPz_TextChanged(sender As Object, e As EventArgs) Handles EMEPz.TextChanged
        If sender.Enabled Then m.EMEP(EMEPcb.SelectedIndex).p.z = (0 & EMEPz.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMEPr_TextChanged(sender As Object, e As EventArgs) Handles EMEPr.TextChanged
        If sender.Enabled Then m.EMEP(EMEPcb.SelectedIndex).p.r = (0 & EMEPr.Text).Replace("0-", "-0")
    End Sub
    Private Sub EME2dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles EME2dgv.CellEndEdit
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).EEOV.inv = (From row As DataGridViewRow In EME2dgv.Rows Where TypeOf row.Cells.Item(0).Value Is String Select row.Cells.Item(0).Value).Cast(Of String)().ToArray()
    End Sub
    Private Sub EME2n_TextChanged(sender As Object, e As EventArgs) Handles EME2n.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).name = EME2n.Text
    End Sub
    Private Sub EME2s1_TextChanged(sender As Object, e As EventArgs) Handles EME2s1.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).EEOV.s1 = EME2s1.Text
    End Sub
    Private Sub EME2s2_TextChanged(sender As Object, e As EventArgs) Handles EME2s2.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).EEOV.s2 = EME2s2.Text
    End Sub
    Private Sub EME2s3_TextChanged(sender As Object, e As EventArgs) Handles EME2s3.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).EEOV.s3 = EME2s3.Text & If(String.IsNullOrWhiteSpace(EME2s3.Text), "", ".amx")
    End Sub
    Private Sub EME2s4_TextChanged(sender As Object, e As EventArgs) Handles EME2s4.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).EEOV.s4 = EME2s4.Text & If(String.IsNullOrWhiteSpace(EME2s4.Text), "", ".dds")
    End Sub
    Private Sub EME2s5_TextChanged(sender As Object, e As EventArgs) Handles EME2s5.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).EEOV.s5 = EME2s5.Text & If(String.IsNullOrWhiteSpace(EME2s5.Text), "", ".veg")
    End Sub
    Private Sub EME2x_TextChanged(sender As Object, e As EventArgs) Handles EME2x.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).l.x = (0 & EME2x.Text).Replace("0-", "-0")
    End Sub
    Private Sub EME2y_TextChanged(sender As Object, e As EventArgs) Handles EME2y.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).l.y = (0 & EME2y.Text).Replace("0-", "-0")
    End Sub
    Private Sub EME2z_TextChanged(sender As Object, e As EventArgs) Handles EME2z.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).l.z = (0 & EME2z.Text).Replace("0-", "-0")
    End Sub
    Private Sub EME2r_TextChanged(sender As Object, e As EventArgs) Handles EME2r.TextChanged
        If sender.Enabled Then m.EME2(EME2cb.SelectedIndex).l.r = (0 & EME2r.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMSDs1_TextChanged(sender As Object, e As EventArgs) Handles EMSDs1.TextChanged
        If sender.Enabled Then m.EMSD(EMSDcb.SelectedIndex).s1 = EMSDs1.Text
    End Sub
    Private Sub EMSDs2_TextChanged(sender As Object, e As EventArgs) Handles EMSDs2.TextChanged
        If sender.Enabled Then m.EMSD(EMSDcb.SelectedIndex).s2 = EMSDs2.Text & If(String.IsNullOrWhiteSpace(EMSDs2.Text), "", ".psf")
    End Sub
    Private Sub EMSDx_TextChanged(sender As Object, e As EventArgs) Handles EMSDx.TextChanged
        If sender.Enabled Then m.EMSD(EMSDcb.SelectedIndex).l.x = (0 & EMSDx.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMSDy_TextChanged(sender As Object, e As EventArgs) Handles EMSDy.TextChanged
        If sender.Enabled Then m.EMSD(EMSDcb.SelectedIndex).l.y = (0 & EMSDy.Text).Replace("0-", "-0")
    End Sub
    Private Sub EMSDz_TextChanged(sender As Object, e As EventArgs) Handles EMSDz.TextChanged
        If sender.Enabled Then m.EMSD(EMSDcb.SelectedIndex).l.z = (0 & EMSDz.Text).Replace("0-", "-0")
    End Sub
    Private Sub EPTHn_TextChanged(sender As Object, e As EventArgs) Handles EPTHn.TextChanged
        If sender.Enabled Then m.EPTH(EPTHcb.SelectedIndex).name = EPTHn.Text
    End Sub
    Private Sub EPTHx_TextChanged(sender As Object, e As EventArgs) Handles EPTHx.TextChanged
        If sender.Enabled Then m.EPTH(EPTHcb.SelectedIndex).p(EPTHnud.Value - 1).x = (0 & EPTHx.Text).Replace("0-", "-0")
    End Sub
    Private Sub EPTHy_TextChanged(sender As Object, e As EventArgs) Handles EPTHy.TextChanged
        If sender.Enabled Then m.EPTH(EPTHcb.SelectedIndex).p(EPTHnud.Value - 1).y = (0 & EPTHy.Text).Replace("0-", "-0")
    End Sub
    Private Sub EPTHz_TextChanged(sender As Object, e As EventArgs) Handles EPTHz.TextChanged
        If sender.Enabled Then m.EPTH(EPTHcb.SelectedIndex).p(EPTHnud.Value - 1).z = (0 & EPTHz.Text).Replace("0-", "-0")
    End Sub
    Private Sub EPTHr_TextChanged(sender As Object, e As EventArgs) Handles EPTHr.TextChanged
        If sender.Enabled Then m.EPTH(EPTHcb.SelectedIndex).p(EPTHnud.Value - 1).r = (0 & EPTHr.Text).Replace("0-", "-0")
    End Sub
    Private Sub Triggern_TextChanged(sender As Object, e As EventArgs) Handles Triggern.TextChanged
        If sender.Enabled Then m.Triggers(Triggercb.SelectedIndex).ExTR.s = Triggern.Text
    End Sub
    Private Sub Triggertcb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Triggertcb.SelectedIndexChanged
        If sender.Enabled Then m.Triggers(Triggercb.SelectedIndex).ExTR.type = Triggertcb.SelectedText
    End Sub
    Private Sub Triggerx_TextChanged(sender As Object, e As EventArgs) Handles Triggerx.TextChanged
        If sender.Enabled Then m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggernud.Value - 1).x = (0 & Triggerx.Text).Replace("0-", "-0")
    End Sub
    Private Sub Triggery_TextChanged(sender As Object, e As EventArgs) Handles Triggery.TextChanged
        If sender.Enabled Then m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggernud.Value - 1).y = (0 & Triggery.Text).Replace("0-", "-0")
    End Sub
    Private Sub Triggerz_TextChanged(sender As Object, e As EventArgs) Handles Triggerz.TextChanged
        If sender.Enabled Then m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggernud.Value - 1).z = (0 & Triggerz.Text).Replace("0-", "-0")
    End Sub
    ' Prevent invalid floats from being entered into text boxes (Add any numeric textboxes to the "Handles" section)
    Private Sub NumbersOnly(sender As TextBox, e As KeyPressEventArgs) _
        Handles ECAMx.KeyPress, ECAMy.KeyPress, ECAMz.KeyPress, ECAMr.KeyPress, EMEPx.KeyPress, EMEPy.KeyPress,
                EMEPz.KeyPress, EMEPr.KeyPress, EMEFx.KeyPress, EMEFy.KeyPress, EMEFz.KeyPress, EMEFr.KeyPress,
                EMSDx.KeyPress, EMSDy.KeyPress, EMSDz.KeyPress, EME2x.KeyPress, EME2y.KeyPress, EME2z.KeyPress,
                EME2r.KeyPress, EPTHx.KeyPress, EPTHy.KeyPress, EPTHz.KeyPress, EPTHr.KeyPress, Triggerx.KeyPress,
                Triggery.KeyPress, Triggerz.KeyPress
        ' This code inserts the pressed character into the existing text (unless it's a backspace), and adds a 0 either at the start, or after "-", if present.
        ' By doing this, it allows any number to be typed, but only if it's valid, while still allowing you to start with a "-" sign
        ' It's done this way so everything here happens before the text is updated, and if it's not a valid number, the text is never written.
        If Not Char.IsControl(e.KeyChar) Then
            If Not Single.TryParse((0 & sender.Text.Insert(sender.SelectionStart, e.KeyChar)).Replace("0-", "-0"), 0F) Then
                e.Handled = True
            End If
        End If
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
    Private Sub SaveFile() Handles SaveToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog With {.Filter = $"Van Buren Data File|*{ext}", .ValidateNames = True, .DefaultExt = ext}
        If sfd.ShowDialog = DialogResult.OK Then
            Dim b As New List(Of Byte)
            Select Case ext
                Case ".amo"
                Case ".arm"
                Case ".con"
                Case ".crt"
                Case ".dor"
                Case ".int"
                Case ".itm"
                Case ".map"
                    b.AddRange(m.EMAP.ToEMAPb)
                    b.AddRange(m.EME2.SelectMany(Function(x) x.ToEME2b()))
                    b.AddRange(m.EMEP.SelectMany(Function(x) x.ToEMEPb()))
                    If m.ECAM IsNot Nothing Then b.AddRange(m.ECAM.ToECAMb())
                    b.AddRange(m.Triggers.SelectMany(Function(x) x.ToTriggerB()))
                    b.AddRange(m.EPTH.SelectMany(Function(x) x.ToEPTHb()))
                    b.AddRange(m.EMSD.SelectMany(Function(x) x.ToEMSDb()))
                    b.AddRange(m.EMNP)
                    b.AddRange(m.EMEF.SelectMany(Function(x) x.ToEMEFb()))
                Case ".use"
                Case ".veg"
                Case ".wea"
            End Select
            File.WriteAllBytes(sfd.FileName, b.ToArray)
        End If
    End Sub
    Private Sub MyBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mapgb.Hide()
        EPTHnud.Enabled = False
        Triggernud.Enabled = False
        EPTHnud.Minimum = 1
        Triggernud.Minimum = 1
        EMAPslb.CustomColour = True
        EME2dgv.GridColor = ThemeProvider.Theme.Colors.GreySelection
        EME2dgv.BackgroundColor = ThemeProvider.BackgroundColour
        EME2dgv.DefaultCellStyle = New DataGridViewCellStyle With {.BackColor = ThemeProvider.BackgroundColour, .ForeColor = ThemeProvider.Theme.Colors.LightText, .SelectionBackColor = ThemeProvider.Theme.Colors.BlueSelection, .SelectionForeColor = ThemeProvider.Theme.Colors.LightText}
    End Sub



#Region "Remove/Add Chunks"
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
#End Region
#Region "New Files"
    Private Sub NewAmo() Handles AmoToolStripMenuItem.Click
    End Sub
    Private Sub NewArm() Handles ArmToolStripMenuItem.Click
    End Sub
    Private Sub NewCon() Handles ConToolStripMenuItem.Click
    End Sub
    Private Sub NewCrt() Handles CrtToolStripMenuItem.Click
    End Sub
    Private Sub NewDor() Handles DorToolStripMenuItem.Click
    End Sub
    Private Sub NewInt() Handles IntToolStripMenuItem.Click
    End Sub
    Private Sub NewItm() Handles ItmToolStripMenuItem.Click
    End Sub
    Private Sub NewMap() Handles MapToolStripMenuItem.Click
        ext = ".map"
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
    End Sub
    Private Sub NewUse() Handles UseToolStripMenuItem.Click
    End Sub
    Private Sub NewVeg() Handles VegToolStripMenuItem.Click
    End Sub
    Private Sub NewWea() Handles WeaToolStripMenuItem.Click
    End Sub
#End Region
#Region ".stf Stuff"
    Private Sub FullSTFToText() Handles StfToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog With {.Filter = "String Table File|*.stf", .Multiselect = False}
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim sfd As New SaveFileDialog With {.Filter = "Text File|*.txt"}
            If sfd.ShowDialog() = DialogResult.OK Then
                File.WriteAllLines(sfd.FileName, STFToTXT(File.ReadAllBytes(ofd.FileName)))
            End If
        End If
    End Sub
    Private Sub FullTextToSTF() Handles TxtTostfToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog With {.Filter = "Text File|*.txt", .Multiselect = False}
        If ofd.ShowDialog() = DialogResult.OK Then
            Dim sfd As New SaveFileDialog With {.Filter = "String Table File|*.stf"}
            If sfd.ShowDialog() = DialogResult.OK Then
                File.WriteAllBytes(sfd.FileName, TXTToSTF(IO.File.ReadAllLines(ofd.FileName)))
            End If
        End If
    End Sub
#End Region
    Private Sub SetEnglishstfLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetEnglishstfLocationToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog With {.Multiselect = False, .CheckFileExists = True, .Filter = "English.stf|*.stf"}
        If ofd.ShowDialog() = DialogResult.OK Then
            My.Settings.STFDir = ofd.FileName
        End If
    End Sub
End Class