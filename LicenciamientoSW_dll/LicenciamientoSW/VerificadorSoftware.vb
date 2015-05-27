Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Xml.Serialization


Public Class VerificadorSoftware

    Declare Auto Function GetShortPathName Lib "kernel32.dll" _
(ByVal lpszLongPath As String, ByVal lpszShortPath As StringBuilder, ByVal cchBuffer As Integer) As Integer

    Private MiDatosConexionBD As New DatosConexionBD()

    Private MiDireccionMAC As String
    Private MiDireccionMACEncriptada As String
    Private MiDireccionMACDesncriptada As String


    Private MiLlaveSecreta As String ' = "65aS&B8nyEXDst3LYn*UU2x9Unw-HK@enas3eth7qeswu8afreq6k@t*sP-@e7R6+v=Cf+LHNEG2#F26@FTdfCeU8%G!n77y&@pnZT^*R#?Nh8BzyxSs$uhyCmBC=QBt2^#vn29bmnC26Fb+r7$ET85@aKubAxECRewaFrat6!wUDasAjH4gw$7%=Q&$#mByXPs%qjcX^AGcWHKcwF-fybezA+*rD@DT6LET+4pWHT5#fg$_9h3cs7jkv73scWESed&*5xxUU^@HfpMC25-gB@%F"


    ''' <summary>
    ''' Constructor de la clase
    ''' </summary>
    Public Sub New(ByVal GuidAplicacion As String)
        MiDireccionMAC = obtenerMACAddress()
        MiLlaveSecreta = GuidAplicacion
    End Sub


    ''' <summary>
    ''' Regresa la dirección MAC encriptada
    ''' </summary>
    Public ReadOnly Property DireccionMACEncriptada
        Get
            If MiDireccionMACEncriptada = "" Then
                MiDireccionMACEncriptada = Encriptar(MiDireccionMAC, MiLlaveSecreta)
            End If
            Return MiDireccionMACEncriptada
        End Get
    End Property


    ''' <summary>
    ''' Regresa la dirección MAC 
    ''' </summary>
    Public ReadOnly Property DireccionMAC As String
        Get
            If MiDireccionMAC = "" Then
                MiDireccionMAC = obtenerMACAddress()
            End If

            Return MiDireccionMAC
        End Get
    End Property


    ''' <summary>
    ''' Validación que la licencia del sistema sea válida
    ''' </summary>
    ''' <returns>VERDADERO si la licencia es válida</returns>
    Public Function ValidarLicencia() As Boolean
        Dim conexionActiva As OleDbConnection = Nothing
        Dim comando As OleDbCommand
        Dim consulta As String, licencia As String = ""
        Dim resultado As Boolean = False

        Try
            lecturaArchivoSerializado()
            conexionActiva = New OleDbConnection(MiDatosConexionBD.CadenaConexion)

            consulta = ("SELECT * FROM TLicencia WHERE Licencia='" + DireccionMACEncriptada + "' ")
            comando = New OleDbCommand(consulta)
            comando.Connection = conexionActiva
            conexionActiva.Open()

            Dim lectorDatos As OleDbDataReader = comando.ExecuteReader()

            While lectorDatos.Read()
                licencia = lectorDatos("Licencia")
            End While

            If licencia.Length > 0 Then
                If DireccionMAC = Desencriptar(licencia, MiLlaveSecreta) Then
                    resultado = True
                Else
                    resultado = False
                End If
            End If

        Catch ex As Exception
            resultado = False
            Throw ex
        Finally
            conexionActiva.Close()
        End Try

        Return resultado

    End Function


    ''' <summary>
    ''' Agrega una nueva licencia al sistema
    ''' </summary>
    Public Sub AgregarLicencia()
        Dim conexionActiva As OleDbConnection = Nothing
        Dim comando As OleDbCommand
        Dim consulta As String

        Try
            lecturaArchivoSerializado()
            conexionActiva = New OleDbConnection(MiDatosConexionBD.CadenaConexion)

            ''Se elimina primero la licencia actual
            'consulta = ("DELETE  FROM TLicencia")
            'comando = New OleDbCommand(consulta)
            'comando.Connection = conexionActiva
            'conexionActiva.Open()
            'comando.ExecuteScalar()

            'Agrega la nueva licencia
            consulta = "INSERT INTO TLicencia(Licencia) VALUES('" + DireccionMACEncriptada + "' ) "
            comando = New OleDbCommand(consulta)
            comando.Connection = conexionActiva
            conexionActiva.Open()
            comando.ExecuteScalar()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' Eliminar la licencia del sistema que concuerde con la dirección MAC donde está siendo ejecutado el comando
    ''' </summary>
    Public Sub EliminarLicenciaIndividual()
        Dim conexionActiva As OleDbConnection = Nothing
        Dim comando As OleDbCommand
        Dim consulta As String

        Try
            lecturaArchivoSerializado()
            conexionActiva = New OleDbConnection(MiDatosConexionBD.CadenaConexion)

            'Se elimina  la licencia actual
            consulta = ("DELETE  FROM TLicencia  WHERE Licencia='" + DireccionMACEncriptada + "' ")
            comando = New OleDbCommand(consulta)
            comando.Connection = conexionActiva
            conexionActiva.Open()
            comando.ExecuteScalar()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' Eliminar todas las licencias del sistema
    ''' </summary>
    Public Sub EliminarLicencias()
        Dim conexionActiva As OleDbConnection = Nothing
        Dim comando As OleDbCommand
        Dim consulta As String

        Try
            lecturaArchivoSerializado()
            conexionActiva = New OleDbConnection(MiDatosConexionBD.CadenaConexion)

            'Se elimina  la licencia actual
            consulta = ("DELETE  FROM TLicencia  ")
            comando = New OleDbCommand(consulta)
            comando.Connection = conexionActiva
            conexionActiva.Open()
            comando.ExecuteScalar()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' Obtener el algoritmo que será usado para la encriptación/desencriptación
    ''' </summary>
    Private Function obtenerAlgoritmo(ByVal llaveSecreta As String) As RijndaelManaged

        Const llaveInterna As String = "wyW4l_nd)TD;4<77V93u2u5_&eF@8cT040fw0LO7_*US21KZHn3Es9Y83&wyW4l_nd)TD;4<77V93u2u5_&F@c0%0%fw0LO7L775-aae*zt^f%KHk^eZH-nPC$k4P5hWNV+*yQEg_+!gs+*kP9eZxNFwe*BN8YWR?7US*7JBBFqH$6+9CL#QwjynaN^H9_^68_ef_*US21KZHn3Es5Fa9Y83&klb3s=re3R*VkmF6JNg?RJ!d9JY3%LaM_W_x_!n"
        Const tamanoLlave As Integer = 256

        Dim keyBuilder As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(llaveSecreta, Encoding.Unicode.GetBytes(llaveInterna))
        Dim algoritmo As RijndaelManaged = New RijndaelManaged()

        algoritmo.KeySize = tamanoLlave
        algoritmo.IV = keyBuilder.GetBytes(CType(algoritmo.BlockSize / 8, Integer))
        algoritmo.Key = keyBuilder.GetBytes(CType(algoritmo.KeySize / 8, Integer))
        algoritmo.Padding = PaddingMode.PKCS7

        Return algoritmo

    End Function


    ''' <summary>
    ''' Encriptar la cadena recibida como parámetro y aplicando la llava secreta recibida
    ''' </summary>
    Private Function Encriptar(ByVal cadenaPorEncriptar As String, ByVal llaveSecreta As String) As String
        Dim cadenaEncriptada As String = Nothing

        Using flujoSalida As MemoryStream = New MemoryStream()

            Dim algoritmo As RijndaelManaged = obtenerAlgoritmo(llaveSecreta)

            Using flujoDatosEncriptacion As CryptoStream = New CryptoStream(flujoSalida, algoritmo.CreateEncryptor(), CryptoStreamMode.Write)

                Dim BufferDeEntrada() As Byte = Encoding.Unicode.GetBytes(cadenaPorEncriptar)

                flujoDatosEncriptacion.Write(BufferDeEntrada, 0, BufferDeEntrada.Length)
                flujoDatosEncriptacion.FlushFinalBlock()
                cadenaEncriptada = Convert.ToBase64String(flujoSalida.ToArray())

            End Using

        End Using


        Return cadenaEncriptada

    End Function


    ''' <summary>
    ''' Desencriptar la cadena encriptada recibida como parámetro y aplicando la llava secreta recibida
    ''' </summary>
    Private Function Desencriptar(ByVal cadenaEncriptada As String, ByVal llaveSecreta As String) As String
        Dim cadenaDesencriptada As String = Nothing

        Using flujoEntrada As MemoryStream = New MemoryStream(Convert.FromBase64String(cadenaEncriptada))

            Dim algoritmo As RijndaelManaged = obtenerAlgoritmo(llaveSecreta)

            Using flujoDatosEncriptacion As CryptoStream = New CryptoStream(flujoEntrada, algoritmo.CreateDecryptor(), CryptoStreamMode.Read)

                Dim BufferDeSalida(0 To CType(flujoEntrada.Length - 1, Integer)) As Byte
                Dim leerBytes As Integer = flujoDatosEncriptacion.Read(BufferDeSalida, 0, CType(flujoEntrada.Length, Integer))
                cadenaDesencriptada = Encoding.Unicode.GetString(BufferDeSalida, 0, leerBytes)

            End Using

        End Using

        Return cadenaDesencriptada

    End Function


    ''' <summary>
    ''' Obtener la MacAddress del equipo
    ''' </summary>
    Private Function obtenerMACAddress() As String

        Try
            Dim interfacesDeRed As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim MAC As String = String.Empty


            For Each interfaceDeRed In interfacesDeRed

                Select Case interfaceDeRed.NetworkInterfaceType

                    'Excluir tuneles, loopbacks y ppp                    
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not interfaceDeRed.GetPhysicalAddress.ToString = String.Empty And Not interfaceDeRed.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            MAC = interfaceDeRed.GetPhysicalAddress.ToString
                            Exit For
                        End If

                End Select

            Next interfaceDeRed

            Return MAC

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function


    ''' <summary>
    ''' Lectura del archivo serializado Config.xml
    ''' </summary>
    Public Sub lecturaArchivoSerializado()
        Try
            Dim archivoSerializado As New FileStream(Environment.CurrentDirectory + "\Config.xml", FileMode.Open)
            Dim xml_serializar As New XmlSerializer(GetType(DatosConexionBD))
            MiDatosConexionBD = xml_serializar.Deserialize(archivoSerializado)
            archivoSerializado.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Crea el archivo serializado Config.xml 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub crearArchivoSerializado()
        Try

            Dim archivoSerializado As New FileStream(Environment.CurrentDirectory + "\Config.xml", FileMode.Create)
            Dim DatosConexion As New DatosConexionBD()
            Dim xml_serializar As New XmlSerializer(GetType(DatosConexionBD))
            xml_serializar.Serialize(archivoSerializado, DatosConexion)
            archivoSerializado.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
