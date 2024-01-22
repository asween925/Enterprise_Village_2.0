Imports System.Net
Imports System.Web.Http
Imports System.Text.Json

Public Class WeatherAPI
    Dim apikey As String = "a4e3d706b2dbc3eaf740fa64ea113707"
    Dim location As String = "Largo, FL"
    'Dim startDate As String = DateTime.Now
    Dim apiEndpoint As String = ""

End Class

Public Class WeatherResponse
    Public Property Days As List(Of WeatherDay)
End Class

Public Class WeatherDay
    Public Property DatetimeStr As String
    Public Property Temp2m As Double
    Public Property Precipitation As Double
    ' Add more properties as needed
End Class
