Public Class MetodosGlobales


    ''' <summary>
    ''' Obtiene el guid de la aplicación
    ''' </summary>
    Public Shared Function ObtenerGuidAplicacion() As String

        Dim GuidAplicacion As String = New Guid(CType(My.Application.GetType.Assembly.GetCustomAttributes(GetType(Runtime.InteropServices. _
                                                        GuidAttribute), False)(0), Runtime.InteropServices.GuidAttribute).Value).ToString
        Return GuidAplicacion
    End Function

End Class
