Public Class Principal

    Private MiLicenciaminento As LicenciamientoSW.VerificadorSoftware


    ''' <summary>
    ''' Licenciar el producto
    ''' </summary>
    Private Sub btnLicenciar_Click(sender As Object, e As EventArgs) Handles btnLicenciar.Click

        'Valida que se haya tecleado el guid de la aplicación
        If Me.txtGuidAplicacion.Text.Trim.Length = 0 Then
            MsgBox("Debe especificar el GUID de la aplicación a licenciar", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        If MsgBox("¿Está seguro que desea agregar la licencia del producto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Try
                MiLicenciaminento = New LicenciamientoSW.VerificadorSoftware(Me.txtGuidAplicacion.Text)
                MiLicenciaminento.AgregarLicencia()
                MsgBox("Se ha creado correctamente la licencia del producto", MsgBoxStyle.Information, "Aviso")
            Catch ex As Exception
                MsgBox(e.ToString, MsgBoxStyle.Critical, "Error")
            End Try

        End If

    End Sub


    ''' <summary>
    ''' Eliminar la licencia actual del producto
    ''' </summary>
    Private Sub btnEliminarLicencia_Click(sender As Object, e As EventArgs) Handles btnEliminarLicencia.Click

        'Valida que se haya tecleado el guid de la aplicación
        If Me.txtGuidAplicacion.Text.Trim.Length = 0 Then
            MsgBox("Debe especificar el GUID de la aplicación a licenciar", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        If MsgBox("¿Está seguro que desea eliminar la licencia actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                MiLicenciaminento = New LicenciamientoSW.VerificadorSoftware(Me.txtGuidAplicacion.Text)
                MiLicenciaminento.EliminarLicenciaIndividual()
                MsgBox("Se ha eliminado correctamente la licencia del producto", MsgBoxStyle.Information, "Aviso")
            Catch ex As Exception
                MsgBox(e.ToString, MsgBoxStyle.Critical, "Error")
            End Try
        End If

    End Sub


    ''' <summary>
    ''' Evento ejecutado durante la carga del formulario
    ''' </summary>
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim GuidAplicacionVacioSoloEnCargaInicial As String = "" 'Solo en la carga inicial si puede ser vacía esta cadena

        MiLicenciaminento = New LicenciamientoSW.VerificadorSoftware(GuidAplicacionVacioSoloEnCargaInicial)
        Me.txtDireccionMAC.Text = MiLicenciaminento.DireccionMAC

        Me.txtGuidAplicacion.Text = ""
        Me.txtGuidAplicacion.Focus()
    End Sub

End Class
