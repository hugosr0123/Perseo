Public Class DatosConexionBD
    Private MiServidor As String
    Private MiBD As String
    Private MiUsuario As String
    Private MiContrasena As String
    Private MiCadenaConexion As String


    ''' <summary>
    ''' Constructor de la clase
    ''' </summary>
    Public Sub New()
        Servidor = "servidor"
        BD = "bd"
        Usuario = "usuario"
        Contrasena = "contrasena"
    End Sub


    ''' <summary>
    ''' Regresa el valor de la variable MiServidor 
    ''' </summary>
    Public Property Servidor() As String
        Get
            Return MiServidor
        End Get
        Set(value As String)
            MiServidor = value
        End Set
    End Property


    ''' <summary>
    ''' Regresa el valor de la variable MiInstanciaBD 
    ''' </summary>
    Public Property BD() As String
        Get
            Return MiBD
        End Get
        Set(value As String)
            MiBD = value
        End Set
    End Property


    ''' <summary>
    ''' Regresa el valor de la variable MiUsuario 
    ''' </summary>
    Public Property Usuario() As String
        Get
            Return MiUsuario
        End Get
        Set(value As String)
            MiUsuario = value
        End Set
    End Property


    ''' <summary>
    ''' Regresa el valor de la variable MiContrasena 
    ''' </summary>
    Public Property Contrasena() As String
        Get
            Return MiContrasena
        End Get
        Set(value As String)
            MiContrasena = value
        End Set
    End Property


    ''' <summary>
    ''' Regresa la cadena de conexion a la bd
    ''' </summary>
    Public ReadOnly Property CadenaConexion() As String
        Get
            MiCadenaConexion = "Provider=sqloledb;" & _
                     "Data Source=" + MiServidor + ";" & _
                     "Initial Catalog=" + MiBD + ";" & _
                     "User Id=" + MiUsuario + ";Password=" + MiContrasena + ""
            Return MiCadenaConexion
        End Get
    End Property
End Class
