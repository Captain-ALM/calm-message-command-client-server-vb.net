<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBoxLog = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtbxlog = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBoxCMDARR = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.butenter = New System.Windows.Forms.Button()
        Me.chkbxenter = New System.Windows.Forms.CheckBox()
        Me.txtbxcmd = New System.Windows.Forms.TextBox()
        Me.GroupBoxPRCONTR = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.butexit = New System.Windows.Forms.Button()
        Me.butreset = New System.Windows.Forms.Button()
        Me.butmcmdarr = New System.Windows.Forms.Button()
        Me.butabout = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBoxLog.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBoxCMDARR.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBoxPRCONTR.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxLog, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(584, 361)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBoxLog
        '
        Me.GroupBoxLog.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupBoxLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxLog.Location = New System.Drawing.Point(3, 93)
        Me.GroupBoxLog.Name = "GroupBoxLog"
        Me.GroupBoxLog.Size = New System.Drawing.Size(578, 265)
        Me.GroupBoxLog.TabIndex = 1
        Me.GroupBoxLog.TabStop = False
        Me.GroupBoxLog.Text = "Operation Log"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel7, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 246.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(572, 246)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 1
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.txtbxlog, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(566, 240)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'txtbxlog
        '
        Me.txtbxlog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtbxlog.Location = New System.Drawing.Point(3, 3)
        Me.txtbxlog.Multiline = True
        Me.txtbxlog.Name = "txtbxlog"
        Me.txtbxlog.ReadOnly = True
        Me.txtbxlog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtbxlog.Size = New System.Drawing.Size(560, 234)
        Me.txtbxlog.TabIndex = 0
        Me.txtbxlog.WordWrap = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxCMDARR, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxPRCONTR, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(578, 84)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'GroupBoxCMDARR
        '
        Me.GroupBoxCMDARR.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBoxCMDARR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxCMDARR.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxCMDARR.Name = "GroupBoxCMDARR"
        Me.GroupBoxCMDARR.Size = New System.Drawing.Size(340, 78)
        Me.GroupBoxCMDARR.TabIndex = 0
        Me.GroupBoxCMDARR.TabStop = False
        Me.GroupBoxCMDARR.Text = "Command Area"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtbxcmd, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(334, 59)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.butenter, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.chkbxenter, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(236, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(95, 53)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'butenter
        '
        Me.butenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butenter.Location = New System.Drawing.Point(3, 3)
        Me.butenter.Name = "butenter"
        Me.butenter.Size = New System.Drawing.Size(89, 20)
        Me.butenter.TabIndex = 0
        Me.butenter.Text = "Enter"
        Me.butenter.UseVisualStyleBackColor = True
        '
        'chkbxenter
        '
        Me.chkbxenter.Checked = True
        Me.chkbxenter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkbxenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkbxenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbxenter.Location = New System.Drawing.Point(3, 29)
        Me.chkbxenter.Name = "chkbxenter"
        Me.chkbxenter.Size = New System.Drawing.Size(89, 21)
        Me.chkbxenter.TabIndex = 1
        Me.chkbxenter.Text = "Read Enter Key"
        Me.chkbxenter.UseVisualStyleBackColor = True
        '
        'txtbxcmd
        '
        Me.txtbxcmd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtbxcmd.Location = New System.Drawing.Point(3, 3)
        Me.txtbxcmd.Multiline = True
        Me.txtbxcmd.Name = "txtbxcmd"
        Me.txtbxcmd.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtbxcmd.Size = New System.Drawing.Size(227, 53)
        Me.txtbxcmd.TabIndex = 0
        Me.txtbxcmd.WordWrap = False
        '
        'GroupBoxPRCONTR
        '
        Me.GroupBoxPRCONTR.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBoxPRCONTR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxPRCONTR.Location = New System.Drawing.Point(349, 3)
        Me.GroupBoxPRCONTR.Name = "GroupBoxPRCONTR"
        Me.GroupBoxPRCONTR.Size = New System.Drawing.Size(226, 78)
        Me.GroupBoxPRCONTR.TabIndex = 1
        Me.GroupBoxPRCONTR.TabStop = False
        Me.GroupBoxPRCONTR.Text = "Program Control"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.butexit, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.butreset, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.butmcmdarr, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.butabout, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(220, 59)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'butexit
        '
        Me.butexit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butexit.Location = New System.Drawing.Point(113, 32)
        Me.butexit.Name = "butexit"
        Me.butexit.Size = New System.Drawing.Size(104, 24)
        Me.butexit.TabIndex = 3
        Me.butexit.Text = "Exit Program"
        Me.butexit.UseVisualStyleBackColor = True
        '
        'butreset
        '
        Me.butreset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butreset.Location = New System.Drawing.Point(3, 32)
        Me.butreset.Name = "butreset"
        Me.butreset.Size = New System.Drawing.Size(104, 24)
        Me.butreset.TabIndex = 2
        Me.butreset.Text = "Restart Program"
        Me.butreset.UseVisualStyleBackColor = True
        '
        'butmcmdarr
        '
        Me.butmcmdarr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butmcmdarr.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butmcmdarr.Location = New System.Drawing.Point(3, 3)
        Me.butmcmdarr.Name = "butmcmdarr"
        Me.butmcmdarr.Size = New System.Drawing.Size(104, 23)
        Me.butmcmdarr.TabIndex = 0
        Me.butmcmdarr.Text = "Move Command Area To The Bottom"
        Me.butmcmdarr.UseVisualStyleBackColor = True
        '
        'butabout
        '
        Me.butabout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.butabout.Location = New System.Drawing.Point(113, 3)
        Me.butabout.Name = "butabout"
        Me.butabout.Size = New System.Drawing.Size(104, 23)
        Me.butabout.TabIndex = 1
        Me.butabout.Text = "About"
        Me.butabout.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.Name = "main"
        Me.Text = "Message Command Client & Server"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBoxLog.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBoxCMDARR.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.GroupBoxPRCONTR.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxLog As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxCMDARR As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxPRCONTR As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtbxcmd As System.Windows.Forms.TextBox
    Friend WithEvents butenter As System.Windows.Forms.Button
    Friend WithEvents chkbxenter As System.Windows.Forms.CheckBox
    Friend WithEvents butmcmdarr As System.Windows.Forms.Button
    Friend WithEvents butabout As System.Windows.Forms.Button
    Friend WithEvents butexit As System.Windows.Forms.Button
    Friend WithEvents butreset As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtbxlog As System.Windows.Forms.TextBox

End Class
