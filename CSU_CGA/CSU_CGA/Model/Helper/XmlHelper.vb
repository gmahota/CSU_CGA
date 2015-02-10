Imports System.IO

Imports System.Xml.Serialization
Imports System.Xml

Public Class XmlHelper
    Public filename = My.Application.Info.DirectoryPath + "\Resources\Config.xml"

    Public Sub loadFolder()
        Try
            Dim doc As XmlDocument = New XmlDocument
            doc.Load(filename)

            Dim pastas As XmlNode = doc.SelectSingleNode("/Configuracao/geral/Pastas")

            For Each node As XmlNode In pastas
                If (Not System.IO.Directory.Exists(node.Attributes.GetNamedItem("folder").InnerText)) Then
                    System.IO.Directory.CreateDirectory(node.Attributes.GetNamedItem("folder").InnerText)
                End If
            Next

        Catch ex As Exception

        End Try

        

    End Sub

    Public Function daPasta(tipo As String) As String
        Try
            Dim doc As XmlDocument = New XmlDocument
            doc.Load(filename)

            Dim pastas As XmlNode = doc.SelectSingleNode("/Configuracao/geral/Pastas")

            For Each node As XmlNode In pastas
                If (tipo = node.Attributes.GetNamedItem("tipo").InnerText) Then
                    Return node.Attributes.GetNamedItem("folder").InnerText
                End If
                
            Next
        Catch ex As Exception

        End Try
        Return ""
    End Function
End Class
