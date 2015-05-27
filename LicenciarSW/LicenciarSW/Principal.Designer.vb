<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.txtDireccionMAC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLicenciar = New System.Windows.Forms.Button()
        Me.btnEliminarLicencia = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGuidAplicacion = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtDireccionMAC
        '
        Me.txtDireccionMAC.Location = New System.Drawing.Point(109, 53)
        Me.txtDireccionMAC.Name = "txtDireccionMAC"
        Me.txtDireccionMAC.ReadOnly = True
        Me.txtDireccionMAC.Size = New System.Drawing.Size(264, 20)
        Me.txtDireccionMAC.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Dirección MAC"
        '
        'btnLicenciar
        '
        Me.btnLicenciar.Image = CType(resources.GetObject("btnLicenciar.Image"), System.Drawing.Image)
        Me.btnLicenciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLicenciar.Location = New System.Drawing.Point(25, 206)
        Me.btnLicenciar.Name = "btnLicenciar"
        Me.btnLicenciar.Size = New System.Drawing.Size(142, 59)
        Me.btnLicenciar.TabIndex = 2
        Me.btnLicenciar.Text = "Licenciar"
        Me.btnLicenciar.UseVisualStyleBackColor = True
        '
        'btnEliminarLicencia
        '
        Me.btnEliminarLicencia.Image = CType(resources.GetObject("btnEliminarLicencia.Image"), System.Drawing.Image)
        Me.btnEliminarLicencia.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnEliminarLicencia.Location = New System.Drawing.Point(231, 206)
        Me.btnEliminarLicencia.Name = "btnEliminarLicencia"
        Me.btnEliminarLicencia.Size = New System.Drawing.Size(142, 59)
        Me.btnEliminarLicencia.TabIndex = 3
        Me.btnEliminarLicencia.Text = "Eliminar Licencia"
        Me.btnEliminarLicencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminarLicencia.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Guid Aplicación"
        '
        'txtGuidAplicacion
        '
        Me.txtGuidAplicacion.Location = New System.Drawing.Point(109, 91)
        Me.txtGuidAplicacion.Name = "txtGuidAplicacion"
        Me.txtGuidAplicacion.Size = New System.Drawing.Size(264, 20)
        Me.txtGuidAplicacion.TabIndex = 4
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(392, 319)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGuidAplicacion)
        Me.Controls.Add(Me.btnEliminarLicencia)
        Me.Controls.Add(Me.btnLicenciar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDireccionMAC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AlfaSW Licenciamiento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDireccionMAC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLicenciar As System.Windows.Forms.Button
    Friend WithEvents btnEliminarLicencia As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGuidAplicacion As System.Windows.Forms.TextBox

End Class
