Imports System.IO
Imports System.Collections.ObjectModel
Imports CSU_CGA

Class MainWindow
    Public listFiles As ObservableCollection(Of Ficheiro)
    Public jury_controller As Jvris_Controller


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim lista = CType(Me.Resources("ListFicheiros"), Ficheiro_Controller)


        'jury_controller = New Jvris_Controller()

        For Each fich As Ficheiro In lista

            If fich.Sel = "True" Then
                jury_controller.Integracao_Primavera(fich.FicheiroSel)
            End If


        Next
        actualizar()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Show()

        listFiles = New ObservableCollection(Of Ficheiro)()
        ' Add any initialization after the InitializeComponent() call.
        jury_controller = New Jvris_Controller()
        jury_controller.AbreEmpresaPrimavera(1, "cga2011", "accsys", "accsys2011")

    End Sub

    Private Sub ComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

        actualizar()


    End Sub

    Private Sub actualizar()
        Dim caminho As String = ""

        Dim sel As ListBoxItem = cbFicheiro.SelectedValue

        Select Case sel.Content
            Case "Por Importar" : caminho = "C:\jvris_primavera\Por Importar"
            Case "Importado" : caminho = "C:\jvris_primavera\Importado"
            Case "Cancelados" : caminho = "C:\jvris_primavera\Cancelados"
            Case "Erro de Importação" : caminho = "C:\jvris_primavera\Erro de Importação"
        End Select


        Dim FileNm As DirectoryInfo = New DirectoryInfo(caminho)
        Dim filename = FileNm.GetFiles()

        Dim lista = CType(Me.Resources("ListFicheiros"), Ficheiro_Controller)

        lista.Clear()

        For Each f As FileInfo In filename
            lista.Add(
                New Ficheiro(True, f.ToString(), f)
            )
        Next

    End Sub

End Class
